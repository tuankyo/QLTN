﻿using System;
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
    public partial class NewChakuKaraFullImport : Man.PageBase
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
                string sql = "DELETE FROM SongMediaKaraokeTmp WHERE SessionId='" + Session.SessionID + "'";
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
                    for (int i = 0; i < Constants.ImportNewKaraokeHeader.Length; i++)
                    {
                        if (!Constants.ImportNewKaraokeHeader[i].Equals(header[i]))
                        {
                            mvImportMaster.AddError("CSVファイルのヘッダー部分が間違っています・・・");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));
                    dt.Columns.Add("Status", Type.GetType("System.String"));
                    dt.Columns.Add("DelFlag", Type.GetType("System.String"));
                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));

                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["DelFlag"] = "0";
                        dt.Rows[i]["Status"] = "0";
                        dt.Rows[i]["Updated"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "SongMediaKaraokeTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportNewKaraokeHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportNewKaraokeDbRef[i]);
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
                //SongId 存在する
                DbHelper.ExecuteNonQuery("Update SongMediaKaraokeTmp set Status = 1,ArtistId = S.ArtistId,GenreId = S.GenreId, AlbumId = S.AlbumId, PRText = S.PRText, CopyrightOrg = S.CopyrightOrg , JasracWorksCode=S.JasracWorksCode ,LabelId=S.LabelId, MusicStyleId = S.MusicStyleId, ContractorId = S.ContractorId  From SongMediaKaraokeTmp, Song S Where SongMediaKaraokeTmp.SongId = S.SongId and SessionId = '" + Session.SessionID + "' ");
                //率を更新
                DbHelper.ExecuteNonQuery("Update SongMediaKaraokeTmp set Rate = C.karaoke_rate From SongMediaKaraokeTmp, Contractor C where SongMediaKaraokeTmp.ContractorId = C.ContractorId and SessionId = '" + Session.SessionID + "' ");

                sql = "SELECT * FROM SongMediaKaraokeTmp WHERE SessionId = '" + Session.SessionID + "' ";
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
                    string rate = row["rate"].ToString();
                    string price = row["Price"].ToString();
                    string priceNoTax = "";
                    string buyUnique = "";
                    string copyrightFeeUnique = "";
                    string KDDICommissionUnique = "";
                    string profitUnique = "";
                    string songMediaId = row["SongMediaId"].ToString();

                    if (!"".Equals(price) && !"".Equals(rate))
                    {
                        priceNoTax = Func.GetPriceNoTax(price);
                        buyUnique = Func.GetBuyUnique(priceNoTax, rate);
                        copyrightFeeUnique = Func.GetCopyrightFeeUnique(row["CopyrightContractId"].ToString(), priceNoTax, "4");
                        KDDICommissionUnique = Func.GetKDDICommissionUnique(priceNoTax);
                        profitUnique = Func.GetProfitUnique(priceNoTax, buyUnique, copyrightFeeUnique, KDDICommissionUnique);
                    }

                    string songId = row["SongId"].ToString();
                    sqlUpdate.Add("Update SongMediaKaraokeTmp set PriceNoTax = '" + priceNoTax + "', BuyUnique = '" + buyUnique + "', CopyrightFeeUnique = '" + copyrightFeeUnique + "', KDDICommissionUnique = '" + KDDICommissionUnique + "', ProfitUnique = '" + profitUnique + "'where SongMediaId = '" + songMediaId + "' and SessionId = '" + Session.SessionID + "'");
                }

                for (int i = 0; i < sqlUpdate.Count; i++)
                {
                    DbHelper.ExecuteNonQuery((string)sqlUpdate[i]);
                }

                //RBT既存　=>　status=1
                DbHelper.ExecuteNonQuery("Update SongMediaKaraokeTmp set Status = 2 From SongMediaKaraokeTmp, SongMedia SM Where SongMediaKaraokeTmp.SongMediaid = SM.SongMediaId and SM.TypeId= '4' and SessionId = '" + Session.SessionID + "' ");

                db.Close();
                ///////////
                Session["FolderPath"] = fileUpload.FileName;
                Response.Redirect("NewListChakuKaraFullImport.aspx", false);
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
            bool valid = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string message = "";
                string strWID = !(dt.Rows[i][0] is System.DBNull) ? (string)dt.Rows[i][0] : "";
                string strFID = !(dt.Rows[i][1] is System.DBNull) ? (string)dt.Rows[i][1] : "";
                string strTitle = !(dt.Rows[i][2] is System.DBNull) ? (string)dt.Rows[i][2] : "";
                string strPrice = !(dt.Rows[i][3] is System.DBNull) ? (string)dt.Rows[i][3] : "";
                string strHaishin = !(dt.Rows[i][4] is System.DBNull) ? (string)dt.Rows[i][4] : "";
                string strHaishinEnd = !(dt.Rows[i][5] is System.DBNull) ? (string)dt.Rows[i][5] : "";
                string strISRC番号 = !(dt.Rows[i][6] is System.DBNull) ? (string)dt.Rows[i][6] : "";
                string strLinkSongId = !(dt.Rows[i][7] is System.DBNull) ? (string)dt.Rows[i][7] : "";

                if (strWID.IndexOf("C-") != 0)
                {
                    message += "【WID】先頭の文字列が「C-」です。" + Func.invalidNull();
                }

                if ("".Equals(strWID))
                {
                    message += "【WID】" + Func.invalidNull();
                }
                else if (strWID.Length > 9)
                {
                    message += "【WID】" + Func.invalidLenght(9);
                }

                if ("".Equals(strFID))
                {
                    message += "【FID】" + Func.invalidNull();
                }
                else if (strFID.Length > 8)
                {
                    message += "【FID】" + Func.invalidLenght(8);
                }

                if ("".Equals(strTitle))
                {
                    message += "【Title】" + Func.invalidNull();
                }
                else if (strTitle.Length > 255)
                {
                    message += "【Title】" + Func.invalidLenght(255);
                }

                if (!"".Equals(strPrice) && !Func.IsInterger(strPrice))
                {
                    message += "【Price】" + Func.invalidNumber();
                }

                if (!"".Equals(strHaishin) && !Func.IsDate(strHaishin))
                {
                    message += "【Price】" + Func.invalidDate();
                }

                if (!"".Equals(strHaishinEnd) && !Func.IsDate(strHaishinEnd))
                {
                    message += "【UPDATE】" + Func.invalidDate();
                }

                
                if (!"".Equals(strISRC番号) && strISRC番号.Length > 50)
                {
                    message += "【ISRC番号】" + Func.invalidLenght(50);
                }

                if (!String.IsNullOrEmpty(strLinkSongId) && strLinkSongId.Length > 9)
                {
                    message += "【紐付けWID】" + Func.invalidLenght(9);
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