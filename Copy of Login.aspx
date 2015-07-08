<%@ Page Language="C#" MasterPageFile="~/MasterPage/OneColumn.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Man.Login" Title="Đăng Nhập Hệ Thống Quản lý Tòa Nhà" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .style1
        {
            width: 204px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:Login ID="login" runat="server"  
                BorderStyle="Solid" BorderWidth="0" Font-Names="Verdana" Font-Size="10pt"  
                 FailureText="Tên Đăng Nhập hoặc Mật Khẩu không đúng" LoginButtonText="Đăng Nhập" 
                    PasswordLabelText="Mật Khẩu:" PasswordRequiredErrorMessage="Mật Khẩu: mục bắt buộc phải nhập." 
                    RememberMeText="Ghi nhớ Tên Đăng Nhập & Mật Khẩu" TitleText="Đăng Nhập" UserNameLabelText="Tên Đăng Nhập:" 
                    UserNameRequiredErrorMessage="Tên Đăng Nhập: mục bắt buộc phải nhập." Width="290px">
                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" BorderColor="#7F7F7F" 
                    ForeColor="#FFFFFF" />
                <LayoutTemplate>
                    <table border="0" cellpadding="1" cellspacing="0" bgcolor ="#5759BE" Width="290px">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="1"  bgcolor="#F1F1F1" width="100%" >
                                    <tr>
                                       <td align="center" colspan="2" style="color:White;height:22px; background-color:#2749BE;font-weight:bold;">
                                           <font size="3">Quản lý Tòa Nhà Cho Thuê
                                       </font>
                                       </td>
                                    </tr>
                                    <tr>
                                    <td style="height:1px;background-color:#2749BE" colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height:28px;border-top-color:#5759BE;" >
                                        <p style="margin-top:10px;"></p>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Tên Đăng Nhập</asp:Label>
                                        </td>
                                        <td >
                                            <p style="margin-top:10px;"></p>
                                            <asp:TextBox ID="UserName" runat="server" Width="170px" Height="18px"></asp:TextBox>
                                         <%--   <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="ユーザー名は入力必須項目です。" 
                                                ToolTip="ユーザー名は入力必須項目です。" ValidationGroup="Login1">&nbsp;</asp:RequiredFieldValidator>
                                             
                                            <cc1:ValidatorCalloutExtender ID="UserNameRequired_ValidatorCalloutExtender" 
                                                runat="server" Enabled="True"  TargetControlID="UserNameRequired">
                                            </cc1:ValidatorCalloutExtender>--%>
                                             
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left"  nowrap="nowrap" style="height:28px;">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Mật Khẩu</asp:Label>
                                        </td>
                                        <td  nowrap="nowrap">
                                            <asp:TextBox ID="Password" Width="170px" runat="server" TextMode="Password"  Height="18"></asp:TextBox>
                                          <%--  <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                ControlToValidate="Password" ErrorMessage="パスワードは入力必須項目です。" 
                                                ToolTip="パスワードは入力必須項目です。" ValidationGroup="Login1">&nbsp;</asp:RequiredFieldValidator>
                                                
                                              <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtenderPasswordRequired" 
                                                runat="server" Enabled="True"  TargetControlID="PasswordRequired">
                                            </cc1:ValidatorCalloutExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" style="height:28px;">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Lưu Tên Đăng Nhập & Mật Khẩu" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td  colspan="2" align="center" style="height:28px;" valign="middle">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Đăng Nhập" 
                                                ValidationGroup="Login1" onclick="LoginButton_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                       <p align="center" >
                    <font color="red"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></font>
                    </p>
                </LayoutTemplate>
            </asp:Login>
            
           
        </asp:Content>
