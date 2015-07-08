using System;
using System.Globalization;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Man.Utils;

namespace Man
{
    public class CustomGridView : GridView
    {
        public bool IsInit
        {
            get { return (bool?)ViewState["IsInit"] ?? false; }
            set { ViewState["IsInit"] = value; }
        }
        
        public bool UseCustomPager
        {
            get { return (bool?)ViewState["UseCustomPager"] ?? false; }
            set { ViewState["UseCustomPager"] = value; }          
        }

        public bool IsCollapseAll
        {
            get { return (bool?)ViewState["ChildCollapse"] ?? false; }
            set { ViewState["ChildCollapse"] = value; }
        }

        
        public SortDirection ListSortDirection
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

        public string ListSortExpression
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

        public int VirtualItemCount
        {
            get
            {
                if (ViewState["pgv_vitemcount"] == null)
                    ViewState["pgv_vitemcount"] = -1;
                return Convert.ToInt32(ViewState["pgv_vitemcount"]);
            }
            set { ViewState["pgv_vitemcount"] = value; }
        }

        private int CurrentPageIndex
        {
            get
            {
                if (ViewState["pgv_pageindex"] == null)
                    ViewState["pgv_pageindex"] = 0;
                return Convert.ToInt32(ViewState["pgv_pageindex"]);
            }
            set
            {
                ViewState["pgv_pageindex"] = value;
            }
        }

        public override object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;
                // we store the page index here so we dont lost it in databind
                CurrentPageIndex = PageIndex;
            }
        }


        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (UseCustomPager)
            {
                CreateCustomPager(row, columnSpan, pagedDataSource);
             //   base.InitializePager(row, columnSpan, pagedDataSource);
            }
            else
                base.InitializePager(row, columnSpan, pagedDataSource);
        }

        protected virtual void CreateCustomPager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            pagedDataSource.AllowCustomPaging = true;
            pagedDataSource.VirtualCount = VirtualItemCount;
            pagedDataSource.CurrentPageIndex = CurrentPageIndex;
            PageIndex = CurrentPageIndex;
            
            int pageCount = pagedDataSource.PageCount;
            int pageIndex = pagedDataSource.CurrentPageIndex + 1;
            int pageButtonCount = PagerSettings.PageButtonCount;

            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            if (columnSpan > 1) cell.ColumnSpan = columnSpan;

            //Add summary text
            HtmlGenericControl summaryArear = new HtmlGenericControl("span");
            summaryArear.Attributes.Add("class", "pagersummary");

            int currenItemMin = pagedDataSource.CurrentPageIndex * pagedDataSource.PageSize + 1;
            int currentItemMax = pagedDataSource.CurrentPageIndex * pagedDataSource.PageSize + pagedDataSource.PageSize ;

            string strSummaryText = pagedDataSource.DataSourceCount.ToString() + " Tập tin:" + currenItemMin.ToString() + "-" + currentItemMax.ToString() + " Đang hiển thị.";

            //Create container
            Label lblSummary = new Label();
            lblSummary.Text = strSummaryText;
            summaryArear.Controls.Add(lblSummary);
            
            //Create pager control
            HtmlGenericControl pager = new HtmlGenericControl("div");
            pager.Attributes["class"] = "pagination";
            cell.Controls.Add(pager);

            //Create pagesize change control            
            DropDownList ddlPageSize = new DropDownList();

            Func.SetPageSize(ddlPageSize);
            
            //ddlPageSize.SelectedIndexChanged += new EventHandler(ddlPageSize_SelectedIndexChanged);
            
            //ddlPageSize.AutoPostBack = true;

            //Create container
            HtmlGenericControl pageSizeChangeArear = new HtmlGenericControl("span");
            pageSizeChangeArear.Attributes.Add("class", "pagersize");
            pageSizeChangeArear.Controls.Add((Control)ddlPageSize);

            //Add summary to pager control
            pager.Controls.Add(summaryArear);
            //pager.Controls.Add(pageSizeChangeArear);

                if (pageCount > 1)
                {
                int min = pageIndex - pageButtonCount;
                int max = pageIndex + pageButtonCount;

                if (max > pageCount)
                    min -= max - pageCount;
                else if (min < 1)
                    max += 1 - min;

                // Create "previous" button
                Control page = pageIndex > 1
                                ? BuildLinkButton(CurrentPageIndex - 1, PagerSettings.PreviousPageText, "Page", "Prev")
                                : BuildSpan(PagerSettings.PreviousPageText, "disabled");
                pager.Controls.Add(page);

                // Create page buttons
                bool needDiv = false;
                for (int i = 1; i <= pageCount; i++)
                {
                    if (i <= 2 || i > pageCount - 2 || (min <= i && i <= max))
                    {
                        string text = i.ToString(NumberFormatInfo.InvariantInfo);
                        page = i == pageIndex
                                ? BuildSpan(text, "current")
                                : BuildLinkButton(i - 1, text, "Page", text);
                        pager.Controls.Add(page);
                        needDiv = true;
                    }
                    else if (needDiv)
                    {
                        page = BuildSpan("&hellip;", null);
                        pager.Controls.Add(page);
                        needDiv = false;
                    }
                }

                // Create "next" button
                page = pageIndex < pageCount
                        ? BuildLinkButton(CurrentPageIndex + 1, PagerSettings.NextPageText, "Page", "Next")
                        : BuildSpan(PagerSettings.NextPageText, "disabled");
                pager.Controls.Add(page);
            }
        }

        private Control BuildLinkButton(int pageIndex, string text, string commandName, string commandArgument)
        {
            PagerLinkButton link = new PagerLinkButton(this);
            link.Text = text;
            link.EnableCallback(ParentBuildCallbackArgument(pageIndex));
            link.CommandName = commandName;
            link.CommandArgument = commandArgument;
            return link;
        }

        private Control BuildSpan(string text, string cssClass)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            if (!String.IsNullOrEmpty(cssClass)) span.Attributes["class"] = cssClass;
            span.InnerHtml = text;
            return span;
        }

        private string ParentBuildCallbackArgument(int pageIndex)
        {
            MethodInfo m =
                typeof(GridView).GetMethod("BuildCallbackArgument", BindingFlags.NonPublic | BindingFlags.Instance, null,
                                            new Type[] { typeof(int) }, null);
            return (string)m.Invoke(this, new object[] { pageIndex });
        }

        protected override void OnSorting(GridViewSortEventArgs e)
        {
          
            //Sets sort expression
            ListSortExpression = e.SortExpression;

            //Sets sort direction
            if (e.SortExpression == ListSortExpression)
            {
                ListSortDirection = (ListSortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            }
            else
            {
                ListSortDirection = SortDirection.Descending;
            }
            base.OnSorting(e);
        }

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            if (e.Row != null && e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (cell.HasControls())
                    {
                        LinkButton button = cell.Controls[0] as LinkButton;
                        if (button != null)
                        {
                            Image image = new Image();
                            image.SkinID = "SpaceImage";
                            if (ListSortExpression == button.CommandArgument)
                            {
                                if (ListSortDirection == SortDirection.Ascending)
                                    image.SkinID = "ASCImage";
                                else
                                    image.SkinID = "DESCImage";
                            }
                            cell.Controls.Add(image);
                        }
                    }
                }
            }
            base.OnRowCreated(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            
            base.Render(writer);
        }
        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            PageIndex = e.NewPageIndex;
            base.OnPageIndexChanging(e);
        }


        //void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        //{        
        //        this.PageSize = int.Parse(((DropDownList)sender).SelectedValue);
        //        this.Page.Response.Write("<script language='javascript'> __doPostBack('POPUPEDITAGENCY','');</script>");
        //}
    }
}