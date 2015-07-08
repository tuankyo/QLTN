<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="AdminBuildingEdit.aspx.cs" Inherits="Man.Building.AdminBuildingEdit" Title="Thông Tin Tòa Nhà Cho Thuê" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Chi Tiết Tòa Nhà Cho Thuê"></asp:Label></div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtBuildingId" Enabled="false" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tòa Nhà Cho Thuê<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tên chủ đầu tư<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtInvestor" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Địa chỉ<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số điện thoại<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Người đại diện<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOwner" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Công ty quản lý<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtManagerCompany" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Người đại diện công ty<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtManagerCompanyAgent" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số điện thoại công ty<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtManagerCompanyPhone" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi Chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="3" TextMode="MultiLine"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="title_form">
                                Thông Tin Chi Chuyển Khoản Thu Phí</div>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tên ngân hàng
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtBank" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tài khoản
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtAccount" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Chủ tài khoản
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtAccountName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Thanh toán tại Văn phòng
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOffice" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Điện thoại
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOfficePhone" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Hoạt động
                        </td>
                        <td class="input_form">
                            <asp:CheckBox ID="chkDelFlag" Enabled="false" Checked="true" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Thông Tin Thêm Mới
                        </td>
                        <td class="text_inputform">
                            <asp:Label ID="lblCreated" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            Thông Tin Cập Nhật
                        </td>
                        <td  class="input_form">
                            <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:HiddenField ID="hidAction" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
