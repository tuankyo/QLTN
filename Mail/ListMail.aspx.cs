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
    public partial class ListMail : PageBase
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
        /// Set where clause for search options
        /// </summary>
        /// <returns></returns>
        private string GetWhere()
        {
            string whereClause = string.Empty;
            whereClause += " AND F.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";
            return whereClause;
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

            //HtmlGenericControl newControl = new HtmlGenericControl("div");
            //newControl.ID = "NEWControl" + 1    ;
            //newControl.InnerHtml = "This is a dynamically created HTML server control.";


            //lnkFile1.Text = "";
            //lnkFile2.Text = "";
            //lnkFile3.Text = "";
            //lnkFile4.Text = "";

            //lnkFile1.CommandArgument = "";
            //lnkFile2.CommandArgument = "";
            //lnkFile3.CommandArgument = "";
            //lnkFile4.CommandArgument = "";

            ////int i = 1;
            ////foreach (DataRow dr in dt.Rows)
            ////{
            ////    string fileName = dr["fileName"].ToString();
            ////    string pathName = dr["pathFile"].ToString();
            ////    string orgFileName = dr["OrgFileName"].ToString();

            ////    switch (i)
            ////    {
            ////        case 1:
            ////            LinkButton lnkFile01 = new LinkButton();
            ////            lnkFile01.Text = orgFileName;
            ////            lnkFile01.CommandArgument = fileName;
            ////            lnkFile01.Command += new CommandEventHandler(btnFile_Click);
            ////            PlaceHolder1.Controls.Add(lnkFile01);

            ////            break;
            ////        case 2:
            ////            //lnkFile2.Text = orgFileName;
            ////            //lnkFile2.CommandArgument = fileName;
            ////            //PlaceHolder1.Controls.Add(newControl);

            ////            break;
            ////        case 3:
            ////            //lnkFile3.Text = orgFileName;
            ////            //lnkFile3.CommandArgument = fileName;
            ////            //PlaceHolder1.Controls.Add(newControl);

            ////            break;
            ////        case 4:
            ////            //lnkFile4.Text = orgFileName;
            ////            //lnkFile4.CommandArgument = fileName;
            ////            //PlaceHolder1.Controls.Add(newControl);

            ////            break;
            ////        case 5:
            ////            //lnkFile5.Text = orgFileName;
            ////            //lnkFile5.CommandArgument = fileName;
            ////            //PlaceHolder1.Controls.Add(newControl);

            ////            break;

            ////    }
            ////    i++;
            ////}


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
        /// List data
        /// </summary>
        private void ShowData(string PlaceHoldId, string Search)
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            string FullName = string.Empty;

            if (Session["__USERFULLNAME__"] != null)
            {
                FullName = Func.ParseString(Session["__USERFULLNAME__"]);
            }
            else
            {
                sql = "SELECT FullName FROM aspnet_Membership "
                + " WHERE UserId=(SELECT UserId FROM aspnet_Users WHERE UserName='" + Page.User.Identity.Name + "')";
                FullName = Func.ParseString(db.ExecuteScalar(sql));
                Session["__USERFULLNAME__"] = (FullName.Length != 0 ? FullName : Page.User.Identity.Name);
            }
            ltrFullName.Text = FullName;

            divCompose.Visible = false;
            divMail.Visible = true;
            divReadMail.Visible = false;
            hidReply.Value = "0";

            string whereString = GetWhere();
            sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "A.Created";
                ListSortDirection = SortDirection.Descending;
            }
            try
            {
                int cntInbox = 0;
                int cntSentItems = 0;
                int cntDraft = 0;
                int cntTrash = 0;
                int cntSpam = 0;

                int cntInboxReadNotYet = 0;
                int cntSentItemsReadNotYet = 0;
                int cntDraftReadNotYet = 0;
                int cntTrashReadNotYet = 0;
                int cntSpamReadNotYet = 0;


                ///////////////////////////////Xe
                sql = "Select * from UsersMessagesMapped Where UserName = '" + Page.User.Identity.Name + "' and Delflag = 0";
                DataTable dt = new DataTable();

                dt = DbHelper.GetDataTable(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    string strPlaceHolderID = dr["PlaceHolderID"].ToString();
                    string IsRead = dr["IsRead"].ToString();
                    string IsReply = dr["IsReply"].ToString();

                    switch (strPlaceHolderID)
                    {
                        case "1":
                            cntInbox++;
                            if ("0".Equals(IsRead))
                                cntInboxReadNotYet++;
                            break;
                        //case "2": cntSentItems++;
                        //    if ("0".Equals(IsRead))
                        //        cntSentItemsReadNotYet++;
                        //    break;
                        case "3": cntDraft++;
                            if ("0".Equals(IsRead))
                                cntDraftReadNotYet++;
                            break;
                        case "4": cntTrash++;
                            //if ("0".Equals(IsRead))
                            //    cntTrashReadNotYet++;
                            break;
                        case "5": cntSpam++;
                            if ("0".Equals(IsRead))
                                cntSpamReadNotYet++;
                            break;
                        default:
                            break;
                    }
                }

                lnkInbox.Text = "Hộp Tin(" + cntInbox + "," + cntInboxReadNotYet + ")";
                lnkSent.Text = "Tin Đã Gửi(" + DbHelper.GetCount("Select count(*) from Messages Where UserName = '" + Page.User.Identity.Name + "' and Delflag = 0") + ")";
                //lnkDraft.Text = "Tin Đang Soạn(" + cntDraft + "," + cntDraftReadNotYet + ")";
                lnkTrash.Text = "Thùng Rác(" + cntTrash + ")";
                int count = 0;
                string sort = "";

                if (!String.IsNullOrEmpty(PlaceHoldId))
                {
                    if ("2".Equals(PlaceHoldId))
                    {
                        sql = " SELECT COUNT(*) ";
                        sql += " FROM Messages A";
                        sql += " WHERE DelFlag=0 and UserName = '" + Page.User.Identity.Name + "'";

                        count = db.ExecuteCount(sql);
                        sql = string.Empty;
                        sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                        //検索条件で取得情報のSQL文を作成する
                        sql = " SELECT C.Count, B.Flag, '-1' isReply,'-1' isRead,A.*, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                        sql += " FROM Messages A left outer join MST_Flag B on A.FlagId = B.FlagId left outer join (SELECT     A.MessageID, COUNT(*) AS Count";
                        sql += " FROM         MessageComment AS A INNER JOIN";
                        sql += "                       MessageCommentReadFlg AS B ON A.MessageCommentId = B.MessageCommentId";
                        sql += " WHERE     (B.ReadFlag = 0) AND (B.UserName = N'" + Page.User.Identity.Name + "')";
                        sql += " GROUP BY A.MessageID) C on A.MessageId = C.MessageId";
                        sql += " WHERE DelFlag=0 and UserName = '" + Page.User.Identity.Name + "'";
                    }
                    else
                    {
                        ////件数を数える
                        sql = " SELECT COUNT(*) ";
                        sql += " FROM UsersMessagesMapped";
                        sql += " WHERE DelFlag=0 and UserName = '" + Page.User.Identity.Name + "' and PlaceHolderId = '" + PlaceHoldId + "'";

                        count = db.ExecuteCount(sql);
                        sql = string.Empty;
                        sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                        //検索条件で取得情報のSQL文を作成する
                        sql = " SELECT D.Count, C.Flag, A.Created,A.MessageMapId,A.MessageID,A.PlaceHolderID,A.IsRead,A.IsReply,B.UserName,B.Subject, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                        sql += " FROM UsersMessagesMapped A inner join Messages B ";
                        sql += " on A.MessageID = B.MessageID left outer join MST_Flag C on A.FlagId = C.FlagId left outer join (SELECT     A.MessageID, COUNT(*) AS Count";
                        sql += " FROM         MessageComment AS A INNER JOIN";
                        sql += "                       MessageCommentReadFlg AS B ON A.MessageCommentId = B.MessageCommentId";
                        sql += " WHERE     (B.ReadFlag = 0) AND (B.UserName = N'" + Page.User.Identity.Name + "')";
                        sql += " GROUP BY A.MessageID) D on A.MessageId = D.MessageId";
                        sql += " Where A.DelFlag=0 and A.UserName = '" + Page.User.Identity.Name + "' and A.PlaceHolderId = '" + PlaceHoldId + "'";
                    }
                    //ページによるレコーダを取得する
                }
                else
                {
                    ////件数を数える
                    sql = " SELECT COUNT(*) ";
                    sql += " FROM UsersMessagesMapped A inner join Messages B ";
                    sql += " on A.MessageID = B.MessageID left outer join MST_Flag C on A.FlagId = C.FlagId Where A.DelFlag=0 and A.UserName = '" + Page.User.Identity.Name + "' and ( B.UserName like '%" + Search + "%' or B.Subject like '%" + Search + "%' or B.Body like '%" + Search + "%')";

                    count = db.ExecuteCount(sql);
                    sql = string.Empty;
                    sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                    //検索条件で取得情報のSQL文を作成する
                    sql = " SELECT D.Count, C.Flag, A.Created,A.MessageMapId,A.MessageID,A.PlaceHolderID,A.IsRead,A.IsReply,B.UserName,B.Subject, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                    sql += " FROM UsersMessagesMapped A inner join Messages B ";
                    sql += " on A.MessageID = B.MessageID left outer join MST_Flag C on A.FlagId = C.FlagId left outer join (SELECT     A.MessageID, COUNT(*) AS Count";
                    sql += " FROM         MessageComment AS A INNER JOIN";
                    sql += "                       MessageCommentReadFlg AS B ON A.MessageCommentId = B.MessageCommentId";
                    sql += " WHERE     (B.ReadFlag = 0) AND (B.UserName = N'" + Page.User.Identity.Name + "')";
                    sql += " GROUP BY A.MessageID) D on A.MessageId = D.MessageId";
                    sql += " Where A.DelFlag=0 and A.UserName = '" + Page.User.Identity.Name + "' and ( B.UserName like '%" + Search + "%' or B.Subject like '%" + Search + "%' or B.Body like '%" + Search + "%')";
                }
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
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
            }
        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("PopUp"))
            {
                if (eventTarget == "PopUpComment")
                {
                    ShowData(hidPlaceHolder.Value, "");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                DbHelper.FillList(drpFlag, "Select * from MST_Flag", "Flag", "FlagId");

                drpFlag.Attributes["style"] = "background-image:url('../App_Themes/Default/images/" + drpFlag.SelectedItem.Text + ".png');background-repeat:no-repeat;padding:.4em";

                PopupWidth = 850;
                PopupHeight = 450;
                PopupName = "EditFlat";
                BindGridview();
                hidPlaceHolder.Value = "1";
                ShowData(hidPlaceHolder.Value, "");
            }

            foreach (ListItem li in drpFlag.Items)
            {
                li.Attributes.Add("style", "background-image:url('../App_Themes/Default/images/" + li.Text + ".png');background-repeat:no-repeat;padding:.4em");
            }

        }
        public void Color_Selection_Change(Object sender, EventArgs e)
        {
            drpFlag.Attributes["style"] = "background-image:url('../App_Themes/Default/images/" + drpFlag.SelectedItem.Text + ".png');background-repeat:no-repeat;padding:.4em";
            foreach (ListItem li in drpFlag.Items)
            {
                li.Attributes.Add("style", "background-image:url('../App_Themes/Default/images/" + li.Text + ".png');background-repeat:no-repeat;padding:.4em");
            }
        }
        protected void BindGridview()
        {
            //SqlDatabase db = new SqlDatabase();
            //string sql = "select RichTextData from RichTextBoxData";
            //SqlCommand cm = db.CreateCommand(sql);

            //SqlDataAdapter da = new SqlDataAdapter(cm);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //gvdetails.DataSource = ds;
            //gvdetails.DataBind();
        }
        protected void btnInbox_Click(object sender, EventArgs e)
        {
            hidPlaceHolder.Value = "1";
            ShowData(hidPlaceHolder.Value, "");
        }
        protected void btnSent_Click(object sender, EventArgs e)
        {
            hidPlaceHolder.Value = "2";
            ShowData(hidPlaceHolder.Value, "");
        }
        protected void btnDraf_Click(object sender, EventArgs e)
        {
            hidPlaceHolder.Value = "3";
            ShowData(hidPlaceHolder.Value, "");
        }
        protected void btnTrash_Click(object sender, EventArgs e)
        {
            hidPlaceHolder.Value = "4";
            ShowData(hidPlaceHolder.Value, "");
        }
        protected void btnCompose_Click(object sender, EventArgs e)
        {
            divCompose.Visible = true;
            divMail.Visible = false;
            divReadMail.Visible = false;
            hidReply.Value = "0";

            txtSubject.Text = "";

            txtContent.Text = "";
            txtToCC.Text = "";
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
        protected void btnOpenContactCc_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('CcContact.aspx?UserName=" + Page.User.Identity.Name + "&type=cc'," + PopupWidth + "," + PopupHeight + ",'CcContact', true);", true);

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ids = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rptList.Items[i].FindControl("chkDelete");
                HiddenField hidId = (HiddenField)rptList.Items[i].FindControl("hidId");
                if (chk.Checked)
                {
                    ids += "," + "'" + hidId.Value + "'";
                }
            }
            if (!String.IsNullOrEmpty(ids))
            {
                ids = "(" + ids.Substring(1) + ")";
                DbHelper.ExecuteDB("Update UsersMessagesMapped Set PlaceHolderID = 4 where UserName = '" + Page.User.Identity.Name + "' and MessageMapId in " + ids + "");
            }
            ShowData("1", "");
        }
        protected void btnOpenContactBcc_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('CcContact.aspx?UserName=" + Page.User.Identity.Name + "&type=bcc'," + PopupWidth + "," + PopupHeight + ",'CcContact', true);", true);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData("", txtSearch.Text.Trim());
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            divCompose.Visible = true;
            divMail.Visible = false;
            divReadMail.Visible = false;
            hidReply.Value = "1";
            txtSubject.Text = "RE: " + lblSubject.Text;

            txtContent.Text = "</br></br></br></br></br>===========================" + ltrBody.Text;
            txtToCC.Text = lblCC.Text;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ("1".Equals(hidReply.Value) && !String.IsNullOrEmpty(hidMessageId.Value))
            {
                DbHelper.ExecuteNonQuery("Update UsersMessagesMapped Set isReply = 1 Where UserName = '" + Page.User.Identity.Name + "' and MessageId = '" + hidMessageId.Value + "'");
            }

            mvMessage.CheckRequired(txtToCC, "Người nhận: cần nhập thông tin");
            mvMessage.CheckRequired(txtSubject, "Tiêu đề: cần nhập thông tin");
            string uploadFileId = "";

            string[] cc = txtToCC.Text.Replace(System.Environment.NewLine, string.Empty).Split(';');
            for (int i = 0; i < cc.Length; i++)
            {
                if (!String.IsNullOrEmpty(cc[i]))
                {
                    int count = DbHelper.GetCount("Select count(*) from aspnet_Users where UserName = '" + cc[i] + "'");
                    if (count == 0)
                        mvMessage.AddError(cc[i] + ": User này không tồn tại");
                }
            }

            if (!String.IsNullOrEmpty(txtToBCC.Text))
            {
                string[] bcc = txtToBCC.Text.Replace(System.Environment.NewLine, string.Empty).Split(';');
                for (int i = 0; i < bcc.Length; i++)
                {
                    if (!String.IsNullOrEmpty(bcc[i]))
                    {
                        int count = DbHelper.GetCount("Select count(*) from aspnet_Users where UserName = '" + bcc[i] + "'");
                        if (count == 0)
                            mvMessage.AddError(bcc[i] + ": User này không tồn tại");
                    }
                }
            }

            if (!mvMessage.IsValid)
                return;


            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + fn;
                string SaveLocation = Server.MapPath("Mail") + "\\File\\" + filename;
                try
                {

                    File1.PostedFile.SaveAs(SaveLocation);

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
                        uploadFileId += ";" + data.UploadFileId;
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

            if ((File2.PostedFile != null) && (File2.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + fn;
                string SaveLocation = Server.MapPath("Mail") + "\\File\\" + filename;
                try
                {

                    File2.PostedFile.SaveAs(SaveLocation);

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
                        uploadFileId += ";" + data.UploadFileId;

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

            if ((File3.PostedFile != null) && (File3.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File3.PostedFile.FileName);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + fn;
                string SaveLocation = Server.MapPath("Mail") + "\\File\\" + filename;
                try
                {

                    File3.PostedFile.SaveAs(SaveLocation);

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
                        uploadFileId += ";" + data.UploadFileId;

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

            if ((File4.PostedFile != null) && (File4.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File4.PostedFile.FileName);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + fn;
                string SaveLocation = Server.MapPath("Mail") + "\\File\\" + filename;
                try
                {

                    File4.PostedFile.SaveAs(SaveLocation);

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
                        uploadFileId += ";" + data.UploadFileId;
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

            if ((File5.PostedFile != null) && (File5.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File5.PostedFile.FileName);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + fn;
                string SaveLocation = Server.MapPath("Mail") + "\\File\\" + filename;
                try
                {

                    File5.PostedFile.SaveAs(SaveLocation);

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
                        uploadFileId += ";" + data.UploadFileId;

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

            //using (SqlConnection con = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
            //{
            //    con.Open();

            //    SqlCommand cmd = new SqlCommand("insert into RichTextBoxData(RichTextData) values(@Richtextbox)", con);
            //    cmd.Parameters.AddWithValue("@Richtextbox", FreeTextBox1.Text);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    FreeTextBox1.Text = "";
            //    lbltxt.Text = "Data Inserted Successfully";
            //    BindGridview();
            //}

            MessagesData dataM = new MessagesData();
            ITransaction tranM = factory.GetInsertObject(dataM);

            dataM.Subject = txtSubject.Text.Trim();
            dataM.Body = txtContent.Text;
            dataM.UserName = Page.User.Identity.Name;
            dataM.DelFlag = "0";
            dataM.CcUser = txtToCC.Text;
            dataM.BccUser = txtToBCC.Text;
            dataM.FlagId = drpFlag.SelectedValue;
            dataM.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            dataM.Updator = Page.User.Identity.Name;
            dataM.Creator = Page.User.Identity.Name;
            dataM.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            dataM.Updated = DateTime.Now.ToString("yyyyMMddHHmmss");

            Execute(tranM);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, "Tạo Mới Thông Tin Thành Công", Page.User.Identity.Name);
                string MessageId = dataM.MessageID;

                using (SqlConnection rConn = new SqlConnection(Gnt.Configuration.ApplicationConfiguration.ConnectionString))
                {
                    rConn.Open();
                    using (SqlCommand cm = new SqlCommand("sp_AddMail", rConn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@MessageId", MessageId);
                        cm.Parameters.AddWithValue("@FlagId", drpFlag.SelectedValue);
                        cm.Parameters.AddWithValue("@UploadFileId", uploadFileId);
                        cm.Parameters.AddWithValue("@BuildingId", Func.ParseString(Session["__BUILDINGID__"]));
                        cm.Parameters.AddWithValue("@UserNames", txtToCC.Text.Replace(System.Environment.NewLine, string.Empty) + ";" + txtToBCC.Text.Replace(System.Environment.NewLine, string.Empty));

                        cm.Parameters.AddWithValue("@Created", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        cm.Parameters.AddWithValue("@CreatedBy", Page.User.Identity.Name);

                        cm.ExecuteNonQuery();
                    }
                    rConn.Close();
                    mvMessage.SetCompleteMessage("Thực Hiện Thành Công");
                }

            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, "Tạo Mới Thông Tin Phát Sinh Lỗi", Page.User.Identity.Name);
                mvMessage.AddError("Tạo Mới Thông Tin Phát Sinh Lỗi");
            }
            ShowData("1", "");
        }
        /// <summary>
        /// ページ押下処理

        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData(hidPlaceHolder.Value, "");

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
                ShowData(hidPlaceHolder.Value, "");

            }
            else if (command.Equals("ReadMail"))
            {
                DbHelper.ExecuteNonQuery("Update UsersMessagesMapped Set isRead = 1 Where UserName = '" + Page.User.Identity.Name + "' and MessageId = '" + e.CommandArgument + "'");
                ShowData(hidPlaceHolder.Value, "");
                divReadMail.Visible = true;
                divMail.Visible = false;
                divCompose.Visible = false;
                LoadMail(Func.ParseString(e.CommandArgument));
                hidMessageId.Value = Func.ParseString(e.CommandArgument);
            }
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
                    string id = Func.ParseString(row["MessageId"]);
                    int count = Func.ParseInt(row["Count"]);

                    string SentDate = Func.ParseString(row["Created"]);
                    string Subject = Func.ParseString(row["Subject"]);
                    string isReply = Func.ParseString(row["isReply"]);
                    string isRead = Func.ParseString(row["isRead"]);
                    string Flag = Func.ParseString(row["Flag"]);

                    Func.SetGridTextValue(item, "ltrSender", Sender);
                    Func.SetGridTextValue(item, "ltrSentDate", Func.Formatdmyhms(SentDate));
                    Func.SetGridLinkValue(item, "ltrSubject", Func.ToolTipByteLen(Subject, 150));



                    LinkButton lbt = (LinkButton)item.FindControl("ltrSubject");
                    lbt.CommandArgument = id;

                    ImageButton bt = (ImageButton)item.FindControl("btnStatus");
                    bt.CommandArgument = id;

                    bt.ImageUrl = "~/App_Themes/Default/images/new.png";
                    if ("1".Equals(isReply))
                    {
                        bt.ImageUrl = "~/App_Themes/Default/images/replied.png";
                    }
                    else if ("1".Equals(isRead))
                    {
                        bt.ImageUrl = "~/App_Themes/Default/images/readed.png";
                    }

                    if ("2".Equals(hidPlaceHolder.Value))
                    {
                        bt.Visible = false;
                    }

                    bt = (ImageButton)item.FindControl("btnFlag");
                    bt.ImageUrl = "../App_Themes/Default/images/" + (String.IsNullOrEmpty(Flag) ? "null" : Flag) + ".png";


                    bt = (ImageButton)item.FindControl("btnComment");

                    if (count > 0)
                    {
                        bt.ImageUrl = "~/App_Themes/Default/images/Comment_Noti.png";
                    }
                    if ("2".Equals(hidPlaceHolder.Value))
                    {
                        bt.Visible = false;
                    }

                    ImageButtonPopup((ImageButton)item.FindControl("btnComment"), "MailComment.aspx?id=" + id);

                    CheckBox chk = (CheckBox)item.FindControl("chkDelete");
                    if ("2".Equals(hidPlaceHolder.Value))
                    {
                        chk.Visible = false;
                    }
                    string MessageMapId = Func.ParseString(row["MessageMapId"]);
                    HiddenField hidId = (HiddenField)item.FindControl("hidId");
                    hidId.Value = MessageMapId;
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
