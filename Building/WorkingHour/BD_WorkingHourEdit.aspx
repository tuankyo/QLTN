<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_WorkingHourEdit.aspx.cs" Inherits="Man.Building.WorkingHour.BD_WorkingHourEdit"
    Title="Thông Tin Ca Làm Việc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Ca Làm Việc"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã Ca Làm Việc<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtId" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Công việc<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpJobType" runat="server" Width="95%"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Thời gian Ca làm việc<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi Chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="10" TextMode="MultiLine"
                                Width="95%"></asp:TextBox>
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
                        <td  class="input_form">
                            <asp:Label ID="lblCreated" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
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
            </div>
            <div>
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hidAction" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
