<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="PaymentTerm.aspx.cs" Inherits="Man.Customer.PaymentTerm" Title="Thu tiền theo kỳ" %>

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
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Mã khách hàng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtCustomerId" runat="server" Width="95%" AutoPostBack="true" OnTextChanged="CustomerId_OnTextChanged" />
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
                            Người trả
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPaymenter" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td valign="top" class="text_label">
                            Người nhận
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtReceiver" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Ngày nhận
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPaymentDate" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                TargetControlID="txtPaymentDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Loại tiền
                        </td>
                        <td class="input_form">
                            <select id="drpExchangeType" runat="server">
                                <option value="0">USD</option>
                                <option value="1">VND</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            Loại phí
                        </td>
                        <td width="20%" valign="top" class="input_form" colspan="3">
                            <select runat="server" id="drpSelect">
                                <option value="0" selected="selected">_</option>
                                <option value="1">Tiền Thuê hằng tháng (bao gồm VAT)</option>
                                <option value="2">Phí Quản Lý hằng tháng (bao gồm VAT)</option>
                                <option value="3">Phí Gửi Xe Tháng</option>
                                <option value="4">Phí Làm Ngoài Giờ hằng tháng (bao gồm VAT)</option>
                                <option value="5">Điện hằng tháng (bao gồm VAT)</option>
                                <option value="6">Nước hằng tháng (bao gồm VAT)</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Năm tháng
                        </td>
                        <td align="left" class="input_form">
                            <asp:ListBox ID="lstYearMonth" runat="server" SelectionMode="Multiple" Width="95%"
                                Height="100px"></asp:ListBox>
                        </td>
                        <td align="center" class="input_form">
                            <asp:Button ID="btnSelect" runat="server" Text=">" Width="50px" OnClick="btnSelect_Click" /><br />
                            <asp:Button ID="btnUnSelect" runat="server" Text="<" Width="50px" OnClick="btnUnSelect_Click" /><br />
                            <asp:Button ID="btnAllSelect" runat="server" Text=">>" Width="50px" OnClick="btnAllSelect_Click" /><br />
                            <asp:Button ID="btnUnAllSelect" runat="server" Text="<<" Width="50px" OnClick="btnUnAllSelect_Click" />
                        </td>
                        <td align="left" class="input_form">
                            <asp:ListBox ID="lstSelectedYearMonth" runat="server" SelectionMode="Multiple" Width="95%"
                                Height="100px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số tiền mỗi tháng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtMoney" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="3" runat="server" MaxLength="100"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="input_form" colspan="4" align="center">
                            <asp:Button CssClass="btn_blue" ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được Lưu?')" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button CssClass="btn_blue" ID="btnExport" runat="server" Text="Hủy" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
