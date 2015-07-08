using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Gnt.Utils.FastCsv;
using System.Collections;
using System.Data.SqlClient;
using System.ComponentModel;
using Gnt.Data;
using Man.Utils;

namespace Man.MasterImport
{
    public partial class ErrorDemandData : PageBase
    {
        private string copyrightContractRate = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        protected SortDirection ListSortDirection
        {
            get
            {
                object o = ViewState["SortDirection"];
                if (o == null)
                {
                    return SortDirection.Descending;
                }
                return (SortDirection)o;
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected string ListSortExpression
        {
            get
            {
                object o = ViewState["SortExpression"];
                if (o == null)
                {
                    return "";
                }
                return o.ToString();
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }

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
        private void InitErrorDemandDataListTable()
        {
            DbHelper.FillList(drpSite, "select distinct SeviceCode, SeviceName from ErrorDemandData", "SeviceName", "SeviceCode");
            //drpSite.Items.Add(new ListItem("サイトを選んでください", "0"));

            // QDo start 110131
            drpSite.Items.Add(new ListItem("", "0"));
            // QDo end 110131

            Func.SortByValue(drpSite);
            drpSite.Items[0].Selected = true;
            
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitErrorDemandDataListTable();
            }
        }

        /// <summary>
        /// Upload 
        /// </summary>
        /// <param name="fileUploadControl"></param>        
        private void DoUpload(FileUpload fileUploadControl, string path)
        {

            if (fileUploadControl.HasFile)
            {
                string fileName = string.Empty;
                try
                {
                    fileName = Path.GetFileName(fileUploadControl.FileName);
                    if (fileUploadControl.PostedFile.ContentLength > 80000000)
                    {
                        mvImportMaster.AddError("添付ファイルのサイズ制限" + Func.FormatNumber(80000000) + "KB を超えています。");
                    }
                    if (!mvImportMaster.IsValid)
                    {
                        return;
                    }

                    if (Func.IsZipFile(fileName))
                    {
                        path = Path.Combine(path, "Zip");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }
                    string fullFileName = Path.Combine(path, fileName);
                    fileUploadControl.SaveAs(fullFileName);

                }
                catch (Exception ex)
                {
                    mvImportMaster.AddError("エラーが発生しました(" + fileName + ")");
                }
            }
        }
        private void DoUnzip(string path)
        {
            string zipPath = Path.Combine(path, "Zip");
            if (!Directory.Exists(zipPath))
            {
                return;
            }
            string[] files = Directory.GetFiles(zipPath);
            for (int i = 0; i < files.Length; i++)
            {
                string file = Path.Combine(zipPath, files[i]);
                Unzip(file, path);
                //ICSharpCode.SharpZipLib.Zip.FastZip fz = new ICSharpCode.SharpZipLib.Zip.FastZip();
                //fz.ExtractZip(file, path, "");
            }
        }
        private void Unzip(string file, string targetPath)
        {
            try
            {

                if (!File.Exists(file))
                {
                    return;
                }

                using (ZipInputStream s = new ZipInputStream(File.OpenRead(file)))
                {

                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string fileName = Path.GetFileName(theEntry.Name);

                        string targetFileName = Path.Combine(targetPath, fileName);
                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(targetFileName))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                //Display Error
            }
            finally
            {
                //Update Status
            }
        }
        /// <summary>
        /// Init file list table
        /// </summary>
        private void InitFileListTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FileName", typeof(String)));
            dt.Columns.Add(new DataColumn("Size", typeof(String)));
            FileListTable = dt;
        }
        /// <summary>
        /// Add uploaded file
        /// </summary>
        /// <param name="fullFileName"></param>
        private void AddFile(string fullFileName)
        {
            FileInfo fileInfo = new FileInfo(fullFileName);
            string fileExtension = fileInfo.Extension;
            fileExtension = fileExtension.Substring(1, fileExtension.Length - 1);
            DataRow row = FileListTable.NewRow();
            row["FileName"] = fileInfo.Name;
            row["Size"] = fileInfo.Length;
            FileListTable.Rows.Add(row);

        }

        /// <summary>
        /// Load file from hard disk to list
        /// </summary>
        /// <param name="deskDir"></param>
        private void LoadFiles(string deskDir)
        {
            string[] files = { };
            int i = 0;
            FileListTable.Rows.Clear();
            if (Directory.Exists(deskDir))
            {
                files = Directory.GetFiles(deskDir);
                if (files.Length > 0)
                {
                    for (i = 0; i < files.Length; i++)
                    {
                        AddFile(files[i]);
                    }
                }
            }
        }

        private DataTable GetCopyrightContract()
        {
            DataTable retTable = null;
            string sql = string.Empty;
            sql += " SELECT *";
            sql += " FROM CopyrightContract";
            sql += " WHERE (CopyrightContractId IS NOT NULL) ";
            try
            {
                retTable = DbHelper.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
            return retTable;
        }

        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            //string importType = string.Empty;

            if (!fileUploadFile.HasFile)
            {
                mvImportMaster.AddError("ファイルを見つかりません・・・");
                return;
            }
            CsvReader csvRead = null;

            try
            {
                // unzip file and upload 
                string importDate = Server.MapPath("./") + "TempImport/" + DateTime.Now.ToString("yyyyMMddHHmmss"); 
                if (!Directory.Exists(importDate))
                {
                    Directory.CreateDirectory(importDate);    
                }
                DoUpload(fileUploadFile, importDate);
                DoUnzip(importDate);
                InitFileListTable();
                LoadFiles(importDate);

                string[] dataHeader = null;
                string[] dbRef = null;
                string ImportTableTemp = "ErrorDemandDataTempt";
                    // importType = "SY0002";

                    // For Each File
                    foreach (DataRow fileNameRow in FileListTable.Rows)
                    {
                        string FileName = fileNameRow["FileName"].ToString();
                        string FileSize = fileNameRow["Size"].ToString();
                        string[] array = FileName.Split('.');
                        string ext = string.Empty;
                        if (array.Length > 0)
                        {
                            ext = array[array.Length - 1];
                        }
                        if (ext.Length == 0) return;
                        ext = ext.ToUpper();
                        if (!"csv".Equals(ext.ToLower()))
                        {
                            mvImportMaster.AddError("TXTファイルを選択してください・・・");
                            return;
                        }
                    }
                    dataHeader = Constants.ErrorDemandDataHeader;
                    dbRef = Constants.ErrorDemandDataDbRef;
                 
                string sql = "DELETE FROM " + ImportTableTemp + " WHERE SessionId='" + Session.SessionID + "'";
                DbHelper.ExecuteNonQuery(sql);

                // For Each File
                foreach (DataRow fileNameRow in FileListTable.Rows)
                {
                    string FileName = fileNameRow["FileName"].ToString();
                    string FileSize = fileNameRow["Size"].ToString();
                    string[] array = FileName.Split('.');
                    csvRead = new CsvReader(importDate + "/" + FileName, true, ',');

                    DataTable dt = new DataTable();
                    DataTable dtTmp = new DataTable();
                    dt.Load(csvRead);


                    string[] header = null;
                    header = csvRead.GetFieldHeaders();
                    // Binh

                    //if (!validFormat(dt))
                    //{
                    //    return;
                    //}
                    DataTable dtCopyrightContract = GetCopyrightContract();

                    string sqlConsent = " SELECT C.ConsentId as KeyConsent, S.TypeId as ValueConsent " +
                                      " FROM Consent C, Site S  " +
                                      " WHERE " +
                                      " C.SiteId = S.Id and S.Id <> 0";
                    DataTable dtConsent = DbHelper.GetMstrData(sqlConsent).Tables[0];

                    Hashtable hashConsent = new Hashtable();

                    foreach (DataRow row in dtConsent.Rows)
                    {
                        hashConsent.Add(row["KeyConsent"].ToString(), row["ValueConsent"].ToString());
                    }

                    if (dt.Rows.Count > 0)
                    {

                        //フォーマットﾁｪｯｸ
                        for (int i = 0; i < dataHeader.Length; i++)
                        {
                            if (!dataHeader[i].ToUpper().Equals(header[i].ToUpper()))
                            {
                                mvImportMaster.AddError("ファイルのヘッダー部分が間違っています・・・");
                                return;
                            }
                        }
                        dt.Columns.Add("SessionId", Type.GetType("System.String"));
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
                            copy.DestinationTableName = ImportTableTemp;
                            copy.BatchSize = 3000;
                            copy.BulkCopyTimeout = 99999;
                            for (int i = 0; i < dataHeader.Length; i++)
                            {
                                copy.ColumnMappings.Add(i, dbRef[i]);
                            }
                            copy.ColumnMappings.Add(dt.Columns.Count - 6, "SessionId");
                            copy.ColumnMappings.Add(dt.Columns.Count - 5, "DelFlag");
                            copy.ColumnMappings.Add(dt.Columns.Count - 4, "Updated");
                            copy.ColumnMappings.Add(dt.Columns.Count - 3, "Updator");
                            copy.ColumnMappings.Add(dt.Columns.Count - 2, "Created");
                            copy.ColumnMappings.Add(dt.Columns.Count - 1, "Creator");
                            copy.WriteToServer(dt);
                        }
                    }
                }
                Session["FolderPath"] = fileUploadFile.FileName;
                Response.Redirect("ListErrorDemandData.aspx", false);
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

        private bool validFormat(DataTable dt, string keyColumn)
        {
            Hashtable tmpKey = new Hashtable();
            string[] arrayKeyColumn = keyColumn.Split(',');
            string KeyValue;

            bool valid = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KeyValue = "";
                for (int j = 0; j < arrayKeyColumn.Length; j++)
                {
                    if (!(dt.Rows[i][int.Parse(arrayKeyColumn[j])] is System.DBNull))
                        KeyValue += dt.Rows[i][int.Parse(arrayKeyColumn[j])].ToString();
                    else
                    {
                        mvImportMaster.AddError("Key columns "+keyColumn+" are not empty ");
                        valid = false;
                        continue;
                    }
                }
                //string strID = !(dt.Rows[i][0] is System.DBNull) ? (string)dt.Rows[i][0] : "";
                string strID = !(KeyValue.Equals("")) ? (string)KeyValue : "";
                if (tmpKey.Contains(strID))
                {
                    mvImportMaster.AddError(strID + "が重複です。");
                    valid = false;
                    continue;
                }
                else
                {
                    tmpKey.Add(strID, strID);
                }
            }
            return valid;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private string GetWhere()
        {
            string whereClause = string.Empty;
            string errorDate = txtErrorDate.Text.Trim();
            

            if (!"".Equals(txtErrorDate.Text.Trim()))
            {
                DateTime dtDayError = new DateTime(int.Parse(errorDate.Substring(0, 4)), int.Parse(errorDate.Substring(4, 2)), 1);
                whereClause += " and CONVERT(datetime, ErrorDate, 101) between convert(datetime,'" + dtDayError.Year + "/" + dtDayError.Month + "/01',101)";
                whereClause += " and convert(datetime,'" + dtDayError.Year + "/" + dtDayError.Month + "/" + DateTime.DaysInMonth(dtDayError.Year,dtDayError.Month) + "',101)";
            }

            if (!drpSite.SelectedItem.Value.Equals("0"))
            {
                whereClause += " and SeviceCode = '"+ drpSite.SelectedItem.Value +"'";
            }
            return whereClause;
        }

        private void ShowData()
        {
            divResult.Visible = true;
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "SeviceCode";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {

                //件数を数える
                sql += " SELECT COUNT(MoneyTotalSumTotal) ";
                sql += " FROM VErrorDemandData ";
                //sql += " WHERE SessionId = '" + Session.SessionID + "'" + GetWhere();

                // QDo start 110131
                sql += " WHERE 1 = 1 " + GetWhere();

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT * ,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum";
                sql += " FROM VErrorDemandData ";
                //sql += " WHERE SessionId = '" + Session.SessionID + "'" + GetWhere();
                sql += " WHERE 1 = 1 " + GetWhere();
                // QDo end 110131

                //ページによるレコーダを取得する
                sql = " SELECT *,RowNum FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY TMP.RowNum ";

                //SQL文を実行する
                SqlCommand cm = db.CreateCommand(sql);
                cm.Parameters.AddWithValue("@PageIndex", pager.CurrentPageIndex);
                cm.Parameters.AddWithValue("@PageSize", pager.PageSize);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                db.Close();
                rptList.DataSource = ds.Tables[0].DefaultView;
                rptList.DataBind();
                pager.Count = count;

                // QDo start 110131
                string sqlSubTotal = string.Empty;
                sqlSubTotal += " SELECT SUM(MoneyTotalSumTotal) ";
                sqlSubTotal += " FROM VErrorDemandData ";
                sqlSubTotal += " WHERE 1 = 1 " + GetWhere();
                decimal ZeiNukiTotal = decimal.Parse(db.ExecuteScalar(sqlSubTotal).ToString());
                double ZeiKomiTotal = double.Parse(db.ExecuteScalar(sqlSubTotal).ToString()) * 1.05;
                lblZeiNukiTotal.Text = Math.Round(ZeiNukiTotal, 0).ToString();
                lblZeiKomiTotal.Text = Math.Round(ZeiKomiTotal, 0).ToString();
                // QDo end 110131
            }
            catch (Exception ex)
            {
                mvImportMaster.AddError(ex.Message.ToString());
                ApplicationLog.WriteError(ex);
            }
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortSite") == 0)
                {
                    colName = "SeviceCode";
                }
                else if (string.Compare(command, "SortPointTotal") == 0)
                {
                    colName = "MoneyTotalSumTotal";
                }
                else if (string.Compare(command, "SortErrorDate") == 0)
                {
                    colName = "ErrorDate";
                }
                
                if (colName == ListSortExpression)
                {
                    ListSortDirection = (ListSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
                }
                else
                {
                    ListSortDirection = SortDirection.Descending;
                }
                ListSortExpression = colName;
                pager.CurrentPageIndex = 0;
                ShowData();
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;
                    string SeviceCode = Func.ParseString(row["SeviceName"]);
                    string MoneyTotalSumTotal = Func.ParseString(row["MoneyTotalSumTotal"]);
                    string ErrorDate = Func.ParseString(row["ErrorDate"]);

                    Func.SetGridTextValue(item, "ltrSite", Func.ToolTipByteLen(SeviceCode, 40));
                    Func.SetGridTextValue(item, "ltrPointTotal", Math.Round(double.Parse(MoneyTotalSumTotal)).ToString());

                    Func.SetGridTextValue(item, "ltrPointZeiKomiTotal", Math.Round(double.Parse(MoneyTotalSumTotal)*1.05).ToString());
                    
                    Func.SetGridTextValue(item, "ltrErrorDate", ErrorDate.Substring(0,4)+"/"+ErrorDate.Substring(4,2)+"/"+ErrorDate.Substring(6,2));

                }
                else if (item.ItemType == ListItemType.Header)
                {
                    string colName = ListSortExpression;
                    if (Func.IsValid(colName))
                    {
                        string img = string.Empty;
                        if (ListSortDirection == SortDirection.Ascending)
                        {
                            img = "<img src=\"../App_Themes/Default/Images/ASCSymbol.gif\" border=\"0\">";
                        }
                        else
                        {
                            img = "<img src=\"../App_Themes/Default/Images/DSCSymbol.gif\" border=\"0\">";
                        }

                        if (colName.EndsWith("SeviceCode"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSite");
                            link.Text = "サイト名" + img;
                        }
                        if (colName.EndsWith("MoneyTotalSumTotal"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkPointTotal");
                            link.Text = "課金（税抜）" + img;
                        }
                        if (colName.EndsWith("ErrorDate"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkErrorDate");
                            link.Text = "請求エラー処理日" + img;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
    }
}
