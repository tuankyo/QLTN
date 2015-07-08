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

using BusinessObjects;
using Gnt.Transaction;
using Gnt.Data.DBCommand;
using Gnt.Data;
using Man.Utils;

namespace Man.User
{
    public partial class AdminEditUser : PageBase
    {
        private string _userName = string.Empty;
        private string _action = string.Empty;

        string UserName
        {
            get { return _userName; }
            set
            {
                if (value != null)
                {
                    _userName = value;
                }
                else
                {
                    _userName = string.Empty;
                }
            }
        }
        string Action
        {
            get { return _action; }
            set
            {
                if (value != null)
                {
                    _action = value;
                }
                else
                {
                    _action = string.Empty;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserName = Request["UserName"];
            Action = Request["Action"];


            if (!IsPostBack)
            {
                if (Action == "Edit")
                {
                    lblHeader.Text = "Thông Tin Người Dùng";
                    btnRegister.Text = "Cập Nhật";
                    btnRegister.CommandName = "Edit";
                    ltrNotice.Visible = false;
                    trPassReset.Visible = true;
                    trPass.Visible = false;
                    trPassConfirm.Visible = false;
                    btnReset.Attributes.Add("onclick", "return confirm('Phát sinh lại Mật Khẩu');");

                    lblOldPassword.Text = "Mật Khẩu Mới";
                    lblPassword.Text = "Xác Nhận Mật Khẩu";

                    if (!IsPostBack)
                    {
                        txtUserName.Text = UserName;
                        txtUserName.ReadOnly = true;

                        aspnet_MembershipData data = new aspnet_MembershipData();
                        Criteria cri = new Criteria();
                        MembershipUser user = Membership.GetUser(UserName);
                        cri.And("UserId", "=", user.ProviderUserKey.ToString());
                        ITransaction tran = factory.GetSearchObject(data, cri);
                        Execute(tran);

                        if (tran.Result != null)
                            if (((System.Collections.ArrayList)tran.Result).Count > 0)
                                data = (aspnet_MembershipData)(((System.Collections.ArrayList)tran.Result)[0]);

                        txtFullName.Text = data.FullName;


                        txtEmail.Text = user.Email;

                        //ddlRolesList.DataSource = Roles.GetAllRoles();
                        //ddlRolesList.DataBind();
                        DbHelper.FillList(ddlRolesList, "Select * from Mst_Roles  Where delFlag = '0'", "RoleName", "RoleId");

                        DbHelper.FillList(drpBuilding, "Select Name as BD_Name, BuildingId from Mst_Building", "BD_Name", "BuildingId");

                        //if (data.SaleUserFlag == "1")
                        //    cbManagement.Checked = true;

                        //if (data.InChargeUserFlag == "1")
                        //    cbInputer.Checked = true;

                        //if(Roles.GetRolesForUser(UserName).Length != 0)                    
                        DbHelper.FillList(ddlRolesList, "Select * from Mst_Roles Where RoleId not in (Select RoleId from Mst_UserInRoles Where Username = '" + txtUserName.Text + "')", "RoleName", "RoleId");
                        DbHelper.FillList(lstSelectedRole, "Select * from Mst_Roles Where RoleId in (Select RoleId from Mst_UserInRoles Where Username = '" + txtUserName.Text + "')", "RoleName", "RoleId");

                        chkActive.Checked = user.IsApproved;
                    }
                }
                else // Add new case
                {
                    //DbHelper.FillList(drpBuilding, "Select Name as BD_Name, BuildingId from Mst_Building Where delFlag = '0'and BuildingId in ('" + Func.ParseString(Session["__BUILDINGID__"]) + "')", "BD_Name", "BuildingId");
                    //DbHelper.FillList(ddlRolesList, "Select * from Mst_Roles  Where delFlag = '0'", "RoleName", "RoleId");
                    DbHelper.FillList(ddlRolesList, "Select * from Mst_Roles Where RoleId not in (Select RoleId from Mst_UserInRoles Where Username = '" + txtUserName.Text + "')", "RoleName", "RoleId");
                    DbHelper.FillList(drpBuilding, "Select Name as BD_Name, BuildingId from Mst_Building", "BD_Name", "BuildingId");

                    lblHeader.Text = "Thông Tin Người Dùng";
                    trPassReset.Visible = false;
                    trPass.Visible = true;
                    trPassConfirm.Visible = true;
                    btnRegister.Text = "Thêm Mới";
                    ltrNotice.Visible = true;
                    ltrNotice.Text = "";

                    //if (!IsPostBack)
                    //{
                    //    ddlRolesList.DataSource = Roles.GetAllRoles();
                    //    ddlRolesList.DataBind();
                    //}
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            mvMessage.CheckRequired(txtUserName, "Tên Người Dùng(User Name): Mục Bắt Buộc");
            mvMessage.CheckRequired(txtFullName, "Họ Tên: ): Mục Bắt Buộc");
            //mvMessage.CheckRequired(txtEmail, "Emailを正しく入力してください。");

            if (!mvMessage.IsValid) return;
            if (btnRegister.CommandName == "Edit")
            {
                //if (txtConfirm.Text != String.Empty || txtPassword.Text != String.Empty)
                //{
                //    if (txtPassword.Text != txtConfirm.Text)
                //    {
                //        mvMessage.AddError("パスワードが一致していません。");
                //        return;
                //    }
                //    if (!mvMessage.IsValid) return;
                //}

                aspnet_MembershipData data = new aspnet_MembershipData();
                Criteria cri = new Criteria();

                MembershipUser user = Membership.GetUser(UserName);
                cri.And("UserId", "=", user.ProviderUserKey.ToString());
                ITransaction tran = factory.GetSearchObject(data, cri);
                Execute(tran);
                data = (aspnet_MembershipData)(((System.Collections.ArrayList)tran.Result)[0]);

                user.IsApproved = chkActive.Checked;

                user.Email = txtEmail.Text.ToString().Trim();

                try
                {
                    string[] roles = Roles.GetRolesForUser(UserName);
                    bool isExist = false;
                    for (int i = 0; i < roles.Length; i++)
                    {
                        if (ddlRolesList.SelectedValue == roles[i])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        if (roles.Length > 0)
                        {
                            Roles.RemoveUserFromRoles(UserName, roles);
                        }
                        Roles.AddUserToRole(UserName, ddlRolesList.SelectedValue);
                    }
                }
                catch (Exception ex)
                {
                    ApplicationLog.WriteError(ex);
                }

                //if (txtPassword.Text != String.Empty)
                //{
                //    try
                //    {
                //        string pass = user.ResetPassword();
                //        txtPassReset.Text = pass;
                //        //if (!user.ChangePassword(pass, txtPassword.Text))
                //        //{
                //        //    mvMessage.AddError("エラーが発生しました。");
                //        //    return;
                //        //}
                //    }
                //    catch
                //    {
                //        mvMessage.AddError("変更パスワード中エラーが発生しました。");
                //    }
                //}

                user.IsApproved = chkActive.Checked;
                user.Email = txtEmail.Text.ToString().Trim();

                Membership.UpdateUser(user);

                //if(  cbManagement.Checked == true)
                //    data.SaleUserFlag = "1";
                //else
                //    data.SaleUserFlag = "0";

                //if (cbInputer.Checked == true)
                //    data.InChargeUserFlag = "1";
                //else
                //    data.InChargeUserFlag = "0";

                string plainQuery = String.Format("UPDATE [aspnet_Membership]  SET [FullName] = '{0}', BuildingId = '{1}'   WHERE [UserID] = '{2}';", txtFullName.Text.Trim(), drpBuilding.SelectedValue, user.ProviderUserKey.ToString());
                SqlDatabase db = new SqlDatabase();
                int Modifieditem = db.ExecuteNonQuery(plainQuery);
                if (Modifieditem == 0)
                {
                    Membership.DeleteUser(txtUserName.Text.Trim());
                    OperationLogger.WriteError(Constants.LogOperationUserId, Constants.LogActionUpdateId, "Lỗi Phát Sinh", Page.User.Identity.Name);
                    mvMessage.AddError("Lỗi Phát Sinh");
                }
                else
                {
                    OperationLogger.WriteInfo(Constants.LogOperationUserId, Constants.LogActionUpdateId, "Cập Nhật Thành Công", Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage("Cập Nhật Thành Công");
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), "openedituser", "window.opener.__doPostBack('PopUpAdminEditUser','');", true);

                    //Add quyền
                    int _count = lstSelectedRole.Items.Count;
                    if (_count != 0)
                    {
                        DbHelper.ExecuteNonQuery("Delete From Mst_UserInRoles Where UserName = '" + txtUserName.Text + "'");
                        for (int i = 0; i < _count; i++)
                        {
                            ListItem item = new ListItem();
                            item.Text = lstSelectedRole.Items[i].Text;
                            item.Value = lstSelectedRole.Items[i].Value;
                            //Add the item to selected employee list
                            Mst_UserInRolesData dataRole = new Mst_UserInRolesData();
                            ITransaction tranA = factory.GetInsertObject(dataRole);

                            dataRole.UserName = txtUserName.Text;
                            dataRole.RoleId = item.Value;

                            dataRole.ModifiedBy = Page.User.Identity.Name;
                            dataRole.CreatedBy = Page.User.Identity.Name;
                            dataRole.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                            dataRole.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                            dataRole.DelFlag = "0";

                            Execute(tranA);

                            if (!HasError)
                            {
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            else // Dang ky moi
            {
                MembershipCreateStatus status;
                MembershipUser user = null;
                mvMessage.CheckRequired(txtPassword, "Nhập Mới Mật Khẩu");
                mvMessage.CheckRequired(txtConfirm, "Nhập Xác Nhận Mật Khẩu");
                if (!mvMessage.IsValid) return;
                if (txtConfirm.Text.Trim() != txtPassword.Text.Trim())
                {
                    mvMessage.AddError("Mật Khẩu Không Giống Nhau");
                    return;
                }

                user = Membership.GetUser(txtUserName.Text);
                if (user != null)
                {
                    mvMessage.AddError("Người dùng: " + txtUserName.Text + " đã tồn tại.");
                    return;
                }

                status = new MembershipCreateStatus();
                user = Membership.CreateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim(), "Who is Peter?", "Peter's Father's son", true, out status);

                if (status == MembershipCreateStatus.Success)
                {
                    user.IsApproved = chkActive.Checked;
                    Membership.UpdateUser(user);

                    try
                    {
                        Roles.RemoveUserFromRoles(user.UserName, Roles.GetAllRoles());
                    }
                    catch
                    {
                    }

                    try
                    {
                        Roles.AddUserToRole(user.UserName, ddlRolesList.SelectedItem.Text);
                    }
                    catch
                    {
                    }

                    if (txtFullName.Text.Trim() != string.Empty)
                    {
                        string SaleUserFlag = String.Empty;
                        string InChargeUserFlag = String.Empty;
                        //if (cbManagement.Checked == true)
                        //{
                        //    SaleUserFlag = "1";
                        //}
                        //else
                        //{
                        //    SaleUserFlag = "0";
                        //}

                        //if (cbInputer.Checked == true)
                        //{
                        //    InChargeUserFlag = "1";
                        //}
                        //else
                        //{
                        //    InChargeUserFlag = "0";
                        //}

                        aspnet_MembershipData data = new aspnet_MembershipData();
                        string plainQuery = String.Format("UPDATE [aspnet_Membership]  SET [FullName] = '{0}', [BuildingId] = '{2}' WHERE [UserId] = '{1}';", txtFullName.Text.Trim(), user.ProviderUserKey.ToString().Trim(), drpBuilding.SelectedValue);
                        SqlDatabase db = new SqlDatabase();
                        if (db.ExecuteNonQuery(plainQuery) == 0)
                        {
                            Membership.DeleteUser(txtUserName.Text.Trim());
                            OperationLogger.WriteError(Constants.LogOperationUserId, Constants.LogActionUpdateId, "Lỗi Phát Sinh", Page.User.Identity.Name);
                            mvMessage.AddError("Lỗi Phát Sinh");
                            return;
                        }
                    }
                    OperationLogger.WriteInfo(Constants.LogOperationUserId, Constants.LogActionInsertId, "Thêm Mới Hoàn Tất", Page.User.Identity.Name);
                    mvMessage.SetCompleteMessage("Thêm Mới Hoàn Tất");
                    ScriptManager.RegisterClientScriptBlock(this.btnRegister, this.GetType(), "openadduser", "window.opener.__doPostBack('PopUpAdminEditUser','');", true);

                    //Add quyền
                    int _count = lstSelectedRole.Items.Count;
                    if (_count != 0)
                    {
                        DbHelper.ExecuteNonQuery("Delete From Mst_UserInRoles Where UserName = '" + txtUserName.Text + "'");
                        for (int i = 0; i < _count; i++)
                        {
                            ListItem item = new ListItem();
                            item.Text = lstSelectedRole.Items[i].Text;
                            item.Value = lstSelectedRole.Items[i].Value;
                            //Add the item to selected employee list
                            Mst_UserInRolesData dataRole = new Mst_UserInRolesData();
                            ITransaction tran = factory.GetInsertObject(dataRole);

                            dataRole.UserName = txtUserName.Text;
                            dataRole.RoleId = item.Value;

                            dataRole.ModifiedBy = Page.User.Identity.Name;
                            dataRole.CreatedBy = Page.User.Identity.Name;
                            dataRole.Created = DateTime.Now.ToString("yyyyMMddHHmmss");
                            dataRole.Modified = DateTime.Now.ToString("yyyyMMddHHmmss");
                            dataRole.DelFlag = "0";

                            Execute(tran);

                            if (!HasError)
                            {
                            }
                            else
                            {
                            }
                        }

                    }



                }
                else
                {
                    OperationLogger.WriteError(Constants.LogOperationUserId, Constants.LogActionInsertId, "Lỗi Phát Sinh", Page.User.Identity.Name);
                    mvMessage.AddError("Lỗi Phát Sinh");
                }
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser user = Membership.GetUser(UserName);
                string pass = user.ResetPassword();
                txtPassReset.Text = pass;
                mvMessage.SetCompleteMessage("Đã phát sinh lại Mật Khẩu.");
            }
            catch
            {
                mvMessage.AddError("Phát sinh mật khẩu bị lỗi.");
            }
        }//End function
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //lstSelectedRole.Items.Add(ddlRolesList.SelectedItem);
                //ddlRolesList.Items.Remove(ddlRolesList.SelectedItem);

                string _value = ddlRolesList.SelectedItem.Value; //Gets the value of items in list.
                string _text = ddlRolesList.SelectedItem.Text;  // Gets the Text of items in the list.  
                ListItem item = new ListItem(); //create a list item
                item.Text = _text;               //Assign the values to list item   
                item.Value = _value;

                ddlRolesList.Items.Remove(item); //Remove from the selected list
                lstSelectedRole.Items.Add(item); //Add in the Employee list 

            }
            catch
            {
                mvMessage.AddError("Phải chọn Quyền để thêm mới.");
            }
        }//End function
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {

                string _value = lstSelectedRole.SelectedItem.Value; //Gets the value of items in list.
                string _text = lstSelectedRole.SelectedItem.Text;  // Gets the Text of items in the list.  
                ListItem item = new ListItem(); //create a list item
                item.Text = _text;               //Assign the values to list item   
                item.Value = _value;

                lstSelectedRole.Items.Remove(item); //Remove from the selected list
                ddlRolesList.Items.Add(item); //Add in the Employee list 
            }
            catch
            {
                mvMessage.AddError("Phải chọn quyền để xóa.");
            }
        }
    }//End class

} //End name space

