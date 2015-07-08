<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_RoomEdit.aspx.cs" Inherits="Man.Building.Room.BD_RoomEdit" Title="Thông Tin Phòng Cho Thuê-Phòng Họp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Phòng Cho Thuê"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã
                        </td>
                        <td class="input_form">
                            <asp:TextBox ReadOnly="true" ID="txtId" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Phòng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Phòng họp
                        </td>
                        <td class="input_form">
                            <asp:CheckBox ID="chkMeetinRoom" runat="server" /> Chỉ chọn nếu Phòng này là phòng hợp
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Khu vực<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtRegional" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Lầu<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtFloor" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Diện tích<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtArea" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            VAT<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtVat" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label1" Text="Phí Thuê(Tháng)"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Phí thuê<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMonthRentPriceVND" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(VND/m2)
                            &nbsp; &nbsp; &nbsp;
                            <asp:TextBox ID="txtMonthRentPriceUSD" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(USD/m2)
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Phí quản lý<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMonthManagerPriceVND" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(VND/m2)
                            &nbsp; &nbsp; &nbsp;
                            <asp:TextBox ID="txtMonthManagerPriceUSD" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(USD/m2)
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Sử dụng ngoài giờ<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtHourExtraTimePriceVND" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(VND/m2/h)&nbsp;
                            &nbsp; &nbsp;
                            <asp:TextBox ID="txtHourExtraTimePriceUSD" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(USD/m2/h)
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Sử dụng ngoài giờ<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMonthExtraTimePriceVND" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(VND/dt/h)&nbsp;
                            &nbsp; &nbsp;
                            <asp:TextBox ID="txtMonthExtraTimePriceUSD" runat="server" MaxLength="100" Width="25%"></asp:TextBox>(USD/dt/h)
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label2" Text="Phí Thuê(Phòng Họp)"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Phí thuê(giờ)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtHourRentPriceVND" runat="server" MaxLength="100" Width="25%"></asp:TextBox>VND
                            &nbsp; &nbsp; &nbsp;
                            <asp:TextBox ID="txtHourRentPriceUSD" runat="server" MaxLength="100" Width="25%"></asp:TextBox>USD
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Công năng
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtDescription" runat="server" MaxLength="200" Rows="3" TextMode="MultiLine"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Ghi Chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="3" TextMode="MultiLine"
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
                    <tr class="text_label">
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <br />
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
