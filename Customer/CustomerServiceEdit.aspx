<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="CustomerServiceEdit.aspx.cs" Inherits="Man.Customer.CustomerServiceEdit"
    Title="Thông Tin Dịch Vụ Cộng Thêm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="content_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Dịch Vụ Cộng Thêm"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ngày<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtServiceDateFrom" runat="server" MaxLength="100" Width="20%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="txtServiceDateFrom" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <asp:TextBox ID="txtServiceDateTo" runat="server" MaxLength="100" Width="20%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                TargetControlID="txtServiceDateTo" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Bill tháng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpMonth" runat="server" />
                            <asp:DropDownList ID="drpYear" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Dịch vụ<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtService" runat="server" MaxLength="200" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số lượng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMount" runat="server" MaxLength="200" Width="20%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Đơn vị tính
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUnit" runat="server" MaxLength="200" Width="20%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Đơn giá<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPriceVND" runat="server" MaxLength="200" Width="20%"></asp:TextBox>VND
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtPriceUSD" runat="server" MaxLength="200" Width="20%"></asp:TextBox>USD
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            VAT<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtVAT" runat="server" MaxLength="200" Width="20%" Text="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="5" TextMode="MultiLine"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Trở về" Style="white-space: nowrap;"
                                OnClientClick="javascript:history.back()" />
                            <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" Text="Cập Nhật" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" Text="Đóng" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
