<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="PaymentBooking.aspx.cs" Inherits="Man.Customer.PaymentBooking" Title="Trả tiền đặt phòng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">Đang thực hiện yêu cầu...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <div class="edit_form">
                <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Khách Hàng"></asp:Label>
                </div>
                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                    style="border-collapse: collapse">
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Mã khách hàng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtCustomerId" runat="server" Width="95%" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td width="5%" valign="top" class="text_label">
                            Khách hàng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td width="5%" valign="top" class="text_label">
                            Người liên hệ
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtContactName" runat="server" MaxLength="100" Width="95%" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="title_form">
                                Thông Tin Thu Phí</div>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Người trả
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtPaymenter" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            Người nhận
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtReceiver" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Ngày trả
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPaymentDate" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                TargetControlID="txtPaymentDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Số tiền (<asp:Label ID="lblMoney" runat="server"></asp:Label>)
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMoney" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="input_form" colspan="4" align="center">
                            <asp:Button CssClass="btn_blue" ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được Lưu?')"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button CssClass="btn_blue" ID="btnExport" runat="server" Text="Hủy" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hidYearMonth" runat="server" />
                <asp:HiddenField ID="hidPaymentType" runat="server" />
                <asp:HiddenField ID="hidExchangeType" runat="server" />
                <asp:HiddenField ID="hidBookingId" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
