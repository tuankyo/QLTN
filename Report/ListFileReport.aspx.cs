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
using System.IO;

namespace Man.Report
{
    public partial class ListFileReport : PageBase
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
        /// List data
        /// </summary>
        private void ShowData()
        {
            if (!Func.IsValid(ListSortExpression))
            {
                ListSortExpression = "Created";
                ListSortDirection = SortDirection.Descending;
            }

            try
            {
                string dataPath = HttpContext.Current.Server.MapPath(@"~\Report\Building\");
                string dataPathPDF = dataPath + Func.ParseString(Session["__BUILDINGID__"]) + @"\" + drpZone.Value;

                if (!Directory.Exists(dataPathPDF))
                {
                    Directory.CreateDirectory(dataPathPDF);
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Name", Type.GetType("System.String"));
                dt.Columns.Add("Path", Type.GetType("System.String"));
                dt.Columns.Add("Created", Type.GetType("System.String"));

                DirectoryInfo di = new DirectoryInfo(dataPathPDF);
                FileInfo[] rgFiles = di.GetFiles("*.*");
                int i = 0;
                foreach (FileInfo fi in rgFiles)
                {
                    DataRow row = dt.NewRow();
                    row["Name"] = fi.Name;
                    row["Path"] = "/" + Func.ParseString(Session["__BUILDINGID__"]) + "/" + drpZone.Value + "/" + fi.Name;
                    row["Created"] = fi.LastWriteTime.ToString("yyyyMMddHHmmss");

                    bool from = true;
                    bool to = true;

                    if (!String.IsNullOrEmpty(txtFromDate.Text))
                    {
                        from = fi.LastWriteTime.ToString("yyyyMMdd").CompareTo(Func.FormatYYYYmmdd(txtFromDate.Text)) >= 1 ? true : false;
                    }

                    if (!String.IsNullOrEmpty(txtToDate.Text))
                    {
                        to = fi.LastWriteTime.ToString("yyyyMMdd").CompareTo(Func.FormatYYYYmmdd(txtToDate.Text)) >= 1 ? false : true;
                    }

                    if (from && to)
                    {
                        dt.Rows.Add(row);
                        i++;
                    }
                }

                pager.Count = i;
                PagedDataSource source = new PagedDataSource();
                source.AllowPaging = true;
                DataView view = dt.DefaultView;


                string SortTb = ListSortExpression + " " + (ListSortDirection == SortDirection.Ascending ? " asc " : " desc ");
                view.Sort = SortTb;

                source.DataSource = view;
                source.CurrentPageIndex = pager.CurrentPageIndex;
                source.PageSize = pager.PageSize;

                rptList.DataSource = source;
                rptList.DataBind();

                //pager.Count = rgFiles.Count();
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
                if (eventTarget == "PopUpEditFlat")
                {
                    ShowData();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopupWidth = 850;
                PopupHeight = 450;
                PopupName = "EditFlat";

                ShowData();
            }
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
                if (string.Compare(command, "SortFileName") == 0)
                {
                    colName = "Name";
                }
                else if (string.Compare(command, "SortCreated") == 0)
                {
                    colName = "Created";
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
            else if ("report".Equals(command))
            {
                string path = (string)e.CommandArgument;
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "", "PopUp('../Report/Building" + path + "'," + PopupWidth + "," + PopupHeight + ",'EditReport', true);", true);
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
                    string Name = Func.ParseString(row["Name"]);
                    string Path = Func.ParseString(row["Path"]);
                    string Created = Func.Formatdmyhms(row["Created"]);

                    Func.SetGridLinkValue(item, "ltrName", Name);
                    Func.SetGridTextValue(item, "ltrCreated", Created);

                    LinkButton tmp = (LinkButton)item.FindControl("ltrName");
                    tmp.CommandName = "report";
                    tmp.CommandArgument = Path;
                    //tmp.Text = Path;
                    //tmp.PostBackUrl = "../Payment/DataTmp/" + Path;
                }
                else if (item.ItemType == ListItemType.Header)
                {
                    //((CheckBox)e.Item.FindControl("chkSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Item.FindControl("chkSelectAll")).ClientID + "')");

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

                        if (colName.EndsWith("FileName"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkName");
                            link.Text = "Tên File" + img;
                        }
                        else if (colName.EndsWith("Created"))
                        {
                            LinkButton link = (LinkButton)item.FindControl("lnkCreated");
                            link.Text = "Ngày tạo" + img;
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
        /// 検索ボタン押下処理

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopupWidth = 850;
            PopupHeight = 450;
            ShowData();
        }
    }
}
