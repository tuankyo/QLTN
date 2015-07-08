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
using System.Text.RegularExpressions;

namespace Man
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private string username
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            username = (Request["uid"] != null) ? Request["uid"] : string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MembershipUser membership;
            try
            {
                if (Membership.ValidateUser(username, txtOldPass.Text))
                {
                    string pattern = @"(?=^.{6,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
                    //định nghĩa những substring abc,ab,b
                    Regex myRegex = new Regex(pattern);
                    Match m = myRegex.Match(txtNewPass.Text);
                    if (m.Success)
                    {

                        if (txtNewPass.Text.Length > 0)
                        {
                            if (txtNewPassConfirm.Text == txtNewPass.Text)
                            {
                                try
                                {
                                    membership = Membership.GetUser(username);
                                    if (membership.ChangePassword(txtOldPass.Text, txtNewPass.Text))
                                    {
                                        mvMessage.SetCompleteMessage("Mật khẩu đã được đổi.");
                                    }
                                    else
                                    {
                                        mvMessage.AddError("Không thể thay đổi.");
                                    }
                                }
                                catch
                                {
                                    mvMessage.AddError("Lỗi phát sinh.");
                                }
                            }
                            else
                            {
                                mvMessage.AddError("Mật Khẩu mới và Mật Khẩu Xác Nhận không giống.");
                            }
                        }
                        else
                        {
                            mvMessage.AddError("Mật Khẩu không đúng.");
                        }
                    }
                    else
                    {
                        mvMessage.AddError("Mật Khẩu mới phải có: ít nhất 6 ký tự.");
                        mvMessage.AddError("Mật Khẩu mới phải có: ít nhất 1 ký tự viết hoa.");
                        mvMessage.AddError("Mật Khẩu mới phải có: ít nhất 1 ký tự viết thường.");
                        mvMessage.AddError("Mật Khẩu mới phải có: ít nhất 1 con số.");
                    }
                }
                else
                {
                    mvMessage.AddError("Mật Khẩu cũ không đúng.");
                }
            }
            catch (Exception ex)
            {
                mvMessage.AddError(ex.Message);
            }
        }
    }
}
