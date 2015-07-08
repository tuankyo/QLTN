<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_StaffEdit.aspx.cs" Inherits="Man.Building.Staff.BD_StaffEdit"
    Title="Thông Tin Nhân Viên" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Loại Phòng"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã NV<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtStaffId" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Họ Tên<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Chức vụ
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpPosition" runat="server" Width="95%"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Công việc
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtJobContent" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Khu vực làm việc
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpWorkingPlace" runat="server" Width="95%"/>                            
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
                            Địa chỉ mail
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMail" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Thời gian vào làm từ<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtJobBegin" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                            TargetControlID="txtJobBegin" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Thời gian nghỉ làm từ
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtJobEnd" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                            Enabled="True" TargetControlID="txtJobEnd" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Ghi Chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="2" TextMode="MultiLine"
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
                        <td align="center" colspan="2">
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
                    <asp:HiddenField ID="hidJobType" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
