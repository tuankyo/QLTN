<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="PaymentOfBD.aspx.cs" Inherits="Man.Customer.PaymentOfBD" Title="Danh Sách Hợp Đồng" %>

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
                            <asp:TextBox ID="txtCustomerId" runat="server" Width="40%" AutoPostBack="true" OnTextChanged="CustomerId_OnTextChanged"/> Hãy nhập Mã KH cần Thu/Chi
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
                            Loại phí
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpPaymentType" runat="server" MaxLength="100" Width="95%" AutoPostBack="true" OnSelectedIndexChanged="drpPaymentType_OnSelectedIndexChanged" />
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Người thực hiện
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPaymenter" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Thu/Chi
                        </td>
                        <td class="input_form">
                            <select id="drpPaidType" runat="server" disabled>
                                <option value="1">Thu</option>
                                <option value="0">Chi</option>
                            </select>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Loại tiền
                        </td>
                        <td class="input_form">
                            <select id="drpExchangeType" runat="server" >
                                <option value="0">USD</option>
                                <option value="1">VND</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            Người/Công ty nhận
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtReceiver" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Ngày thực hiện
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
