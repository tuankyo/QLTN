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
using Microsoft.VisualBasic;

namespace Man.MasterImport
{
    public partial class UtaUpdateMasterImport : Man.PageBase
    {
        private string importType = "3";

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
                string sql = "DELETE FROM SongImport WHERE SessionId='" + Session.SessionID + "' and ImportType = '"+ importType +"'";
                DbHelper.ExecuteNonQuery(sql);
                sql = "DELETE FROM SongMediaTemp WHERE SessionId='" + Session.SessionID + "' and ImportType = '" + importType + "'";
                DbHelper.ExecuteNonQuery(sql);


                DataTable dt = new DataTable();
                DataTable dtTmp = new DataTable();
                dt.Load(csvRead);
                

                string[] header = csvRead.GetFieldHeaders();

                if (!validFormat(dt))
                {
                    return;
                }

                if (dt.Rows.Count > 0)
                {

                    //フォーマットﾁｪｯｸ
                    for (int i = 0; i < Constants.ImportUtaDataHeader.Length; i++)
                    {
                        if (!Constants.ImportUtaDataHeader[i].Equals(header[i]))
                        {
                            mvImportMaster.AddError("CSVファイルのヘッダー部分が間違っています・・・");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));
                    dt.Columns.Add("ImportType", Type.GetType("System.String"));
                    dt.Columns.Add("Status");

                    dt.Columns.Add("DelFlag", Type.GetType("System.String"));
                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));

                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["ImportType"] = importType;
                        dt.Rows[i]["DelFlag"] = "0";
                        dt.Rows[i]["Updated"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "SongImport";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportUtaDataHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportUtaDataDbRef[i]);
                        }

                        copy.ColumnMappings.Add(dt.Columns.Count - 8, "SessionId");
                        copy.ColumnMappings.Add(dt.Columns.Count - 7, "ImportType");
                        copy.ColumnMappings.Add(dt.Columns.Count - 6, "Status");

                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "DelFlag");
                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Updated");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");

                        copy.WriteToServer(dt);
                    }
                }

                //DbHelper.ExecuteNonQuery("Update SongImport set Status = 1 where SessionId = '" + Session.SessionID + "' and ImportType = '"+ importType +"' and SongId in (Select SongMediaId from SongMedia where TypeId = '1')");
                //DbHelper.ExecuteNonQuery("Update SongImport set SongImport.CopyrightOrg = Song.CopyrightOrg From SongImport, Song Where SongImport.SongId = Song.SongId");
                DbHelper.ExecuteNonQuery("Update SongImport set Status = 1, SongImport.CopyrightOrg = S.CopyrightOrg, SongImport.CopyrightContractId = S.CopyrightContractId , SongTitle = S.Title, SongTitleReading = S.TitleReading, ArtistId = S.ArtistId, " +
                                        " GenreId = S.GenreId, AlbumId = S.AlbumId, LabelId=S.LabelId, ContractorId = S.ContractorId, IVT = S.IVT, IVTType = S.IVTType, "+
                                        " JasracWorksCode = S.JasracWorksCode, IsrcNo=S.IsrcNo From SongImport, Song S where SessionId = '" + Session.SessionID + "' "+
                                        " and SongImport.ImportType = '" + importType + "' and S.SongId = SongImport.SongId ");

                sql = "Select * from SongImport where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                SqlDatabase db = new SqlDatabase();
                DataSet ds = new DataSet();
                DataSet dsTmp = new DataSet();

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                dt = ds.Tables[0];

                ArrayList sqlUpdate = new ArrayList();

                dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    string contractorId = row["ContractorId"].ToString();
                    string uta_rate = "";
                    if (!"".Equals(contractorId))
                    {
                        ContractorData data = new ContractorData();
                        ITransaction tran = factory.GetLoadObject(data, contractorId);
                        Execute(tran);
                        if (!HasError)
                        {
                            //編集の場合、DBに既存データを取得して設定する。                            data = (ContractorData)tran.Result;
                            uta_rate = data.uta_rate;
                        }
                    }

                    ArrayList sqlAddSongMedia = GetSqlAddSongMediaKey(row,uta_rate);
                    for (int i = 0; i < sqlAddSongMedia.Count; i++)
                    {
                        sqlUpdate.Add(sqlAddSongMedia[i]);
                    }
                }

                for (int i = 0; i < sqlUpdate.Count; i++)
                {
                    DbHelper.ExecuteNonQuery((string)sqlUpdate[i]);
                }

                //うた既存　=>　status=1
                DbHelper.ExecuteNonQuery("Update SongMediaTemp set SongMediaTemp.Status = 1 From SongMediaTemp, SongMedia SM Where SongMediaTemp.SongMediaId = SM.SongMediaId and SM.TypeId = '2' and SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'");

                db.Close();
                ///////////
                Session["FolderPath"] = fileUpload.FileName;
                Response.Redirect("UtaUpdateListMasterImport.aspx", false);
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

        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private ArrayList GetSqlAddSongMediaKey(DataRow row, string uta_rate)
        {
            try
            {
                ArrayList returnList = new ArrayList();

                string Updated = DateTime.Now.ToString("yyyyMMddHHmmss");
                string Updator = Page.User.Identity.Name;
                string Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                string Creator = Page.User.Identity.Name;

                string songId = row["SongId"].ToString();
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
                string fileName = "";
                string songMediaId = "";
                string price = "";
                string haishinEndDate = "";

                haishinDate = row["RemoveDateUta"].ToString();
                haishinEndDate = row["HaishinEndDateUta"].ToString();

                price = row["PriceUta"].ToString();

                string rate = "".Equals(uta_rate) ? "0" : uta_rate;

                for (int i = 0; i < Constants.SongMediaExt.Length; i++)
                {
                    songMediaId = row["SongId"].ToString() + Constants.SongMediaExt[i];
                    title = row["UtaTitle" + Constants.SongMediaExt[i]].ToString().Replace("'", "''");
                    isrcNo = row["UtaIsrcNo" + Constants.SongMediaExt[i]].ToString();
                    fileName = row["UtaFileName" + Constants.SongMediaExt[i]].ToString();

                    if (!"".Equals(price) && !"".Equals(rate))
                    {
                        priceNoTax = Func.GetPriceNoTax(price);
                        buyUnique = Func.GetBuyUnique(priceNoTax, rate);
                        copyrightFeeUnique = Func.GetCopyrightFeeUnique(copyrightContractId, priceNoTax, "2");
                        KDDICommissionUnique = Func.GetKDDICommissionUnique(priceNoTax);
                        profitUnique = Func.GetProfitUnique(priceNoTax, buyUnique, copyrightFeeUnique, KDDICommissionUnique);
                    }

                    if (!"".Equals(title) || !"".Equals(isrcNo) || !"".Equals(fileName))
                    {
                        returnList.Add("Insert into SongMediaTemp (SessionId, ImportType, SongMediaId, SongId, Title, FileName, TypeId, ISRCNo, rate , Price,Flag, HaishinDate, HaishinEndDate,PriceNoTax, BuyUnique, CopyrightFeeUnique, KDDICommissionUnique, ProfitUnique,DelFlag,Updated , Updator, Created, Creator) " +
                            "values('" + Session.SessionID + "', '" + importType + "', '" + songMediaId + "', '" + songId + "','" + title.Replace("'", "''") + "', '" + fileName.Replace("'", "''") + "','2', '" + isrcNo + "','" + rate + "','" + price + "','" + Flag + "'," + ("".Equals(haishinDate) ? "null" : "'" + haishinDate + "'") + "," + ("".Equals(haishinEndDate) ? "null" : "'" + haishinEndDate + "'") + ", '" + priceNoTax + "','" + buyUnique + "','" + copyrightFeeUnique + "','" + KDDICommissionUnique + "','" + profitUnique + "', '0','" + Updated + "', '" + Updator + "', '" + Created + "', '" + Creator + "')");
                    }
                }
                return returnList;
            }
            catch (Exception exc)
            {
                return null;
            }
        }


        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetKey(DataObject data, string[] condition)
        {
            string key = "";
            for (int i = 0; i < condition.Length; i++)
            {
                string sql = "SELECT " + data.ObjectKeyColumnName + " FROM " + data.ObjectKeyTableName + " WHERE " + condition[i];
                key = DbHelper.GetScalar(sql);
                if (!"".Equals(key))
                {
                    break;
                }
            }
            return key;
        }

        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string CreateKey(DataObject data,string prefix)
        {
            int length = data.KeyAttributeData.MaxLength;
            string tmp = String.Format("", length);

            string sql = "SELECT max(maxid) from (SELECT SUBSTRING(" + data.ObjectKeyColumnName + ", " + (prefix.Length + 1) + ", " + length + ") as maxid FROM " + data.ObjectKeyTableName + ") as tmp WHERE maxid < '" + "".PadRight(length - prefix.Length, '9') + "'";
            
            
            int key = 0;
            try
            {
                key = Convert.ToInt32(DbHelper.GetScalar(sql));
                key++;
            }
            catch
            {
                key = 1;
            }

            bool keyFlg = true;
            while (keyFlg)
            {
                string tmpKey = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
                sql = "SELECT count(*) from " + data.ObjectKeyTableName + " WHERE " + data.ObjectKeyColumnName + " = '" + tmpKey + "'";
                if (Convert.ToInt32(DbHelper.GetScalar(sql)) != 1)
                {
                    keyFlg = false;
                }
                else
                {
                    key--;
                }
            }
            
            return prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }

        private bool validFormat(DataTable dt)
        {
            Hashtable tmpKey = new Hashtable();

            bool valid = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string message = "";
                string strWID = !(dt.Rows[i][0] is System.DBNull) ? (string)dt.Rows[i][0] : "";
                if (tmpKey.Contains(strWID))
                {
                    mvImportMaster.AddError(strWID + "が重複です。");
                    valid = false;
                    continue;
                }
                else
                {
                    tmpKey.Add(strWID, strWID);
                }

                string strHaishinUta = !(dt.Rows[i][1] is System.DBNull) ? (string)dt.Rows[i][1] : "";
                string strPriceUta = !(dt.Rows[i][3] is System.DBNull) ? (string)dt.Rows[i][3] : "";

                if ("".Equals(strWID))
                {
                    message += "【" + Constants.ImportUtaDataHeader[0] + "】" + Func.invalidNull();
                }
                else if (strWID.Length > 8)
                {
                    message += "【" + Constants.ImportUtaDataHeader[0] + "】" + Func.invalidLenght(8);
                }
                if (!"".Equals(strHaishinUta) && !Func.IsDate(strHaishinUta))
                {
                    message += "【" + Constants.ImportUtaDataHeader[1] + "】" + Func.invalidDate();
                }
                if (!"".Equals(strPriceUta) && !Func.IsInterger(strPriceUta))
                {
                    message += "【" + Constants.ImportUtaDataHeader[3] + "】" + Func.invalidNumber();
                }

                for (int j = 4; j <= 21; j++)
                {
                    string strTitleUta = !(dt.Rows[i][j] is System.DBNull) ? (string)dt.Rows[i][j] : "";
                    if (!"".Equals(strTitleUta) && strTitleUta.Length > 255)
                    {
                        message += "【" + Constants.ImportUtaDataHeader[j] + "】" + Func.invalidLenght(255);
                    }
                }

                for (int j = 22; j <= 39; j++)
                {
                    string strIsrcUta = !(dt.Rows[i][j] is System.DBNull) ? (string)dt.Rows[i][j] : "";
                    if (!"".Equals(strIsrcUta) && strIsrcUta.Length > 50)
                    {
                        message += "【" + Constants.ImportUtaDataHeader[j] + "】" + Func.invalidLenght(50);
                    }
                }

                for (int j = 40; j <= 57; j++)
                {
                    string strFileName = !(dt.Rows[i][j] is System.DBNull) ? (string)dt.Rows[i][j] : "";
                    if (!"".Equals(strFileName) && strFileName.Length > 200)
                    {
                        message += "【" + Constants.ImportUtaDataHeader[j] + "】" + Func.invalidLenght(255);
                    }
                }

                if (!"".Equals(message))
                {
                    valid = false;
                    mvImportMaster.AddError("Error (Line)" + (i+2) + ": " + message);
                }
            }
            return valid;
        }        
    }
}
