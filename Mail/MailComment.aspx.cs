using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Gnt.Data;
using Man.Utils;
using Gnt.Data.DBCommand;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using System.Text;
using Gnt.Utils.FastCsv;
using C1.C1Excel;
using System.IO;
using System.Drawing;
using System.Net;

namespace Man.Mail
{
    public partial class MailComment : PageBase
    {
        //private const int PopupWidth = 850;
        //private const int PopupHeight = 550;

        public string[,] resultSync = new string[20, 3];
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

        /// <summary>
        /// Load data
        /// </summary>
        private void LoadMail(string id)
        {
            MessagesData data = new MessagesData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (MessagesData)tran.Result;
                lblCC.Text = data.UserName;
                lblSubject.Text = data.Subject;
                ltrBody.Text = data.Body;
            }
            string sql = "Select A.* from UploadedFile A, UploadedFileMessageMap B Where A.UploadFileId = B.UploadFileId and B.MessageID = '" + id + "'";
            SqlDatabase db = new SqlDatabase();

            SqlCommand cm = db.CreateCommand(sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            db.Close();
            rptAttach.DataSource = ds.Tables[0].DefaultView;
            rptAttach.DataBind();

            //DataTable dt = new DataTable();

            //dt = DbHelper.GetDataTable(sql);

            //lnkFile1.Text = "";
            //lnkFile2.Text = "";
            //lnkFile3.Text = "";
            //lnkFile4.Text = "";

            //lnkFile1.CommandArgument = "";
            //lnkFile2.CommandArgument = "";
            //lnkFile3.CommandArgument = "";
            //lnkFile4.CommandArgument = "";

            //int i = 1;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string fileName = dr["fileName"].ToString();
            //    string pathName = dr["pathFile"].ToString();
            //    string orgFileName = dr["OrgFileName"].ToString();


            //    switch (i)
            //    {
            //        case 1:
            //            lnkFile1.Text = orgFileName;
            //            lnkFile1.CommandArgument = fileName;
            //            btnFile1.CommandArgument = fileName;
            //            btnFile1.Visible = true;
            //            break;
            //        case 2:
            //            lnkFile2.Text = orgFileName;
            //            lnkFile2.CommandArgument = fileName;
            //            btnFile2.CommandArgument = fileName;
            //            btnFile2.Visible = true;
            //            break;
            //        case 3:
            //            lnkFile3.Text = orgFileName;
            //            lnkFile3.CommandArgument = fileName;
            //            btnFile3.CommandArgument = fileName;
            //            btnFile3.Visible = true;
            //            break;
            //        case 4:
            //            lnkFile4.Text = orgFileName;
            //            lnkFile4.CommandArgument = fileName;
            //            btnFile4.CommandArgument = fileName;
            //            btnFile4.Visible = true;
            //            break;
            //        case 5:
            //            lnkFile5.Text = orgFileName;
            //            lnkFile5.CommandArgument = fileName;
            //            btnFile5.CommandArgument = fileName;
            //            btnFile5.Visible = true;
            //            break;

            //    }
            //    i++;
            //}
        }
        protected void rptAttach_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;

                    string fileName = Func.ParseString(row["fileName"]);
                    string pathName = Func.ParseString(row["pathFile"]);
                    string orgFileName = Func.ParseString(row["OrgFileName"]);

                    Func.SetGridLinkValue(item, "lnkFile", Func.ToolTipByteLen(orgFileName, 150));

                    LinkButton lbt = (LinkButton)item.FindControl("lnkFile");
                    lbt.CommandArgument = fileName;

                    ImageButton bt = (ImageButton)item.FindControl("btnFile");
                    bt.CommandArgument = fileName;
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!mvMessage.IsValid)
                return;


            if ((File.PostedFile != null) && (File.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File.PostedFile.FileName);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + fn;
                string SaveLocation = Server.MapPath("Mail") + "\\File\\" + filename;
                try
                {

                    File.PostedFile.SaveAs(SaveLocation);

                    UploadedFileData data = new UploadedFileData();
                    ITransaction tran = factory.GetInsertObject(data);
                    data.OrgFileName = fn;
                    data.FileName = filename;
                    data.PathFile = SaveLocation;
                    data.ModifiedBy = Page.User.Identity.Name;
                    data.CreatedBy = Page.User.Identity.Name;
                    data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                    data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                    Execute(tran);

                    if (!HasError)
                    {
                        ////////////////////
                        UploadedFileMessageMapData dataM = new UploadedFileMessageMapData();
                        ITransaction tranM = factory.GetInsertObject(dataM);

                        dataM.UploadFileID = data.UploadFileId;
                        dataM.MessageID = hidMessageId.Value;

                        Execute(tranM);

                        if (!HasError)
                        {

                            mvMessage.SetCompleteMessage("Thực Hiện Thành Công");


                        }
                        else
                        {
                            OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, "Tạo Mới Thông Tin Phát Sinh Lỗi", Page.User.Identity.Name);
                            mvMessage.AddError("Tạo Mới Thông Tin Phát Sinh Lỗi");
                        }
                        LoadMail(hidMessageId.Value);

                    }
                    else
                    {
                        mvMessage.AddError("Lỗi phát sinh");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);

                }
            }
        }
        protected void rptAttach_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.Equals("GetFile"))
            {
                string SaveLocation = "Mail\\Mail\\File\\" + e.CommandArgument;

                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + e.CommandArgument + "\"");
                byte[] data = req.DownloadData(Server.MapPath("Mail\\File\\" + e.CommandArgument));
                response.BinaryWrite(data);
                response.End();
            }
        }
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            divMail.Visible = true;
            divReadMail.Visible = false;

            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "A.Created";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                sql = " SELECT COUNT(*) ";
                sql += " FROM MessageComment A inner join Messages B ";
                sql += " on A.MessageID = B.MessageID Where A.UserName = '" + Page.User.Identity.Name + "' and B.DelFlag = 0 and B.UserName in (Select UserName From UsersMessagesMapped Where MessageId = '" + hidMessageId.Value + "') and B.MessageId = '" + hidMessageId.Value + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //検索条件で取得情報のSQL文を作成する
                sql = " SELECT A.*, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM MessageComment A inner join Messages B ";
                sql += " on A.MessageID = B.MessageID Where A.UserName = '" + Page.User.Identity.Name + "' and B.DelFlag = 0 and B.UserName in (Select UserName From UsersMessagesMapped Where MessageId = '" + hidMessageId.Value + "') and B.MessageId = '" + hidMessageId.Value + "'";

                sql = " SELECT * FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

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
                pager.CurrentPageIndex = pager.PageSize;

                //検索条件で取得情報のSQL文を作成する
                //sql = " Update MessageCommentReadFlg Set ReadFlag = 1 Where MessageCommentId in(";

                sql = " SELECT A.MessageCommentId, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM MessageComment A inner join Messages B ";
                sql += " on A.MessageID = B.MessageID Where A.UserName = '" + Page.User.Identity.Name + "' and B.DelFlag = 0 and B.UserName in (Select UserName From UsersMessagesMapped Where MessageId = '" + hidMessageId.Value + "') and B.MessageId = '" + hidMessageId.Value + "'";

                sql = " Update MessageCommentReadFlg Set ReadFlag = 1 Where MessageCommentId in( SELECT MessageCommentId FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize) ";
                sql += " and UserName = '" + Page.User.Identity.Name + "'";

                cm = new SqlCommand();
                cm = db.CreateCommand(sql);
                cm.Parameters.AddWithValue("@PageIndex", pager.CurrentPageIndex);
                cm.Parameters.AddWithValue("@PageSize", pager.PageSize);
                cm.ExecuteNonQuery();
                //SQL文を実行する
                ScriptManager.RegisterClientScriptBlock(this.divReadMail, this.GetType(), "PopUpComment", "window.opener.__doPostBack('PopUpComment','');", true);

                int checkId = DbHelper.GetCount("Select Count(*) from UsersMessagesMapped Where MessageId = '" + hidMessageId.Value + "' and UserName = '" + Page.User.Identity.Name + "'");
                if (checkId == 0)
                {
                    divMail.Visible = false;
                    divComment.Visible = false;
                    divReadMail.Visible = false;
                }
                else
                {
                    divMail.Visible = true;
                    divComment.Visible = true;
                    divReadMail.Visible = true;
                }

                if (count == 0)
                {
                    pager.Visible = false;
                }
                else
                {
                    pager.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }
        protected void btnFile_Click(object sender, CommandEventArgs e)
        {
            string SaveLocation = "Mail\\Mail\\File\\" + e.CommandArgument;

            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + e.CommandArgument + "\"");
            byte[] data = req.DownloadData(Server.MapPath("Mail\\File\\" + e.CommandArgument));
            response.BinaryWrite(data);
            response.End();
        }
        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            hidMessageId.Value = Func.ParseString(Request["id"]);
        }

        protected override void DoPost()
        {
            hidMessageId.Value = Func.ParseString(Request["id"]);

            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUp"))
            {
                if (eventTarget == "PopUpEditFlat")
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hidMessageId.Value = Func.ParseString(Request["id"]);

            if (!IsPostBack)
            {
                PopupWidth = 850;
                PopupHeight = 450;
                PopupName = "EditFlat";
                ShowData();
                LoadMail(hidMessageId.Value);

            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtBody, "Cần nhập nội dung");
            if (!mvMessage.IsValid) return;

            MessageCommentData dataM = new MessageCommentData();
            ITransaction tranM = factory.GetInsertObject(dataM);

            dataM.Body = txtBody.Text;
            dataM.UserName = Page.User.Identity.Name;
            dataM.DelFlag = "0";
            dataM.MessageID = hidMessageId.Value;

            dataM.Updator = Page.User.Identity.Name;
            dataM.Creator = Page.User.Identity.Name;
            dataM.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            dataM.Updated = DateTime.Now.ToString("yyyyMMddHHmmss");

            Execute(tranM);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, "Tạo Mới Thông Tin Thành Công", Page.User.Identity.Name);
                txtBody.Text = "";
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, "Tạo Mới Thông Tin Phát Sinh Lỗi", Page.User.Identity.Name);
                mvMessage.AddError("Tạo Mới Thông Tin Phát Sinh Lỗi");
            }
            ShowData();
        }

        /// <summary>
        /// ページ押下処理

        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();

        }
        /// <summary>
        /// グリッドにボタン押下処理

        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortFlag") == 0)
                {
                    colName = "C.Flag";
                }
                else if (string.Compare(command, "SortRead") == 0)
                {
                    colName = "A.isRead";
                }
                else if (string.Compare(command, "SortSubject") == 0)
                {
                    colName = "B.Subject";
                }
                else if (string.Compare(command, "SortUserName") == 0)
                {
                    colName = "B.UserName";
                }
                else if (string.Compare(command, "SortCreated") == 0)
                {
                    colName = "A.Created";
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
        protected void imgFile_Click(object sender, EventArgs e)
        {
            string SaveLocation = "Mail\\Mail\\File\\" + ((ImageButton)sender).CommandArgument;

            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + ((ImageButton)sender).CommandArgument + "\"");
            byte[] data = req.DownloadData(Server.MapPath("Mail\\File\\" + ((ImageButton)sender).CommandArgument));
            response.BinaryWrite(data);
            response.End();
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        /// <summary>
        /// グリッドのコンテンツを設定する処理

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            try
            {
                if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                {
                    DataRowView row = (DataRowView)item.DataItem;
                    string Sender = Func.ParseString(row["UserName"]);
                    string Body = Func.ParseString(row["Body"]);
                    string id = Func.ParseString(row["MessageId"]);

                    string SentDate = Func.ParseString(row["Created"]);
                    string MessageCommentId = Func.ParseString(row["MessageCommentId"]);

                    Func.SetGridTextValue(item, "ltrSender", Sender);
                    Func.SetGridTextValue(item, "ltrSentDate", Func.Formatdmyhms(SentDate));
                    Func.SetGridTextValue(item, "ltrBody", Body);

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

                        if (colName.EndsWith("Created"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkCreated");
                            link.Text = "Ngày" + img;
                        }
                        if (colName.EndsWith("Subject"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkSubject");
                            link.Text = "Tiêu đề" + img;
                        }
                        else if (colName.EndsWith("UserName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkUserName");
                            link.Text = "Người gửi" + img;
                        }
                        else if (colName.EndsWith("Flag"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkFlag");
                            link.Text = "Độ ưu tiên" + img;
                        }
                        else if (colName.EndsWith("Read"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkRead");
                            link.Text = "Tình trạng" + img;
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
