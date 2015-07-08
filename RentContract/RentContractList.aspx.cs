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

namespace Man.RentContract
{
    public partial class RentContractList : PageBase
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

        private string popup = "PopupRentContractEdit";
        private string editPageName = "RentContractEdit";
        private string RoomPageName = "RC_Room";
        private string DocumentPageName = "RC_Document";
        private string RC_HandoverPage = "RC_Handover";
        private string RC_IndemnifyPage = "RC_Indemnify";

        
        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                    ListSortExpression = "Modified";
                    ListSortDirection = SortDirection.Descending;
            }
            try
            {
                //Đếm số lượng record
                sql += " Select COUNT(ContractID) ";
                sql += " FROM RentContract";
                sql += " WHERE (ContractID IS NOT NULL) and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '"+ hidID.Value +"'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " Select *, ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM RentContract";
                sql += " WHERE (ContractID IS NOT NULL) and DelFlag <> 1 and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and CustomerId = '" + hidID.Value + "'";

                //Phân trang
                sql = " Select * FROM (" + sql + ") AS TMP ";
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

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            hidID.Value = Func.ParseString(Request["id"]);

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

        protected void Page_Load(object sender, EventArgs e)
        {
            hidID.Value = Func.ParseString(Request["id"]);

            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                ShowData();

                CustomerData data = new CustomerData();
                ITransaction tran = factory.GetLoadObject(data, hidID.Value);
                Execute(tran);
                if (!HasError)
                {
                    //Get Data
                    data = (CustomerData)tran.Result;
                    lblCustomerId.Text = data.CustomerId;
                    lblName.Text = data.Name;
                    lblComment.Text = data.Comment;
                }
            }
        }

        /// </summary> Chọn trang
        /// <param name="source"></param>
        /// <param name="args"></param>
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

                    string ContractId = Func.ParseString(row["ContractId"]);
                    //string CustomerId = Func.ParseString(row["CustomerId"]);
                    string ContractDate = Func.ParseString(row["ContractDate"]);
                    string ContractEndDate = Func.ParseString(row["ContractEndDate"]);
                    string ReceiveDate = Func.ParseString(row["ReceiveDate"]);
                    string StaffMount = Func.ParseString(row["StaffMount"]);
                    string Comment = Func.ParseString(row["Comment"]);

                    Func.SetGridLinkValue(item, "btnEdit", ContractId);
                    //Func.SetGridTextValue(item, "ltrCustomerId", CustomerId);
                    Func.SetGridTextValue(item, "ltrContractDate", Func.FormatDMY(ContractDate));
                    Func.SetGridTextValue(item, "ltrContractEndDate", Func.FormatDMY(ContractEndDate));
                    Func.SetGridTextValue(item, "ltrReceiveDate", Func.FormatDMY(ReceiveDate));
                    //Func.SetGridTextValue(item, "ltrStaffMount", StaffMount);
                    //Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));

                    PopupWidth = 1050;
                    PopupHeight = 600;
                    LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?Action=Edit&Id=" + ContractId);
                    ButtonPopup((Button)item.FindControl("btnRoom"), RoomPageName + ".aspx?Action=Edit&Id=" + ContractId);
                    ButtonPopup((Button)item.FindControl("btnHandover"), RC_HandoverPage + ".aspx?Action=Edit&Id=" + ContractId);
                    ButtonPopup((Button)item.FindControl("btnIndemnify"), RC_IndemnifyPage + ".aspx?Action=Edit&Id=" + ContractId);
                    ButtonPopup((Button)item.FindControl("btnDoc"), DocumentPageName + ".aspx?Action=Edit&DocType=5&Id=" + ContractId);

                    string ModifiedBy = Func.ParseString(row["ModifiedBy"].ToString().Trim());
                    string Modified = Func.ParseString(row["Modified"].ToString().Trim());
                    Func.SetGridTextValue(item, "ltrModifiedBy", ModifiedBy);
                    Func.SetGridTextValue(item, "ltrModified", Func.Formatdmyhms(Modified));

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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 450;
            ShowData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 600;

            mvMessage.CheckRequired(txtAutoId, "Hãy tạo ID trước khi Thêm mới, chọn nút Cấp Phát ID");
            if (!mvMessage.IsValid)
            {
                return;
            }
            int count = DbHelper.GetCount("Select count(*) from RentContract Where ContractId = '" + txtAutoId.Text.Trim() + "'");
            if (count >= 1)
            {
                mvMessage.AddError("ID đã tồn tại, hãy cấp phát lại");
                return;
            }
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + editPageName + ".aspx?Action=Register&ID=" + txtAutoId.Text.Trim() + "&CustomerId="+ hidID.Value +"'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAutoId_Click(object sender, EventArgs e)
        {
            RentContractData data = new RentContractData();

            string prefix = Func.ParseString(Session["__BUILDINGID__"]) + "HD";
            if (String.IsNullOrEmpty(prefix))
            {
                mvMessage.AddError("Lỗi xảy ra, hãy bấm F5 hoặc liên hệ Admin");
                return;
            }
            int length = 10;
            string tmp = String.Format("", length);

            string sql = "SELECT max(maxid) from (SELECT SUBSTRING(ContractId, " + (prefix.Length + 1) + ", " + length + ") as maxid FROM RentContract) as tmp WHERE maxid < '100'";


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
                sql = "SELECT count(*) from RentContract WHERE ContractId = '" + tmpKey + "'";
                if (Convert.ToInt32(DbHelper.GetScalar(sql)) != 1)
                {
                    keyFlg = false;
                }
                else
                {
                    key--;
                }
            }
            txtAutoId.Text = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }
    }
}
