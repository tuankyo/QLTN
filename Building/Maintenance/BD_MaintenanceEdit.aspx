<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_MaintenanceEdit.aspx.cs" Inherits="Man.Building.Maintenance.BD_MaintenanceEdit"
    Title="Thông Tin Làm Thêm của Nhân Viên" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Nhân Viên"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Danh mục
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMainName" runat="server" MaxLength="100" Width="95%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nội dung công việc<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtSubName" runat="server" MaxLength="100" Width="95%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Năm<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtYear" runat="server" MaxLength="100" Width="95%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tháng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMonth" runat="server" MaxLength="100" Width="95%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tuần<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtWeek" runat="server" MaxLength="100" Width="95%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ngày thực hiện<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtExecDate" runat="server" MaxLength="100" Width="95%" />
                            <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtExecDate"
                                Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Công ty thực hiện<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtExecCompany" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Mô tả
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtExecDescription" runat="server" Width="40%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Người giám sát<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtExecConfirmer" runat="server" Width="40%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Ghi Chú
                        </td>
                        <td>
                            <asp:TextBox ID="txtExecComment" runat="server" MaxLength="200" Rows="3" TextMode="MultiLine"
                                Width="98%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Hoạt động
                        </td>
                        <td>
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
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:HiddenField ID="hidId" runat="server" />
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
