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
    public partial class RbtDownloadImport : Man.PageBase
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
            string sql = "";
            sql = "SELECT CarrierId,Name FROM Carrier";
            DbHelper.FillListSearch(drpCarrier, sql, "Name", "CarrierId");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitFileListTable();
            }
        }

        protected void AuUpload()
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

                csvRead = new CsvReader(Server.MapPath("./") + fileUpload.FileName, true, '\t');
                csvRead.IsCheckQuote = true;
                string sql = "DELETE FROM RbtDownloadImportAuTmp WHERE SessionId='" + Session.SessionID + "'";
                DbHelper.ExecuteNonQuery(sql);

                DataTable dt = new DataTable();
                DataTable dtTmp = new DataTable();
                dt.Load(csvRead);

                string[] header = csvRead.GetFieldHeaders();
                //string[] header = temp[0].Split("\t"):

                if (dt.Rows.Count > 0)
                {
                    //フォーマットﾁｪｯｸ
                    for (int i = 0; i < Constants.ImportRbtDownloadAuHeader.Length; i++)
                    {
                        if (!Constants.ImportRbtDownloadAuHeader[i].Equals(header[i]))
                        {
                            mvImportMaster.AddError("CSVファイルのヘッダー部分が間違っています・・・");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));

                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["Updated"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "RbtDownloadImportAuTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportRbtDownloadAuHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportRbtDownloadAuDbRef[i]);
                        }

                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "SessionId");

                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Updated");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");

                        copy.WriteToServer(dt);
                    }
                }

                Session["FolderPath"] = fileUpload.FileName;
                Response.Redirect("ListRbtDownloadImportAu.aspx", false);
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

        protected void DocomoUpload()
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
                string sql = "DELETE FROM RbtDownloadImportTmp WHERE SessionId='" + Session.SessionID + "'";
                DbHelper.ExecuteNonQuery(sql);

                DataTable dt = new DataTable();
                DataTable dtTmp = new DataTable();
                dt.Load(csvRead);


                string[] header = csvRead.GetFieldHeaders();

                /*                if (!validFormat(dt))
                                {
                                    return;
                                }
                                */


                if (dt.Rows.Count > 0)
                {

                    //フォーマットﾁｪｯｸ
                    for (int i = 0; i < Constants.ImportRbtDownloadHeader.Length; i++)
                    {
                        if (!Constants.ImportRbtDownloadHeader[i].Equals(header[i]))
                        {
                            mvImportMaster.AddError("CSVファイルのヘッダー部分が間違っています・・・");
                            return;
                        }
                    }

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));

                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["Updated"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "RbtDownloadImportTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportRbtDownloadHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportRbtDownloadDbRef[i]);
                        }

                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "SessionId");

                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Updated");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");

                        copy.WriteToServer(dt);
                    }
                }

                ///////////
                Session["FolderPath"] = fileUpload.FileName;
                Response.Redirect("ListRbtDownloadImport.aspx", false);
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

        protected void SoftbankUpload()
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

                csvRead = new CsvReader(Server.MapPath("./") + fileUpload.FileName, false, ',');
                csvRead.IsCheckQuote = true;
                string sql = "DELETE FROM RbtDownloadImportSbTmp WHERE SessionId='" + Session.SessionID + "'";
                DbHelper.ExecuteNonQuery(sql);

                DataTable dt = new DataTable();
                dt.Load(csvRead);

                if (dt.Rows.Count > 0)
                {

                    dt.Columns.Add("SessionId", Type.GetType("System.String"));

                    dt.Columns.Add("Updated", Type.GetType("System.String"));
                    dt.Columns.Add("Updator", Type.GetType("System.String"));
                    dt.Columns.Add("Created", Type.GetType("System.String"));
                    dt.Columns.Add("Creator", Type.GetType("System.String"));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SessionId"] = Session.SessionID;
                        dt.Rows[i]["Updated"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Updator"] = Page.User.Identity.Name;
                        dt.Rows[i]["Created"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                        dt.Rows[i]["Creator"] = Page.User.Identity.Name;
                    }

                    using (SqlBulkCopy copy = new SqlBulkCopy(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                    {
                        copy.DestinationTableName = "RbtDownloadImportSbTmp";
                        copy.BatchSize = 3000;
                        copy.BulkCopyTimeout = 99999;
                        for (int i = 0; i < Constants.ImportRbtDownloadSbHeader.Length; i++)
                        {
                            copy.ColumnMappings.Add(i, Constants.ImportRbtDownloadSbDbRef[i]);
                        }

                        copy.ColumnMappings.Add(dt.Columns.Count - 5, "SessionId");

                        copy.ColumnMappings.Add(dt.Columns.Count - 4, "Updated");
                        copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                        copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                        copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");

                        copy.WriteToServer(dt);
                    }
                }

                Session["FolderPath"] = fileUpload.FileName;
                Response.Redirect("ListRbtDownloadImportSb.aspx", false);
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string carrier = string.Empty;
            if (drpCarrier.SelectedValue.Trim().Length != 0)
            {
                carrier = drpCarrier.SelectedValue;
            }
            if (carrier.Equals("0"))
            {
                DocomoUpload();
            }
            else if (carrier.Equals("2"))
            {
                AuUpload();
            }
            else if (carrier.Equals("1"))
            {
                SoftbankUpload();
            }
            else
            {
                mvImportMaster.AddError("キャリアは選択されていません！");
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

                if ("".Equals(strWID))
                {
                    message += "【" + Constants.ImportNewRbtHeader[0] + "】" + Func.invalidNull();
                }
                else if (strWID.Length > 9)
                {
                    message += "【" + Constants.ImportNewRbtHeader[0] + "】" + Func.invalidLenght(9);
                }

                if ("".Equals(strFID))
                {
                    message += "【" + Constants.ImportNewRbtHeader[1] + "】" + Func.invalidNull();
                }
                else if (strFID.Length > 8)
                {
                    message += "【" + Constants.ImportNewRbtHeader[1] + "】" + Func.invalidLenght(8);
                }

                if ("".Equals(strTitle))
                {
                    message += "【" + Constants.ImportNewRbtHeader[2] + "】" + Func.invalidNull();
                }
                else if (strTitle.Length > 255)
                {
                    message += "【" + Constants.ImportNewRbtHeader[2] + "】" + Func.invalidLenght(255);
                }

                if (!"".Equals(strPrice) && !Func.IsInterger(strPrice))
                {
                    message += "【" + Constants.ImportNewRbtHeader[3] + "】" + Func.invalidNumber();
                }

                if (!"".Equals(strHaishin) && !Func.IsDate(strHaishin))
                {
                    message += "【" + Constants.ImportNewRbtHeader[4] + "】" + Func.invalidDate();
                }

                if (!"".Equals(strHaishinEnd) && !Func.IsDate(strHaishinEnd))
                {
                    message += "【" + Constants.ImportNewRbtHeader[5] + "】" + Func.invalidDate();
                }

                

                if (!"".Equals(strISRC番号) && strISRC番号.Length > 50)
                {
                    message += "【" + Constants.ImportNewRbtHeader[6] + "】" + Func.invalidLenght(50);
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
