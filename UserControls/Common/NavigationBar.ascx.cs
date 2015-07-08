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

using System.Xml;

namespace Man.UserControls.Common
{
    public partial class NavigationBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void walkTree(SiteMapNode pNode)
        {
            string[] siteLevel = new string[10];
            //Xet chinh nut dang xet

            if (Session["LastValue"] == null) return;

            if (pNode.Title == Session["LastValue"].ToString())
                {
                    
                        siteLevel[0] = pNode.Title;
                        SiteMapNode temp;
                        temp = pNode;
                        int i = 1;
                        while (temp.ParentNode != null)
                        {
                            siteLevel[i] = temp.ParentNode.Title;
                            temp = temp.ParentNode;
                            i++;
                        }

                        LabelBarNavigator.Text = String.Empty;
                        string BeginSpanTab = "'<span style=\"NavigatorSeperator\"> ";
                        string EndSpanTab = "</span> ";
                        string Seperator = "»";
                        for (i = 9; i >= 0; i--)
                            if (siteLevel[i] != null)
                                LabelBarNavigator.Text += siteLevel[i] + BeginSpanTab + Seperator + EndSpanTab;

                        if (LabelBarNavigator.Text != String.Empty)
                        {
                            int total = BeginSpanTab.Length + EndSpanTab.Length + Seperator.Length;
                            LabelBarNavigator.Text = LabelBarNavigator.Text.Remove(LabelBarNavigator.Text.Length - total, total);
                        }

                }

            //Duyet toan bo nut con
            if (pNode.HasChildNodes)
            foreach (SiteMapNode child in pNode.ChildNodes)
            {
                walkTree(child);
            }
        }

        protected void ProcessTree(string[] siteLevel)
        {
            
        }

        protected override object SaveViewState()
        {
            if (Session["LastValue"] != null)
            {
                string[] siteLevel = new string[10];
                SiteMapNode cNode = SiteMap.RootNode;

                walkTree(cNode);
              
                
                
            }
            return base.SaveViewState();
        }

    }
}