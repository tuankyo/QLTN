using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Reflection;
namespace Man
{

    public class PagerPageChangedEventArgs : EventArgs
    {
        private int newPageIndex;

        public PagerPageChangedEventArgs(int newPageIndex)
        {
            this.newPageIndex = newPageIndex;
        }
        public int NewPageIndex
        {
            get { return newPageIndex; }
        }
    }
    public delegate void PagerPageChangedEventHandler(object source, PagerPageChangedEventArgs args);
    /// <summary>
    /// Summary description for Pager.
    /// </summary>
    [DefaultEvent("PageIndexChanged")]
    [ToolboxData("<{0}:Pager runat=\"server\" />")]
    public class Pager : WebControl, INamingContainer
    {

        private static readonly object EventPageIndexChanged = new object();

        private int pageSize = 0;
        private int currentPageIndex = 0;
        private int count;

        private const string PreviousPageText = "<<";
        private const string NextPageText = ">>";
        private const int PageButtonCount = 5;

        [Bindable(false), Category("Appearance"), DefaultValue(0)]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        [Bindable(false), Category("Appearance"), DefaultValue(10)]
        public int PageSize
        {
            get { return pageSize <= 0 ? 20 : pageSize; }
            set
            {
                if (value <= 0)
                    value = 20;
                pageSize = value;
            }
        }
        [Bindable(false), Category("Appearance"), DefaultValue(0)]
        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set
            {
                if (value >= this.PageCount) value = this.PageCount - 1;
                if (value < 0) value = 0;
                currentPageIndex = value;
            }
        }
        [Bindable(false), Category("Appearance"), DefaultValue(0)]
        public int FirstIndexInPage
        {
            get { return this.currentPageIndex * this.pageSize; }
        }
        [Bindable(false), Category("Appearance"), DefaultValue(0)]
        public bool IsFirstPage
        {
            get { return this.CurrentPageIndex == 0; }
        }
        [Bindable(false), Category("Appearance"), DefaultValue(0)]
        public bool IsLastPage
        {
            get { return (this.currentPageIndex == this.PageCount - 1); }
        }
        [Bindable(false), Category("Appearance"), DefaultValue(0)]
        public int PageCount
        {
            get
            {
                return (this.count + this.pageSize - 1) / this.pageSize;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            pageSize = 20;
        }
        protected override void CreateChildControls()
        {
            this.CreateControlHierarchy();
        }
        protected virtual void CreateControlHierarchy()
        {
            int pageButtonCount = PageButtonCount;
            int pageCount = PageCount;
            int pageIndex = currentPageIndex;

            ControlCollection controls = this.Controls;
            controls.Clear();

            if (pageCount > 0)
            {

                DropDownList drp = new DropDownList();
                drp.ID = "drpPageSize";
                drp.EnableViewState = true;
                drp.Items.Add(new ListItem("10", "10"));
                drp.Items.Add(new ListItem("20", "20"));
                drp.Items.Add(new ListItem("30", "30"));
                drp.Items.Add(new ListItem("50", "50"));
                drp.Items.Add(new ListItem("100", "100"));
                drp.Items.Add(new ListItem("200", "200"));
                drp.Items.Add(new ListItem("500", "500"));
                drp.Items.Add(new ListItem("1000", "1000"));

                pageSize = GetPageSize(drp.ClientID);
                if (drp.Items.FindByValue(pageSize.ToString()) != null)
                {
                    drp.Items.FindByValue(pageSize.ToString()).Selected = true;
                }

                int begin = (PageCount == 0) ? 0 : FirstIndexInPage + 1;
                int end = Math.Min(FirstIndexInPage + pageSize, this.count);
                string summary = string.Format("{0} Tập tin:{1}-{2} Đang hiển thị", count, begin, end);



                Table table = new Table();
                TableRow row = new TableRow();
                TableCell col1 = new TableCell();
                TableCell col2 = new TableCell();
                TableCell col3 = new TableCell();
                table.CssClass = "Pager";
                col1.CssClass = "Left";
                col2.CssClass = "Center";
                col3.CssClass = "Right";

                Table tablePageSize = new Table();
                TableRow row1 = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.Controls.Add(new LiteralControl("Số Tập Tin Hiển Thị/Trang:"));
                cell1.CssClass = "PageSizeText";
                cell2.Controls.Add(drp);
                row1.Controls.Add(cell1);
                row1.Controls.Add(cell2);
                tablePageSize.Controls.Add(row1);




                HtmlGenericControl pager = new HtmlGenericControl("div");
                pager.Attributes["class"] = "pagination";

                col1.Controls.Add(new LiteralControl(summary));
                col2.Controls.Add(pager);
                col3.Controls.Add(tablePageSize);

                row.Cells.Add(col1);
                row.Cells.Add(col2);
                row.Cells.Add(col3);
                table.Rows.Add(row);
                controls.Add(table);

                int min = pageIndex - pageButtonCount;
                int max = pageIndex + pageButtonCount;

                if (max > pageCount)
                    min -= max - pageCount;
                else if (min < 1)
                    max += 1 - min;

                Control page = pageIndex > 0
                              ? BuildLinkButton(currentPageIndex - 1, PreviousPageText, "Page", (currentPageIndex - 1).ToString())
                              : BuildSpan(PreviousPageText, "disabled");
                pager.Controls.Add(page);

                bool needDiv = false;
                for (int i = 1; i <= pageCount; i++)
                {
                    if (i <= 2 || i > pageCount - 2 || (min <= i && i <= max))
                    {
                        //  string text = i.ToString(NumberFormatInfo.InvariantInfo);
                        string text = (i).ToString();
                        page = i == pageIndex + 1
                                ? BuildSpan(text, "current")
                                : BuildLinkButton(i - 1, text, "Page", (i - 1).ToString());
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


                page = pageIndex + 1 < pageCount
                       ? BuildLinkButton(currentPageIndex + 1, NextPageText, "Page", (currentPageIndex + 1).ToString())
                       : BuildSpan(NextPageText, "disabled");
                pager.Controls.Add(page);
            }
            else
            {
                Table table = new Table();
                TableRow row = new TableRow();
                TableCell col1 = new TableCell();
                table.CssClass = "Pager";
                col1.CssClass = "Left";
                col1.Controls.Add(new LiteralControl("Dữ liệu chưa Thêm Mới"));
                row.Cells.Add(col1);
                table.Rows.Add(row);
                controls.Add(table);
            }
        }
        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            CommandEventArgs e = args as CommandEventArgs;
            bool handle = false;

            if (e != null)
            {
                if (e.CommandName.Equals("Page"))
                {
                    int index = 0;
                    try { index = int.Parse(e.CommandArgument.ToString()); }
                    catch { }
                    OnPageIndexChanged(this, new PagerPageChangedEventArgs(index));
                    handle = true;
                }
            }
            return handle;
        }
        protected virtual void OnPageIndexChanged(object source, PagerPageChangedEventArgs args)
        {
            PagerPageChangedEventHandler onPageIndexChangedHandler = (PagerPageChangedEventHandler)Events[EventPageIndexChanged];
            if (onPageIndexChangedHandler != null)
            {
                this.currentPageIndex = args.NewPageIndex;
                onPageIndexChangedHandler(this, args);
            }
        }
        [Category("Action"), Description("Raised when a CommandEvent occurs within an item.")]
        public event PagerPageChangedEventHandler PageIndexChanged
        {
            add
            {
                Events.AddHandler(EventPageIndexChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventPageIndexChanged, value);
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.CreateControlHierarchy();
        }
        protected override object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object count = this.count;
            object pageSize = this.pageSize;
            object currentPageIndex = this.currentPageIndex;
            //object firstImageUrl = this.firstImageUrl;
            //object prevImageUrl = this.prevImageUrl;
            //object nextImageUrl = this.nextImageUrl;
            //object lastImageUrl = this.lastImageUrl;
            //object firstImageUrlDisable = this.firstImageUrlDisable;
            //object prevImageUrlDisable = this.prevImageUrlDisable;
            //object nextImageUrlDisable = this.nextImageUrlDisable;
            //object lastImageUrlDisable = this.lastImageUrlDisable;
            object[] myState = new object[] { baseState, count, pageSize,
																				currentPageIndex 
																				};
            return myState;
        }
        protected override void LoadViewState(object savedState)
        {
            object[] myStates = (object[])savedState;
            if (myStates[0] != null)
                base.LoadViewState(myStates[0]);
            if (myStates[1] != null)
                count = (int)myStates[1];
            if (myStates[2] != null)
                pageSize = (int)myStates[2];
            if (myStates[3] != null)
                currentPageIndex = (int)myStates[3];
        }

        private Control BuildLinkButton(int pageIndex, string text, string commandName, string commandArgument)
        {
            LinkButton link = new LinkButton();
            link.Text = text;
            link.CommandName = commandName;
            link.CommandArgument = commandArgument;
            link.CausesValidation = false;
            return link;
        }

        private Control BuildSpan(string text, string cssClass)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            if (!String.IsNullOrEmpty(cssClass)) span.Attributes["class"] = cssClass;
            span.InnerHtml = text;
            return span;
        }

        private int GetPageSize(string id)
        {
              string request =  this.Page.Request[this.ClientID.Replace("_","$") + "$" + id];
              if (request != null)
              {
                  return int.Parse(request);
              }
              return this.PageSize;
        }

    }
}
