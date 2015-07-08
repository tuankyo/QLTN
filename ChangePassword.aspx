<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="Man.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="upList" runat="server">
        <ContentTemplate>
            <div>
                <div class="edit_form">
                    <div class="title_form">
                        <asp:Label runat="server" ID="lblHeader" Text="Đổi Mật Khẩu"></asp:Label>
                    </div>
                    <table cellpadding="1" cellspacing="1" width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" valign="top" class="text_label">
                                Mật Khẩu Hiện Tại
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtOldPass" runat="server" Width="150" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_label">
                                Mật Khẩu Mới
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNewPass" runat="server" Width="150" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="text_label">
                                Xác Nhận Mật Khẩu Mới
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNewPassConfirm" runat="server" Width="150" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button CssClass="btn_blue" ID="btnSave" runat="server" Text="Đổi Mật Khẩu" OnClientClick="return confirmSubmit('Thay đổi Mật Khẩu?');"
                                    OnClick="btnSave_Click" />
                                <asp:Button CssClass="btn_blue" ID="btnClose" Text="Đóng" runat="server" OnClientClick="window.close();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
