<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Man.Login"
    Title="Đăng Nhập Hệ Thống Quản lý Tòa Nhà" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
    <title>Quản Lý Tòa Nhà Cho Thuê</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/style_login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row_top_title">
    </div>
    <!--container pages -->
    <div class="container_login">
        <div class="panel_login">
            <div class="row_bottom_login">
                <div class="title_login">
                    <img src="App_Themes/Default/images/icon_user.png" align="absmiddle" border="0" />
                    ĐĂNG NHẬP</div>
                <div class="form_login">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="text_form_login" valign="bottom" align="left">
                                <asp:Login ID="login" runat="server" BorderStyle="Solid" BorderWidth="0" Font-Names="Verdana"
                                    Font-Size="10pt" FailureText="Tên Đăng Nhập hoặc Mật Khẩu không đúng" LoginButtonText=""
                                    LoginButtonStyle-CssClass="btn_login" PasswordLabelText="Mật Khẩu:" PasswordRequiredErrorMessage="Mật Khẩu: mục bắt buộc phải nhập."
                                    RememberMeText="Ghi nhớ Tên Đăng Nhập & Mật Khẩu" TitleText="" UserNameLabelText="Tên Đăng Nhập:"
                                    UserNameRequiredErrorMessage="Tên Đăng Nhập: mục bắt buộc phải nhập." Width="300px"
                                    OnLoggedIn="OnLoggedIn">
                                    <TextBoxStyle Width="160px" />
                                </asp:Login>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="row_bottom_title">
    </div>
    <!--end container pages -->
    </form>
</body>
</html>
