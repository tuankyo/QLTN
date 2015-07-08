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

namespace Man.Building.TarrifsElecWater
{
    public partial class BD_TarrifsElecWaterList : PageBase
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
        private string popup = "PopupTarrifsElecWaterEdit";
        private string editPageName = "BD_TarrifsElecWaterEdit";
        private string feeGroupPageName = "BD_FeeGroup";

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            SqlDatabase db = new SqlDatabase();
            string sql = string.Empty;
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "A.FeeGroup, IndexFrom";
                ListSortDirection = SortDirection.Ascending;
            }
            try
            {
                DbHelper.FillList(drpFeeGroup, "Select * from BD_FeeGroup where delFlag = 0 and FeeGroup = '" + hidType.Value + "' and BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'", "Name", "id");

                //Đếm số lượng record
                sql += " SELECT COUNT(A.ID) ";
                sql += " FROM [BD_TarrifsElecWater] A, BD_FeeGroup B ";
                sql += " WHERE A.ID IS NOT NULL and A.DelFlag <> 1 and A.FeeGroup = B.id and B.FeeGroup = '" + hidType.Value + "' and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

                int count = db.ExecuteCount(sql);
                sql = string.Empty;
                string sort = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");

                //Xuất ra toàn bộ nội dung theo Trang
                sql += " SELECT A.*, B.Name as FeeGroupName ,ROW_NUMBER() OVER(ORDER BY " + sort + ") as RowNum ";
                sql += " FROM [BD_TarrifsElecWater] A, BD_FeeGroup B ";
                sql += " WHERE A.ID IS NOT NULL and A.DelFlag <> 1 and A.FeeGroup = B.id and B.FeeGroup = '" + hidType.Value + "' and A.BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "'";

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
            hidType.Value = Func.ParseString(Request["Type"]);
            if ("1".Equals(hidType.Value))
            {
                ltrPage.Text = "Kế toán > Biểu phí > Điện";
            }
            else
            {
                ltrPage.Text = "Kế toán > Biểu phí > Nước";
            }
            if (!IsPostBack)
            {
                PopupWidth = 600;
                PopupHeight = 450;
                ShowData();

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
                    string ID = Func.ParseString(row["id"]);
                    string Name = Func.ParseString(row["Name"]);
                    string IndexFrom = Func.ParseString(row["IndexFrom"]);
                    string Comment = Func.ParseString(row["Comment"]);
                    string PriceVND = Func.ParseString(row["PriceVND"]);
                    string PriceUSD = Func.ParseString(row["PriceUSD"]);

                    //string VAT = Func.ParseString(row["VAT"]);
                    //string OtherFee01 = Func.ParseString(row["OtherFee01"]);
                    //string OtherFee02 = Func.ParseString(row["OtherFee02"]);

                    string FeeGroupName = Func.ParseString(row["FeeGroupName"]);
                    string FeeGroup = Func.ParseString(row["FeeGroup"]);

                    Func.SetGridLinkValue(item, "btnEdit", ID);
                    Func.SetGridTextValue(item, "ltrName", Name);
                    Func.SetGridTextValue(item, "ltrIndexFrom", IndexFrom);
                    Func.SetGridTextValue(item, "ltrComment", Func.ToolTipByteLen(Comment, 20));
                    Func.SetGridTextValue(item, "ltrPriceVND", Func.FormatCurrency(PriceVND));
                    Func.SetGridTextValue(item, "ltrPriceUSD", PriceUSD);

                    //Func.SetGridTextValue(item, "ltrOtherFee01", OtherFee01);
                    //Func.SetGridTextValue(item, "ltrOtherFee02", OtherFee02);
                    //Func.SetGridTextValue(item, "ltrVAT", VAT);

                    Func.SetGridTextValue(item, "ltrGroup", FeeGroupName);

                    PopupWidth = 600;
                    PopupHeight = 650;
                    LinkPopup((LinkButton)item.FindControl("btnEdit"), editPageName + ".aspx?feegroup="+ FeeGroup +"&Action=Edit&Id=" + ID);

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
            PopupHeight = 500;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + editPageName + ".aspx?Action=Register&FeeGroup=" + drpFeeGroup.SelectedValue + "'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddFeeGroup_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 500;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + feeGroupPageName + ".aspx?Action=Register&FeeGroup=" + hidType.Value + "'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
        protected void btnUpdateFeeGroup_Click(object sender, EventArgs e)
        {
            PopupWidth = 600;
            PopupHeight = 500;
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('" + feeGroupPageName + ".aspx?id="+ drpFeeGroup.SelectedValue +"&Action=Edit&FeeGroup=" + hidType.Value + "'," + PopupWidth + "," + PopupHeight + ",'" + editPageName + "', true);", true);
        }
    }
}
