<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="AdminEditUser.aspx.cs" Inherits="Man.User.AdminEditUser" Title="Thông Tin Người Dùng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Người Dùng"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td colspan="2" align="center">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Tên Truy Cập(username) <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox runat="server" ID="txtUserName" Width="250px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Tên <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox runat="server" ID="txtFullName" SkinID="IMETextBox" Width="250px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr runat="server" id="trPass">
                        <td class="text_label">
                            <asp:Label runat="server" ID="lblOldPassword" Text="Mật Khẩu"></asp:Label>
                            &nbsp;
                        </td>
                        <td class="input_form">
                            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" Width="250px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr runat="server" id="trPassConfirm">
                        <td class="text_label">
                            <asp:Label runat="server" ID="lblPassword" Text="Xác Nhận Mật Khẩu"></asp:Label>
                            &nbsp;
                        </td>
                        <td class="input_form">
                            <asp:TextBox runat="server" TextMode="Password" ID="txtConfirm" Width="250px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr runat="server" id="trPassReset">
                        <td class="text_label">
                            Mật Khẩu Mới
                        </td>
                        <td class="input_form">
                            <table style="border: 0;" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td class="input_form">
                                        <asp:TextBox ID="txtPassReset" runat="server" Width="100px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td class="input_form">
                                        <asp:Button CssClass="btn_blue" ID="btnReset" Text="Phát Sinh Lại Mật Khẩu" runat="server"
                                            OnClick="btnReset_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Email
                        </td>
                        <td class="input_form">
                            <asp:TextBox runat="server" ID="txtEmail" Width="250px" MaxLength="99"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Có hiệu lực
                        </td>
                        <td class="input_form">
                            <asp:CheckBox runat="server" ID="chkActive" Checked="True" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Tòa nhà
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpBuilding" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Quyền hạn
                        </td>
                        <td class="input_form">
                            <table>
                                <tr>
                                    <td>
                                        Quyền chưa gán cho User<br />
                                        <asp:ListBox runat="server" ID="ddlRolesList" Width="150px" Height="100px"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button CssClass="btn_blue_short" runat="server" ID="btnAdd" OnClick="btnAdd_Click"
                                            CausesValidation="false" Text=">" /><br /><br />
                                        <asp:Button CssClass="btn_blue_short" runat="server" ID="btnRemove" OnClick="btnRemove_Click"
                                            CausesValidation="false" Text="<" />
                                    </td>
                                    <td>
                                        Quyền đã gán cho User<br />
                                    
                                        <asp:ListBox runat="server" ID="lstSelectedRole" Width="150px" Height="100px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <tr>
                            <td colspan="2">
                                <div style="text-align: center">
                                    <cc:CustomButton CssClass="btn_blue" runat="server" ID="btnRegister" Text="" OnClick="btnRegister_Click" />
                                    <asp:Button CssClass="btn_blue" runat="server" ID="btnCancel" OnClientClick="window.close();return false;"
                                        CausesValidation="false" Text="Đóng" />
                                </div>
                            </td>
                        </tr>
                </table>
                <font style="color: red; font-size: small;">
                    <asp:Literal ID="ltrNotice" runat="server" Visible="False"></asp:Literal></font>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
