<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="PaymentBillInfo.aspx.cs" Inherits="Man.Customer.PaymentBillInfo"
    Title="Danh Sách Hợp Đồng" %>

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
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Mã khách hàng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtCustomerId" runat="server" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="5%" valign="top" class="text_label">
                            Khách hàng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="5%" valign="top" class="text_label">
                            Người liên hệ
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtContactName" runat="server" MaxLength="100" Width="95%" />
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
                            Tên ngân hàng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtBank" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            Tài khoản
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtAccount" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Chủ tài khoản
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtAccountName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Thanh toán tại Văn phòng
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOffice" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Điện thoại
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOfficePhone" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="title_form">
                                Thông Tin Hóa Đơn</div>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Số Hóa Đơn
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="BillNo" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Ngày Xuất
                        </td>
                        <td style="font-size:xx-small">
                            <asp:TextBox Style="text-align: right" ID="txtBillDate" runat="server" MaxLength="100"
                                Width="95%"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtBillDate"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Tỉ giá USD - VND
                        </td>
                        <td class="input_form">
                            <asp:TextBox Style="text-align: right" ID="txtUsdExchange" runat="server" MaxLength="100"
                                Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Áp dụng lúc (dd/MM/yyyy hh:mm:ss)
                        </td>
                        <td class="input_form">
                            <asp:TextBox Style="text-align: right" ID="txtUsdExchangeDate" runat="server" MaxLength="100"
                                Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                TargetControlID="txtUsdExchangeDate" Format="dd/MM/yyyy hh:mm:ss">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="title_form">
                                Loại tiền tệ thanh toán</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tiền Thuê Phòng
                        </td>
                        <td class="input_form">
                            <asp:RadioButton ID="rdoRentPaidUSD" runat="server" GroupName="rentPaid" Checked="true"
                                Text="USD" />
                            <asp:RadioButton ID="rdoRentPaidVND" runat="server" GroupName="rentPaid" Text="VND" />
                        </td>
                        <td>
                            Phí Quản Lý
                        </td>
                        <td class="input_form">
                            <asp:RadioButton ID="rdoManagerPaidUSD" runat="server" GroupName="managerPaid" Checked="true"
                                Text="USD" />
                            <asp:RadioButton ID="rdoManagerPaidVND" runat="server" GroupName="managerPaid" Text="VND" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phí Gửi Xe
                        </td>
                        <td class="input_form">
                            <asp:RadioButton ID="rdoParkingPaidUSD" runat="server" GroupName="ParkingPaid" Checked="true"
                                Text="USD" />
                            <asp:RadioButton ID="rdoParkingPaidVND" runat="server" GroupName="ParkingPaid" Text="VND" />
                        </td>
                        <td>
                            Phí Ngoài Giờ
                        </td>
                        <td class="input_form">
                            <asp:RadioButton ID="rdoExtraTimePaidUSD" runat="server" GroupName="ExtraTimePaidVND"
                                Checked="true" Text="USD" />
                            <asp:RadioButton ID="rdoExtraTimePaidVND" runat="server" GroupName="ExtraTimePaidVND"
                                Text="VND" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tiền Điện
                        </td>
                        <td class="input_form">
                            <asp:RadioButton ID="rdoElecPaidUSD" runat="server" GroupName="ElecPaid" Checked="true"
                                Text="USD" />
                            <asp:RadioButton ID="rdoElecPaidVND" runat="server" GroupName="ElecPaid" Text="VND" />
                        </td>
                        <td>
                            Tiền Nước
                        </td>
                        <td class="input_form">
                            <asp:RadioButton ID="rdoWaterPaidUSD" runat="server" GroupName="WaterPaid" Checked="true"
                                Text="USD" />
                            <asp:RadioButton ID="rdoWaterPaidVND" runat="server" GroupName="WaterPaid" Text="VND" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phí Khác
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:RadioButton ID="rdoServicePaidUSD" runat="server" GroupName="ServicePaid" Checked="true"
                                Text="USD" />
                            <asp:RadioButton ID="rdoServicePaidVND" runat="server" GroupName="ServicePaid" Text="VND" />&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="input_form" colspan="4" align="center">
                            <asp:Button CssClass="btn_blue" ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được Lưu?')" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button CssClass="btn_blue" ID="btnExport" runat="server" Text="Đóng" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hidYearMonth" runat="server" />
                <asp:HiddenField ID="hidBillId" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
