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

namespace Man.Building.Staff
{
    public partial class BD_WorkingExtraTimeInfoEdit : Man.PageBase
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
        private string action = String.Empty;
        private string id = String.Empty;

        private string updateSuccess = "Cập Nhật Thông Tin Đã Thành Công";
        private string updateUnSuccess = "Cập Nhật Thông Tin Không Thành Công";
        private string addSuccess = "Thêm Mới Thành Công";
        private string addUnSuccess = "Thêm Mới Không Thành Công";
        private string title = "Thông Tin Làm Thêm Của Nhân Viên";
        private string postback = "window.opener.__doPostBack('PopupBD_StaffEdit','');";
        private string key = "openBD_StaffEdit";
        private string deleteSuccess = "Xóa Thành Công";
        private string deleteUnSuccess = "Xóa Không Thành Công";

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
            
        }

        /// <summary>
        /// Update
        /// </summary>
        private void UpdateData()
        {
            //BD_WorkingExtraTimeInfoData data = new BD_WorkingExtraTimeInfoData();
            //ITransaction tran = factory.GetLoadObject(data, hidId.Value);
            //Execute(tran);
            //if (!HasError)
            //{
            //    //Get Data
            //    data = (BD_WorkingExtraTimeInfoData)tran.Result;
            //    data.Name = txtName.Text.Trim();
            //    data.Comment = txtComment.Text.Trim();

            //    data.ModifiedBy = Page.User.Identity.Name;
            //    data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            //    data.DelFlag =  true.Equals(chkDelFlag.Checked) ? "0" : "1";

            //    data.Phone = txtPhone.Text;
            //    data.Address = txtAddress.Text;
            //    data.Mail = txtMail.Text;
            //    data.JobBegin = txtJobBegin.Text;
            //    data.JobEnd = !"".Equals(txtJobEnd.Text) ? Func.Formatdmyhms(txtJobEnd.Text) : "";

            //    data.JobTypeId = drpJobTypeId.SelectedValue;

            //    tran = factory.GetUpdateObject(data);

            //    Execute(tran);

            //    if (!HasError)
            //    {
            //        OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateSuccess, Page.User.Identity.Name);
            //        mvMessage.SetCompleteMessage(updateSuccess);
            //        ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

            //        lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
            //        lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
            //    }
            //    else
            //    {
            //        OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, updateUnSuccess, Page.User.Identity.Name);
            //        mvMessage.AddError(updateUnSuccess);
            //    }
            //}
        }

        /// <summary>
        /// Insert data
        /// </summary>
        private void InsertData()
        {
            //Get and Insert Data
            BD_WorkingExtraTimeInfoData data = new BD_WorkingExtraTimeInfoData();
            ITransaction tran = factory.GetInsertObject(data);
            data.Comment = txtComment.Text.Trim();
            data.ModifiedBy = Page.User.Identity.Name;
            data.CreatedBy = Page.User.Identity.Name;
            data.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
            data.DelFlag = true.Equals(chkDelFlag.Checked) ? "0" : "1";

            data.WorkingDate = Func.FormatYYYYmmdd(txtWorkingDate.Text);
            data.WorkingHour = drpWorkingHourId.SelectedValue;
            data.WorkingPlace = drpWorkingPlaceId.SelectedValue;
            data.WorkingHourFrom = drpHourFrom.SelectedValue;
            data.WorkingHourTo = drpHourTo.SelectedValue;
            data.WorkingMinuteFrom = drpMinuteFrom.Value;
            data.WorkingMinuteTo = drpMinuteTo.Value;

            float hour = Func.ParseInt(data.WorkingHourTo) - Func.ParseInt(data.WorkingHourFrom);
            int hourOdd = Func.ParseInt(data.WorkingMinuteTo) - Func.ParseInt(data.WorkingMinuteFrom);
            if (hourOdd < 0)
            {
                hour--;
            }
            else
            {
                hour += Func.ParseFloat(hourOdd) / 60;
            }

            data.ExtraHour = Func.ParseString(hour).Replace(",",".");

            data.JobContent = txtJobContecnt.Text;

            data.BuildingId = Func.ParseString(Session["__BUILDINGID__"]);
            data.StaffId = hidId.Value;

            Execute(tran);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addSuccess, Page.User.Identity.Name);
                mvMessage.SetCompleteMessage(addSuccess);
                ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);

                ShowData();
                //btnRegister.CommandName = "Register";
                //hidAction.Value = "Edit";
                //txtId.Enabled = false;

                //lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                //lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, addUnSuccess, Page.User.Identity.Name);
                mvMessage.AddError(addUnSuccess);
            }

        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            action = Request["Action"];
            id = Request["id"];

            hidId.Value = id;
            hidAction.Value = action;
            hidJobType.Value = Request["JobType"];

            BD_StaffData data = new BD_StaffData();
            ITransaction tran = factory.GetLoadObject(data, id);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_StaffData)tran.Result;
                txtId.Text = data.StaffId;
                txtName.Text = data.Name;

                chkDelFlag.Checked = "1".Equals(data.DelFlag) ? false : true;
                txtJobContecnt.Text = data.JobContent;

                lblCreated.Text = !"".Equals(data.Created) ? data.CreatedBy + "(" + Func.Formatdmyhms(data.Created) + ")" : "";
                lblModified.Text = !"".Equals(data.Modified) ? data.ModifiedBy + "(" + Func.Formatdmyhms(data.Modified) + ")" : "";

                hidId.Value = id;
            }

            for (int i = 0; i < 24; i++)
            {
                drpHourFrom.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
                drpHourTo.Items.Add(new ListItem(Func.ParseString(i).PadLeft(2, '0'), Func.ParseString(i).PadLeft(2, '0')));
            }
            drpHourFrom.Items.FindByValue(DateTime.Now.AddHours(-1).ToString("hh")).Selected = true;
            drpHourTo.Items.FindByValue(DateTime.Now.AddHours(1).ToString("hh")).Selected = true;
            DbHelper.FillListSearch(drpWorkingHourId, "SELECT WorkingHourId + '-' + Name as WorkingHourId FROM BD_WorkingHour Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and JobTypeId = '" + hidJobType.Value + "' ", "WorkingHourId", "WorkingHourId");
            DbHelper.FillListSearch(drpWorkingPlaceId, "Select WorkingPlaceId + '-' + Name WorkingPlaceId From BD_WorkingPlace Where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and delFlag = 0 and JobTypeId = '" + hidJobType.Value + "'", "WorkingPlaceId", "WorkingPlaceId");
            ShowData();
        }
        protected override void DoGet()
        {
            chkDelFlag.Enabled = DbHelper.isAdmin(Page.User.Identity.Name);

            action = Request["Action"];
            id = Request["id"];

            hidId.Value = id;
            hidAction.Value = action;

            SqlDatabase db = new SqlDatabase();
            if (action == "Edit")
            {
                lblHeader.Text = "Thông Tin Chi Tiết " + title;
                btnRegister.Text = "Cập Nhật";
                btnCancel.Text = "Đóng";
                btnRegister.CommandName = "Edit";
                txtId.Enabled = false;
                if (!IsPostBack)
                {
                    LoadData();
                }
            }
            else // Add new case
            {
                lblHeader.Text = "Thêm Mới " + title;
                btnRegister.Text = "Thêm Mới";
                btnRegister.CommandName = "Register";
                btnCancel.Text = "Đóng";
            }
        }

        protected override void DoPost()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtName, "* là Danh mục bắt bắt buộc nhập");
            if (hidAction.Value == "Edit")
            {
                UpdateData();
            }
            else // Add new case
            {
                InsertData();
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
                //Đếm số lượng record
                sql += " SELECT COUNT(ID) ";
                sql += " FROM [BD_WorkingExtraTimeInfo]";
                sql += " WHERE (ID IS NOT NULL) and DelFlag <> 1 and StaffId = '" + hidId.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT A.*, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM BD_WorkingExtraTimeInfo A";
                sql += " WHERE A.DelFlag <> 1 and A.StaffId = '" + hidId.Value + "' and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

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
                    string ID = Func.ParseString(row["ID"]);
                    string BuildingId = Func.ParseString(row["BuildingId"]);
                    string StaffId = Func.ParseString(row["StaffId"]);
                    string WorkingPlaceId = Func.ParseString(row["WorkingPlace"]);
                    string WorkingHourId = Func.ParseString(row["WorkingHour"]);
                    string JobTypeId = Func.ParseString(row["JobContent"]);
                    string WorkingDate = Func.ParseString(row["WorkingDate"]);
                    string WorkingHourFrom = Func.ParseString(row["WorkingHourFrom"]);
                    string WorkingHourTo = Func.ParseString(row["WorkingHourTo"]);
                    string WorkingMinuteFrom = Func.ParseString(row["WorkingMinuteFrom"]);
                    string WorkingMinuteTo = Func.ParseString(row["WorkingMinuteTo"]);
                    string ExtraHour = Func.ParseString(row["ExtraHour"]);

                    string Comment = Func.ParseString(row["Comment"]);

                    //Func.SetGridTextValue(item, "BuildingId", BuildingId);
                    //Func.SetGridTextValue(item, "StaffId", StaffId);
                    Func.SetGridTextValue(item, "ltrWorkingPlaceId", Func.ToolTipByteLen(WorkingPlaceId, 20));
                    Func.SetGridTextValue(item, "ltrWorkingHourId", Func.ToolTipByteLen(WorkingHourId, 20));
                    Func.SetGridTextValue(item, "ltrJobTypeId", Func.ToolTipByteLen(JobTypeId, 20));
                    Func.SetGridTextValue(item, "ltrWorkingDate", Func.Formatdmyhms(WorkingDate));
                    Func.SetGridTextValue(item, "ltrFrom", WorkingHourFrom + ":" + WorkingMinuteFrom);
                    Func.SetGridTextValue(item, "ltrTo", WorkingHourTo + ":" + WorkingMinuteTo);
                    Func.SetGridTextValue(item, "ltrHour", ExtraHour);

                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

                    Button btnDelete = (Button)item.FindControl("btnDelete");
                    btnDelete.CommandArgument = ID;
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
        /// <summary>
        /// Update
        /// </summary>
        private void DeleteData(string strId)
        {
            BD_WorkingExtraTimeInfoData data = new BD_WorkingExtraTimeInfoData();
            ITransaction tran = factory.GetLoadObject(data, strId);
            Execute(tran);
            if (!HasError)
            {
                //Get Data
                data = (BD_WorkingExtraTimeInfoData)tran.Result;
                data.DelFlag = "1";
                data.ExtraHour = data.ExtraHour.Replace(",", ".");
                tran = factory.GetUpdateObject(data);

                Execute(tran);

                if (!HasError)
                {
                    OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteSuccess, Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage(deleteSuccess);
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), key, postback, true);
                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionUpdateId, deleteUnSuccess, Page.User.Identity.Name);
                    mvMessage.AddError(deleteUnSuccess);
                }
            }
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
            }
            else if (command.Equals("Delete"))
            {
                DeleteData(Func.ParseString(e.CommandArgument));
            }
            ShowData();
        }
    }
}
