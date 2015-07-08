<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_SuppliesEdit.aspx.cs" Inherits="Man.Building.Supplies.BD_SuppliesEdit"
    Title="Thông Tin Vật Tư" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Vật Tư"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtId" Enabled="false" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tên<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nhà cung cấp<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtProductOf" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nhãn hiệu<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtLabel" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            <asp:Label ID="lblModel" runat="server" Text="Model"></asp:Label>
                            <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtModel" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            <asp:Label ID="lblDescription" runat="server" Text="Thông số kỹ thuật"></asp:Label>
                            <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            <asp:Label ID="lblRegional" runat="server" Text="Khu vực"></asp:Label>
                            <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtRegional" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Ghi Chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="10" TextMode="MultiLine"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Hoạt động
                        </td>
                        <td class="input_form">
                            <asp:CheckBox ID="chkDelFlag" Enabled="false" Checked="true" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Thông Tin Thêm Mới
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblCreated" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Thông Tin Cập Nhật
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                        </td>
                    </tr>
                    <tr class="text_label">
                        <td align="center" colspan="4">
                            <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:HiddenField ID="hidId" runat="server" />
                    <asp:HiddenField ID="hidAction" runat="server" />
                    <asp:HiddenField ID="hidSuppliesType" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
