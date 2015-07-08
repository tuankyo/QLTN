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

using Gnt.Data.DBCommand;
using Gnt.Data;
using System.Data.SqlClient;
using BusinessObjects;
using Gnt.Transaction;
using Man.Utils;

namespace Man.Building.Document
{
    public partial class BD_Document : Man.PageBase
    {
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

        private string popup = "PopupBD_DocumentEdit";
        private string action = String.Empty;
        private string id = String.Empty;
        private string editPageName = "BD_DocumentEdit";

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Biểu Phí Tiền Nước";
        private string postback = "window.opener.__doPostBack('PopupBD_Document','');";
        private string key = "openBD_Document";

        /// <summary>
        /// Init values
        /// </summary>
        private void InitValues()
        {
        }

        /// <summary>
        /// Load data
        /// </summary>
        private void LoadData()
        {
            //Mst_BuildingData data = new Mst_BuildingData();
            //ITransaction tran = factory.GetLoadObject(data, Func.ParseString(Session["__BUILDINGID__"]));
            //Execute(tran);
            //if (!HasError)
            //{
            //    //Get Data
            //    data = (Mst_BuildingData)tran.Result;
            //    lblName.Text = data.Name;
            //    lblComment.Text = data.Comment;
            //    lblBuildingId.Text = data.BuildingId;
            //    lblName.Text = data.Name;
            //    lblInvestor.Text = data.Investor;
            //    lblAddress.Text = data.Address;
            //    lblPhone.Text = data.Phone;
            //    lblOwner.Text = data.Owner;
            //    lblManagerCompany.Text = data.ManagerCompany;
            //    lblManagerCompanyAgent.Text = data.ManagerCompanyAgent;
            //    lblManagerCompanyPhone.Text = data.ManagerCompanyPhone;
            //}

            ShowData();
        }

        protected override void DoPost()
        {
            //Handle postback from popup
            string eventTarget = Func.ParseString(Request["__EVENTTARGET"]);
            string eventArgument = Func.ParseString(Request["__EVENTARGUMENT"]);
            if (eventTarget.StartsWith("Popup"))
            {
                if (eventTarget == popup)
                {
                    ShowData();
                }
            }
        }
        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            InitValues();
        }
        protected override void DoGet()
        {
            action = Request["Action"];
            id = Request["id"];
            hidId.Value = id;
            hidAction.Value = action;
            hidDocType.Value = Request["DocType"];
            if (!IsPostBack)
            {
                switch (hidDocType.Value)
                {
                    case "1":
                        ltrPage.Text = "Thông tin tòa nhà > Hồ sơ";
                        break;
                    case "2":
                        ltrPage.Text = "Quản lý hoạt động > Hồ sơ";
                        break;
                    case "3":
                        ltrPage.Text = "Kỹ thuật > Hồ sơ";
                        break;
                    case "4":
                        ltrPage.Text = "Kế toán > Hồ sơ";
                        break;
                    case "5":
                        ltrPage.Text = "Hợp đồng > Hồ sơ";
                        break;
                    case "6":
                        ltrPage.Text = "Khách hàng > Hồ sơ";
                        break;
                    case "7":
                        ltrPage.Text = "Nhân viên > Hồ sơ";
                        break;
                    case "8":
                        ltrPage.Text = "Vật tư > Hồ sơ";
                        break;
                    case "9":
                        ltrPage.Text = "Trang thiết bị > Hồ sơ";
                        break;
                    default:
                        break;
                }
                LoadData();
            }
            DbHelper.FillList(drpDocSubject, "Select * from BD_DocSubject where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DocType = '" + hidDocType.Value + "' and (DelFlag is null or DelFlag = '0')", "DocSubject", "id");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtName, "Tên hồ sơ: là Danh mục bắt bắt buộc nhập");
            if (!mvMessage.IsValid) return;

            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                string filename = Func.ParseString(Session["__BUILDINGID__"])
                    + "_" + hidDocType.Value + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                    + fn;
                string SaveLocation = Server.MapPath("Data") + "\\" + filename;
                try
                {

                    File1.PostedFile.SaveAs(SaveLocation);

                    BD_DocumentData data = new BD_DocumentData();
                    ITransaction tran = factory.GetInsertObject(data);

                    data.Name = txtName.Text.Trim();
                    data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
                    data.Comment = txtComment.Text.Trim();
                    data.FileNamePath = filename;
                    data.ModifiedBy = Page.User.Identity.Name;
                    data.CreatedBy = Page.User.Identity.Name;
                    data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                    data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                    data.DelFlag = "0";
                    data.DocType = hidDocType.Value;
                    data.Appeal = txtAppeal.Text;
                    data.InOutDoc = rdoInDoc.Checked == true ? "0" : "1";
                    data.DocFrom = rdoCDT.Checked == true ? "0" : "1";
                    data.DocSubject = drpDocSubject.SelectedValue;

                    switch (hidDocType.Value)
                    {
                        case "1":
                            break;
                        case "2":
                            data.Dept = "2";
                            break;
                        case "3":
                            data.Dept = "3";
                            break;
                        case "4":
                            data.Dept = "4";
                            break;
                        //case "5":
                        //    data.ContractId = hidId.Value;
                        //    break;
                        //case "6":
                        //    data.CustomerId =  hidId.Value;
                        //    break;
                        //case "7":
                        //    data.StaffId =  hidId.Value;
                        //    break;
                        //case "8":
                        //    data.SuppliesId =  hidId.Value;
                        //    break;
                        //case "9":
                        //    data.EquipmentId = hidId.Value;
                        //    break;
                        case "5":
                        case "6":
                        case "7":
                        case "8":
                        case "9":
                            data.DocTypeId = hidId.Value;
                            break;
                        default:
                            break;
                    }

                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(addSuccess);
                        ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                        btnRegister.CommandName = "Register";
                        hidAction.Value = "Edit";
                        //hidId.Value = data.id;

                        ShowData();
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(addUnSuccess);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }


        }
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "A.Modified";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                string condition = "";
                switch (hidDocType.Value)
                {
                    case "1":
                        break;
                    case "2":
                        condition = " And Dept = '2'";
                        break;
                    case "3":
                        condition = " And Dept = '3'";
                        break;
                    case "4":
                        condition = " And Dept = '4'";
                        break;
                    //case "5":
                    //    condition = " And ContractId = '" + hidId.Value + "'";
                    //    break;
                    //case "6":
                    //    condition = " And CustomerId = '" + hidId.Value + "'";
                    //    break;
                    //case "7":
                    //    condition = " And StaffId = '" + hidId.Value + "'";
                    //    break;
                    //case "8":
                    //    condition = " And SuppliesId = '" + hidId.Value + "'";
                    //    break;
                    //case "9":
                    //    condition = " And EquipmentId = '" + hidId.Value + "'";
                    //    break;
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        condition = " And DocTypeId = '" + hidId.Value + "'";
                        break;
                    default:
                        break;
                }

                //Đếm số lượng record
                sql += " SELECT COUNT(ID) ";
                sql += " FROM [BD_Document]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and DocType = '" + hidDocType.Value + "'" + condition;


                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT A.*,B.DocSubject Subject, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_Document A left outer join BD_DocSubject B on A.DocSubject = B.id ";
                sql += " WHERE (A.ID IS NOT NULL) and A.DelFlag <> 1 and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and A.DocType = '" + hidDocType.Value + "'" + condition;


                //Phân trang
                sql = " SELECT * FROM (" + sql + ") AS TMP ";
                sql += " WHERE RowNum BETWEEN @PageIndex*@PageSize + 1  AND (@PageIndex+1)*@PageSize ORDER BY RowNum ";

                //Thực hiện câu SQL

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

        protected void pager_PageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            ShowData();
        }

        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string colName = string.Empty;
            if (command.StartsWith("Sort"))
            {
                if (string.Compare(command, "SortID") == 0)
                {
                    colName = "ID";
                }
                else if (string.Compare(command, "SortName") == 0)
                {
                    colName = "Name";
                }
                else if (string.Compare(command, "SortModifiedBy") == 0)
                {
                    colName = "ModifiedBy";
                }
                else if (string.Compare(command, "SortModified") == 0)
                {
                    colName = "Modified";
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
            //else if (command.Equals("Update"))
            //{
            //    TextBox txtName = (TextBox)e.Item.FindControl("txtName");
            //    TextBox txtComment = (TextBox)e.Item.FindControl("txtComment");

            //    RadioButton irdoInDoc = (RadioButton)e.Item.FindControl("irdoInDoc");
            //    RadioButton irdoOutDoc = (RadioButton)e.Item.FindControl("irdoOutDoc");
            //    RadioButton irdoCDT = (RadioButton)e.Item.FindControl("irdoCDT");
            //    RadioButton irdoCustomer = (RadioButton)e.Item.FindControl("irdoCustomer");
            //    TextBox itxtAppeal = (TextBox)e.Item.FindControl("itxtAppeal");

            //    BD_DocumentData data = new BD_DocumentData();
            //    ITransaction tran = factory.GetLoadObject(data, Func.ParseString(e.CommandArgument));
            //    Execute(tran);
            //    if (!HasError)
            //    {
            //        //Get Data
            //        data = (BD_DocumentData)tran.Result;
            //        data.Name = txtName.Text.Trim();
            //        data.Comment = txtComment.Text.Trim();
            //        data.Appeal = itxtAppeal.Text;
            //        data.InOutDoc = irdoInDoc.Checked.Equals(true) ? "0" : "1";
            //        data.DocFrom = irdoCDT.Checked.Equals(true) ? "0" : "1";

            //        data.ModifiedBy = Page.User.Identity.Name;
            //        data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

            //        tran = factory.GetUpdateObject(data);

            //        Execute(tran);

            //        if (!HasError)
            //        {
            //            OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
            //            mvMessage.SetCompleteMessage(updateSuccess);
            //            ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);
            //        }
            //        else
            //        {
            //            OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
            //            mvMessage.AddError(updateUnSuccess);
            //        }
            //        ShowData();
            //    }
            //}
            else if (command.Equals("View"))
            {
                string path = (string)e.CommandArgument;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('./Data/" + path + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            }
            else if (command.Equals("Update"))
            {
                string path = (string)e.CommandArgument;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('./" + editPageName + ".aspx?Id=" + id + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
            }
            else if (command.Equals("Delete"))
            {
                BD_DocumentData data = new BD_DocumentData();
                ITransaction tran = factory.GetLoadObject(data, Func.ParseString(e.CommandArgument));
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (BD_DocumentData)tran.Result;
                    data.DelFlag = "1";

                    data.ModifiedBy = Page.User.Identity.Name;
                    data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");

                    tran = factory.GetUpdateObject(data);

                    Execute(tran);

                    if (!HasError)
                    {
                        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
                        mvMessage.SetCompleteMessage(updateSuccess);
                        ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);
                    }
                    else
                    {
                        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
                        mvMessage.AddError(updateUnSuccess);
                    }
                    ShowData();
                }
            }
        }

        /// </summary>Hiển thị nội dung trên datagrid
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

                    string id = Func.ParseString(row["id"]);
                    string Name = Func.ParseString(row["Name"]);
                    string FileNamePath = Func.ParseString(row["FileNamePath"]);
                    string Comment = Func.ParseString(row["Comment"]);
                    string DocSubject = Func.ParseString(row["Subject"]);

                    Func.SetGridLinkValue(item, "btnView", Name);
                    Func.SetGridTextValue(item, "ltrName", Name);
                    Func.SetGridTextValue(item, "ltrComment", Comment);
                    Func.SetGridTextValue(item, "ltrDocSubject", DocSubject);

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    LinkButton btnView = (LinkButton)item.FindControl("btnView");
                    btnView.CommandArgument = FileNamePath;

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = id;

                    PopupWidth = 600;
                    PopupHeight = 450;
                    LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Id=" + id);
                    
                    Func.SetGridTextValue(item, "ltrAppeal", Func.ParseString(row["Appeal"]));

                    if (Func.ParseString(row["InOutDoc"]).Equals("0"))
                    {
                        Func.SetGridTextValue(item, "ltrInOutDoc", "Đi");

                    }
                    else
                    {
                        Func.SetGridTextValue(item, "ltrInOutDoc", "Đến");

                    }
                    if (Func.ParseString(row["DocFrom"]).Equals("0"))
                    {
                        Func.SetGridTextValue(item, "ltrDocFrom", "Chủ Đầu Tư");

                    }
                    else
                    {
                        Func.SetGridTextValue(item, "ltrDocFrom", "Khách Hàng");

                    }
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

                        if (colName.EndsWith("Id"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkTypeId");
                            link.Text = "ID" + img;
                        }
                        else if (colName.EndsWith("Address"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Địa Chỉ" + img;
                        }
                        else if (colName.EndsWith("Name"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Loại Phí" + img;
                        }
                        else if (colName.EndsWith("ModifiedBy"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModifiedBy");
                            link.Text = "Cập Nhật" + img;
                        }
                        else if (colName.EndsWith("Modified"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkModified");
                            link.Text = "Ngày Cập Nhật" + img;
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
