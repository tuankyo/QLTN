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
    public partial class CcContact : PageBase
    {
        //private const int PopupWidth = 850;
        //private const int PopupHeight = 550;


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string contacts = "";
            foreach (ListItem li in chkContactList.Items)
            {
                if (li.Selected)
                {
                    contacts += ";" + li.Value;
                }
            }

            if (!String.IsNullOrEmpty(contacts))
            {
                if ("cc".Equals(hidType.Value))
                {
                    Response.Write("<script language=javascript>window.opener.document.getElementById('txtToCC').value += ';" + contacts.Substring(1) + "';window.close();</script>");
                }
                else if ("bcc".Equals(hidType.Value))
                {
                    Response.Write("<script language=javascript>window.opener.document.getElementById('txtToBCC').value += ';" + contacts.Substring(1) + "';window.close();</script>");
                }
            }
        }

        /// <summary>
        /// List data
        /// </summary>
        private void ShowData()
        {
            DbHelper.FillList(chkContactList, "Select A.UserName + '(' + A.FullName + ')' FullName, B.Contact from vw_aspnet_MembershipUsers A, AddressBook B where B.Contact = A.UserName and B.UserName = '" + Page.User.Identity.Name + "'", "FullName", "Contact");
        }

        /// <summary>
        /// Init values
        /// </summary>
        protected override void DoInit()
        {
            //Page.User.Identity.Name = Func.ParseString(Request["UserName"]);
            hidType.Value = Func.ParseString(Request["type"]);
        }

        protected override void DoPost()
        {
            //Page.User.Identity.Name = Func.ParseString(Request["UserName"]);
            hidType.Value = Func.ParseString(Request["type"]);

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
            //Page.User.Identity.Name = Func.ParseString(Request["UserName"]);
            hidType.Value = Func.ParseString(Request["type"]);

            if (!IsPostBack)
            {
                //drpUserName
                AutoCompleteExtender1.ContextKey = Func.ParseString(Session["__BUILDINGID__"]);

                DbHelper.FillList(chkContactList, "Select B.Contact + '(' + A.FullName + ')' as FullName, B.Contact from vw_aspnet_MembershipUsers A, AddressBook B where B.Contact = A.UserName and B.UserName = '" + Page.User.Identity.Name + "'", "FullName", "Contact");
                //DbHelper.FillList(drpContact, "Select FullName from vw_aspnet_MembershipUsers A", "FullName", "FullName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtContact, "Contact: cần nhập thông tin");
            if (!mvMessage.IsValid)
                return;

            string[] contacts = txtContact.Text.Split('(');

            if (contacts.Length == 1)
            {
                mvMessage.AddError("Hãy tìm kiếm đúng và chọn trong danh sách");
                return;
            }

            int count = DbHelper.GetCount("Select count(*) from AddressBook where UserName = '" + Page.User.Identity.Name + "' and Contact = '" + contacts[0] + "'");
            if (count > 0)
            {
                mvMessage.AddError("Đã tồn tại Contact này");
                return;
            }
            count = DbHelper.GetCount("Select count(*) from vw_aspnet_MembershipUsers where BuildingId = '" + Func.ParseString(Session["__BUILDINGID__"]) + "' and UserName = '" + contacts[0] + "'");
            if (count == 0)
            {
                mvMessage.AddError("User đã chọn không tồn tại trong hệ thống!");
                return;
            }

            AddressBookData dataM = new AddressBookData();
            ITransaction tranM = factory.GetInsertObject(dataM);

            dataM.UserName = Page.User.Identity.Name;
            dataM.Contact = contacts[0];
            dataM.FullName = contacts[1].Substring(0, contacts[1].Length - 1);
            Execute(tranM);

            if (!HasError)
            {
                OperationLogger.WriteInfo(Constants.LogOperationAlbumId, Constants.LogActionInsertId, "Tạo Mới Thông Tin Thành Công", Page.User.Identity.Name);

                mvMessage.SetCompleteMessage("Thực Hiện Thành Công");
            }
            else
            {
                OperationLogger.WriteError(Constants.LogOperationAlbumId, Constants.LogActionInsertId, "Tạo Mới Thông Tin Phát Sinh Lỗi", Page.User.Identity.Name);
                mvMessage.AddError("Tạo Mới Thông Tin Phát Sinh Lỗi");
            }
            ShowData();
        }
    }
}
