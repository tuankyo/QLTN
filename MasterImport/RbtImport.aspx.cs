using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using Man.Utils;
using System.IO;
using Gnt.Utils.FastCsv;
using System.Data.SqlTypes;
namespace Man.MasterImport
{
    public partial class RbtImport : Man.PageBase
    {
        public string GetPath
        {
            get
            {
                return "../Update/Tmp/" + Page.User.Identity + "/";
            }
        }

        protected DataTable FileListTable
        {
            get
            {
                object obj = ViewState["FileListTable"];
                if (obj == null)
                {
                    return null;
                }
                else
                {
                    return (DataTable)obj;
                }
            }
            set
            {
                ViewState["FileListTable"] = value;
            }
        }

        /// <summary>
        /// Init file list table
        /// </summary>
        private void InitFileListTable()
        {
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitFileListTable();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!fileUpload.HasFile)
            {
                mvImportMaster.AddError("ファイルを見つかりません・・・");
                return;
            }
            CsvReader csvRead = null;
            Hashtable artistKeyMap = new Hashtable();
            Hashtable labelKeyMap = new Hashtable();
            Hashtable albumKeyMap = new Hashtable();

            try
            {
                string[] array = fileUpload.FileName.Split('.');
                string ext = string.Empty;
                if (array.Length > 0)
                {
                    ext = array[array.Length - 1];
                }
                if (ext.Length == 0) return;

                ext = ext.ToUpper();

                if (!"csv".Equals(ext.ToLower()))
                {
                    mvImportMaster.AddError("CSVファイルを選択してください・・・");
                    return;
                }
                if (File.Exists(Server.MapPath("./") + fileUpload.FileName))
                {
                    File.Delete(Server.MapPath("./") + fileUpload.FileName);
                }
                fileUpload.SaveAs(Server.MapPath("./") + fileUpload.FileName);

                csvRead = new CsvReader(Server.MapPath("./") + fileUpload.FileName, true, ',');
                csvRead.IsCheckQuote = true;
                string sql = "DELETE FROM SongMediaRbtTmp WHERE SessionId='" + Session.SessionID + "' ";
                DbHelper.ExecuteNonQuery(sql);


                DataTable dt = new DataTable();
                DataTable dtTmp = new DataTable();
                dt.Load(csvRead);


                string[] header = csvRead.GetFieldHeaders();
                if (dt.Rows.Count > 0)
                {

                    //フォーマットﾁｪｯｸ
                    for (int i = 0; i < Constants.ImportRbtHeader.Length; i++)
                    {
                        if (!Constants.ImportRbtHeader[i].Equals(header[i]))
                        {
                            mvImportMaster.AddError("CSVファイルのヘッダー部分が間違っています・・・");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));
                    dt.Columns.Add("Status");

                    dt.Columns.Add("DelFlag", Type.GetType("System.String"));
                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["DelFlag"] = "0";
                        dt.Rows[i]["Updated"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "SongMediaRbtTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportRbtHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportRbtDbRef[i]);
                        }

                        copy.ColumnMappings.Add(dt.Columns.Count - 7, "SessionId");
                        copy.ColumnMappings.Add(dt.Columns.Count - 6, "Status");

                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "DelFlag");
                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Updated");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");

                        copy.WriteToServer(dt);
                    }
                }
                string Updated = DateTime.Now.ToString("yyyyMMddHHmmss");
                string Updator = Page.User.Identity.Name;
                string Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string Creator = Page.User.Identity.Name;

                sql = "Select * from SongMediaRbtTmp where SessionId = '" + Session.SessionID + "'";
                SqlDatabase db = new SqlDatabase();
                DataSet ds = new DataSet();
                DataSet dsTmp = new DataSet();

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                dt = ds.Tables[0];

                ArrayList insertList = new ArrayList();
                //record
                foreach (DataRow row in dt.Rows)
                {
                    string contractorId = row["ContractorId"].ToString();
                    string rbt_rate = "";
                    if (!"".Equals(contractorId))
                    {
                        ContractorData data = new ContractorData();
                        ITransaction tran = factory.GetLoadObject(data, contractorId);
                        Execute(tran);
                        if (!HasError)
                        {
                            //編集の場合、DBに既存データを取得して設定する。
                            data = (ContractorData)tran.Result;
                            rbt_rate = data.rbt_rate;
                        }
                    }
                    string songId = row["SongId"].ToString();
                    string PRText = row["PRText"].ToString();
                    string Flag = row["Flag"].ToString();

                    string haishinDate = "";
                    string copyrightContractId = row["CopyrightContractId"].ToString();
                    string priceNoTax = "";
                    string buyUnique = "";
                    string copyrightFeeUnique = "";
                    string KDDICommissionUnique = "";
                    string profitUnique = "";
                    string title = "";
                    string isrcNo = "";
                    //string fileName = "";
                    string songMediaId = "";
                    string price = "";

                    price = row["Price"].ToString();
                    songMediaId = row["SongMediaId"].ToString();
                    title = row["Title"].ToString().Replace("'", "''");
                    isrcNo = row["IsrcNo"].ToString();
                    //fileName = row["UtaFileName" + Constants.SongMediaExt[i]].ToString();
                    haishinDate = row["HaishinDate"].ToString();

                    string rate = "".Equals(rbt_rate) ? "0" : rbt_rate;

                    if (!"".Equals(price) && !"".Equals(rbt_rate))
                    {
                        priceNoTax = Func.GetPriceNoTax(price);
                        buyUnique = Func.GetBuyUnique(priceNoTax, rbt_rate);
                        copyrightFeeUnique = Func.GetCopyrightFeeUnique(copyrightContractId, priceNoTax, "4");
                        KDDICommissionUnique = Func.GetKDDICommissionUnique(priceNoTax);
                        profitUnique = Func.GetProfitUnique(priceNoTax, buyUnique, copyrightFeeUnique, KDDICommissionUnique);
                    }

                    if ("".Equals(rbt_rate))
                    {
                        rbt_rate = "0";
                    }

                    if (!"".Equals(title) || !"".Equals(isrcNo))
                    {
                        insertList.Add("Insert into SongMedia (SongMediaId, SongId, Title, TypeId, ISRCNo, rate , Price,PRText,Flag, HaishinDate,PriceNoTax, BuyUnique, CopyrightFeeUnique, KDDICommissionUnique, ProfitUnique,DelFlag,Updated , Updator, Created, Creator) " +
                            "values('" + songMediaId + "', '" + songId + "','" + title + "','4', '" + isrcNo + "','" + rbt_rate + "','" + price + "','" + PRText + "','" + Flag + "','" + haishinDate + "', '" + priceNoTax + "','" + buyUnique + "','" + copyrightFeeUnique + "','" + KDDICommissionUnique + "','" + profitUnique + "', '0','" + Updated + "', '" + Updator + "', '" + Created + "', '" + Creator + "')");
                    }
                }

                for (int i = 0; i < insertList.Count; i++)
                {
                    DbHelper.ExecuteNonQuery((string)insertList[i]);
                }

                db.Close();
                ///////////
                DbHelper.ExecuteNonQuery("Delete from SongMediaRbtTmp where SessionId = '"+ Session.SessionID +"'");

                Response.Redirect("ImportFinish.aspx", false);
            }
            catch (Exception ex)
            {
                mvImportMaster.AddError("エラーが発生しました: " + ex.Message);
            }
            finally
            {
                if (csvRead != null)
                {
                    csvRead.Dispose();
                }
            }
        }        
    }
}
