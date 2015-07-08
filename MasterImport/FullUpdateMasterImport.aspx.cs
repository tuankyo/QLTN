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
using System.Threading;

namespace Man.MasterImport
{
    public partial class FullUpdateMasterImport : Man.PageBase
    {
        private string importType = "2";

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
                string sql = "DELETE FROM SongImport WHERE SessionId='" + Session.SessionID + "' and ImportType = '" + importType + "'";
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
                    for (int i = 0; i < Constants.ImportFullDataHeader.Length; i++)
                    {
                        if (!Constants.ImportFullDataHeader[i].Equals(header[i]))
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
                        for (int i = 0; i < Constants.ImportFullDataHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportFullDataDbRef[i]);
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

                DbHelper.ExecuteNonQuery("Update SongImport set SongImport.CopyrightOrg = S.CopyrightOrg, SongImport.CopyrightContractId = S.CopyrightContractId, ContractorId = S.ContractorId From SongImport, Song S Where SongImport.SongId = S.SongId and SessionId = '" + Session.SessionID + "' and SongImport.ImportType = '" + importType + "'");
                //DbHelper.ExecuteNonQuery("Update SongImport set SongImport.CopyrightOrg = Song.CopyrightOrg From SongImport, Song Where SongImport.SongId = Song.SongId and SongImport.ImportType = '" + importType + "' ");
                //DbHelper.ExecuteNonQuery("Update SongImport set ContractorId = S.ContractorId From SongImport, Song S where SessionId = '" + Session.SessionID + "' and SongImport.ImportType = '" + importType + "' and S.SongId = SongImport.SongId ");

                sql = "Select * from SongImport where SessionId = '" + Session.SessionID + "' and ImportType = '" + importType + "'";
                SqlDatabase db = new SqlDatabase();
                DataSet ds = new DataSet();
                DataSet dsTmp = new DataSet();

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                dt = ds.Tables[0];

                ArrayList sqlUpdate = new ArrayList();

                

                foreach (DataRow row in dt.Rows)
                {
                    string contractorId = row["ContractorId"].ToString();
                    string hbunRitsu = "";
                    if (!"".Equals(contractorId))
                    {
                        ContractorData data = new ContractorData();
                        ITransaction tran = factory.GetLoadObject(data, contractorId);
                        Execute(tran);
                        if (!HasError)
                        {
                            //編集の場合、DBに既存データを取得して設定する。
                            data = (ContractorData)tran.Result;
                            hbunRitsu = data.HbunRitsu;
                        }
                    }

                    string price = row["Price"].ToString();
                    string rate = hbunRitsu;
                    string priceNoTax = "";
                    string buyUnique = "";
                    string copyrightFeeUnique = "";
                    string KDDICommissionUnique = "";
                    string profitUnique = "";

                    if (!"".Equals(price) && !"".Equals(rate))
                    {
                        priceNoTax = Func.GetPriceNoTax(price);
                        buyUnique = Func.GetBuyUnique(priceNoTax, rate);
                        copyrightFeeUnique = Func.GetCopyrightFeeUnique(row["CopyrightContractId"].ToString(), priceNoTax, "1");
                        KDDICommissionUnique = Func.GetKDDICommissionUnique(priceNoTax);
                        profitUnique = Func.GetProfitUnique(priceNoTax, buyUnique, copyrightFeeUnique, KDDICommissionUnique);
                    }

                    string songId = row["SongId"].ToString();
                    sqlUpdate.Add("Update SongImport set hbunRitsu = '" + hbunRitsu + "', PriceNoTax = '" + priceNoTax + "', BuyUnique = '" + buyUnique + "', CopyrightFeeUnique = '" + copyrightFeeUnique + "', KDDICommissionUnique = '" + KDDICommissionUnique + "', ProfitUnique = '" + profitUnique + "'where SongId = '" + songId + "' and SessionId = '" + Session.SessionID + "' and SongImport.ImportType = '" + importType + "'");
                }

                for (int i = 0; i < sqlUpdate.Count; i++)
                {
                    DbHelper.ExecuteNonQuery((string)sqlUpdate[i]);
                }

                DbHelper.ExecuteNonQuery("Update SongImport set SongImport.Status = 1 From SongImport, SongMedia SM Where SongImport.SongId = SM.SongMediaId and SM.TypeId = '1' and SessionId = '" + Session.SessionID + "' and SongImport.ImportType = '" + importType + "'");

                db.Close();
                ///////////
                Session["FolderPath"] = fileUpload.FileName;
                Response.Redirect("FullUpdateListMasterImport.aspx", false);
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

                string strHaishinFull = !(dt.Rows[i][4] is System.DBNull) ? (string)dt.Rows[i][4] : "";
                string strHaishinEndDateFull = !(dt.Rows[i][5] is System.DBNull) ? (string)dt.Rows[i][5] : "";

                string strIVT = !(dt.Rows[i][6] is System.DBNull) ? (string)dt.Rows[i][6] : "";
                string strPriceFull = !(dt.Rows[i][7] is System.DBNull) ? (string)dt.Rows[i][7] : "";
                string strISRC番号 = !(dt.Rows[i][8] is System.DBNull) ? (string)dt.Rows[i][8] : "";
                string strPOINT1 = !(dt.Rows[i][9] is System.DBNull) ? (string)dt.Rows[i][9] : "";
                string strSabi1 = !(dt.Rows[i][10] is System.DBNull) ? (string)dt.Rows[i][10] : "";
                string strSabi1end = !(dt.Rows[i][11] is System.DBNull) ? (string)dt.Rows[i][11] : "";
                string strPOINT2 = !(dt.Rows[i][12] is System.DBNull) ? (string)dt.Rows[i][12] : "";
                string strSabi2 = !(dt.Rows[i][13] is System.DBNull) ? (string)dt.Rows[i][13] : "";
                string strSabi2end = !(dt.Rows[i][14] is System.DBNull) ? (string)dt.Rows[i][14] : "";
                string strPOINT3 = !(dt.Rows[i][15] is System.DBNull) ? (string)dt.Rows[i][15] : "";
                string strSabi3 = !(dt.Rows[i][16] is System.DBNull) ? (string)dt.Rows[i][16] : "";
                string strSabi3end = !(dt.Rows[i][17] is System.DBNull) ? (string)dt.Rows[i][17] : "";
                string strFlag = !(dt.Rows[i][18] is System.DBNull) ? (string)dt.Rows[i][18] : "";
                string strFileName = !(dt.Rows[i][19] is System.DBNull) ? (string)dt.Rows[i][19] : "";
                /*
                if ("".Equals(strWID))
                {
                    message += "【" + Constants.ImportFullDataHeader[0] + "】" + Func.invalidNull();
                }
                else if (strWID.Length > 8)
                {
                    message += "【" + Constants.ImportFullDataHeader[0] + "】" + Func.invalidLenght(8);
                }

                if (!"".Equals(strHaishinFull) && !Func.IsDate(strHaishinFull))
                {
                    message += "【" + Constants.ImportFullDataHeader[3] + "】" + Func.invalidDate();
                }

                if (!"".Equals(strIVT) && strIVT.Length > 1)
                {
                    message += "【" + Constants.ImportDataHeader[5] + "】" + Func.invalidLenght(1);
                }

                if (!"".Equals(strPriceFull) && !Func.IsInterger(strPriceFull))
                {
                    message += "【" + Constants.ImportFullDataHeader[6] + "】" + Func.invalidNumber();
                }

                if (!"".Equals(strISRC番号) && strISRC番号.Length > 50)
                {
                    message += "【" + Constants.ImportFullDataHeader[7] + "】" + Func.invalidLenght(6);
                }

                if (!"".Equals(strPOINT1) && strPOINT1.Length > 50)
                {
                    message += "【" + Constants.ImportFullDataHeader[8] + "】" + Func.invalidLenght(50);
                }

                if (!"".Equals(strSabi1) && strSabi1.Length > 7)
                {
                    message += "【" + Constants.ImportFullDataHeader[9] + "】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strSabi1end) && strSabi1end.Length > 7)
                {
                    message += "【" + Constants.ImportFullDataHeader[10] + "】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strPOINT2) && strPOINT2.Length > 50)
                {
                    message += "【" + Constants.ImportFullDataHeader[11] + "】" + Func.invalidLenght(50);
                }

                if (!"".Equals(strSabi2) && strSabi2.Length > 7)
                {
                    message += "【" + Constants.ImportFullDataHeader[12] + "】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strSabi2end) && strSabi2end.Length > 7)
                {
                    message += "【" + Constants.ImportFullDataHeader[13] + "】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strPOINT3) && strPOINT3.Length > 50)
                {
                    message += "【" + Constants.ImportFullDataHeader[14] + "】" + Func.invalidLenght(50);
                }
                if (!"".Equals(strSabi3) && strSabi3.Length > 7)
                {
                    message += "【" + Constants.ImportFullDataHeader[15] + "】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strSabi3end) && strSabi3end.Length > 7)
                {
                    message += "【" + Constants.ImportFullDataHeader[16] + "】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strFlag) && !"1".Equals(strFlag) && !"0".Equals(strFlag))
                {
                    message += "【" + Constants.ImportFullDataHeader[17] + "】がTrue:1 False:0又はブランク";
                }
                */
                if (!"".Equals(strFileName) && strFileName.Length > 200)
                {
                    message += "【" + Constants.ImportFullDataHeader[18] + "】" + Func.invalidLenght(255);
                }





                if ("".Equals(strWID))
                {
                    message += "【WID】" + Func.invalidNull();
                }
                else if (strWID.Length > 8)
                {
                    message += "【WID】" + Func.invalidLenght(8);
                }

                /*
                if (!"".Equals(strAlphabetTitle) && strAlphabetTitle.Length > 200)
                {
                    message += "【曲名英表記】" + Func.invalidLenght(200);
                }
                */

                if (!"".Equals(strHaishinFull) && !Func.IsDate(strHaishinFull))
                {
                    message += "【解禁日（フル）】" + Func.invalidDate();
                }

                if (!"".Equals(strHaishinEndDateFull) && !Func.IsDate(strHaishinEndDateFull))
                {
                    message += "配信停止日" + Func.invalidDate();
                }


                if (!"".Equals(strPriceFull) && !Func.IsInterger(strPriceFull))
                {
                    message += "【価格】" + Func.invalidNumber();
                }

                if (!"".Equals(strIVT) && strIVT.Length > 1)
                {
                    message += "【歌詞区分】" + Func.invalidLenght(1);
                }

                if (!"".Equals(strISRC番号) && strISRC番号.Length > 50)
                {
                    message += "【ISRC番号】" + Func.invalidLenght(50);
                }

                if (!"".Equals(strPOINT1) && strPOINT1.Length > 50)
                {
                    message += "【切り出し表記1】" + Func.invalidLenght(50);
                }
                /*
                if (!"".Equals(strSabi1) && strSabi1.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[43] + "】" + invalidEqual(7);
                }
                if (!"".Equals(strSabi1end) && strSabi1end.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[44] + "】" + invalidEqual(7);
                }
                */
                if (!"".Equals(strSabi1) && strSabi1.Length > 7)
                {
                    message += "【cut開始1】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strSabi1end) && strSabi1end.Length > 7)
                {
                    message += "【cut終了1】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strPOINT2) && strPOINT2.Length > 50)
                {
                    message += "【切り出し表記2】" + Func.invalidLenght(50);
                }
                /*
                if (!"".Equals(strSabi2) && strSabi2.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[46] + "】" + invalidEqual(7);
                }
                if (!"".Equals(strSabi2end) && strSabi2end.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[47] + "】" + invalidEqual(7);
                }
                */
                if (!"".Equals(strSabi2) && strSabi2.Length > 7)
                {
                    message += "【cut開始2】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strSabi2end) && strSabi2end.Length > 7)
                {
                    message += "【cut終了2】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strPOINT3) && strPOINT3.Length > 50)
                {
                    message += "【切り出し表記3】" + Func.invalidLenght(50);
                }
                /*
                if (!"".Equals(strSabi3) && strSabi3.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[49] + "】" + invalidEqual(7);
                }
                if (!"".Equals(strSabi3end) && strSabi3end.Length != 7)
                {
                    message += "【" + Constants.ImportDataHeader[50] + "】" + invalidEqual(7);
                }
                */
                if (!"".Equals(strSabi3) && strSabi3.Length > 7)
                {
                    message += "【cut開始3】" + Func.invalidLenght(7);
                }
                if (!"".Equals(strSabi3end) && strSabi3end.Length > 7)
                {
                    message += "【cut終了3】" + Func.invalidLenght(7);
                }

                if (!"".Equals(strFlag) && strFlag.Length != 1)
                {
                    message += "【fineflag】" + Func.invalidEqual(1);
                }

                if (!"".Equals(strFlag) && !"1".Equals(strFlag) && !"0".Equals(strFlag))
                {
                    message += "【fineflag】がTrue:1 False:0又はブランク";
                }

                if (!"".Equals(message))
                {
                    valid = false;
                    mvImportMaster.AddError("Error (Line)" + (i + 2) + ": " + message);
                }
            }
            return valid;
        }
    }
}
