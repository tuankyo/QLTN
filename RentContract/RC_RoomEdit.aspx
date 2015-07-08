<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="RC_RoomEdit.aspx.cs" Inherits="Man.RentContract.RC_RoomEdit" Title="Thông Tin HĐ Thuê Phòng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="content_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Hợp Đồng"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="14%" valign="top" class="text_label">
                            Mã HĐ
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblId" runat="server" MaxLength="100" Width="95%"></asp:Label>
                        </td>
                        <td valign="top" class="text_label">
                            Khách hàng
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblCustomerId" runat="server" MaxLength="100" Width="95%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="14%" valign="top" class="text_label">
                            Ngày HĐ
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblContractDate" runat="server" MaxLength="100" Width="95%"></asp:Label>
                        </td>
                        <td width="14%" valign="top" class="text_label">
                            Kết thúc
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblContractEndDate" runat="server" MaxLength="100" Width="95%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="14%" valign="top" class="text_label">
                            Bàn giao
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblReceiveDate" runat="server" MaxLength="100" Width="95%"></asp:Label>
                        </td>
                        <td class="text_label">
                            Số lượng NV
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblStaffMount" runat="server" MaxLength="100" Rows="10" Width="95%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Ghi Chú
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:Label ID="lblComment" runat="server" MaxLength="100" Rows="10" TextMode="MultiLine"
                                Width="95%"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Thông Tin Khu Vực Thuê"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="14%" valign="top" class="text_label">
                            Khu vực<font color="red">※</font>
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:DropDownList ID="drpRoom" runat="server" MaxLength="100" Width="95%" OnSelectedIndexChanged="drpRoom_SelectedIndexChanged"
                                AutoPostBack="true" ViewStateMode="Enabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Hợp đồng từ Ngày<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtContractDate" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                TargetControlID="txtContractDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Đến Ngày<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtContractEndDate" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                TargetControlID="txtContractEndDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label5" Text="Thông tin Fitout" />
                            </div>
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:DropDownList ID="drpBeginMonth" runat="server">
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpBeginYear" runat="server">
                            </asp:DropDownList>
                            ~
                            <asp:DropDownList ID="drpEndMonth" runat="server">
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpEndYear" runat="server">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:CheckBox ID="chkFitoutManager" runat="server" Text="Quản lý" />
                            <asp:CheckBox ID="chkFitoutExtraTime" runat="server" Text="Làm thêm" />
                            <asp:CheckBox ID="chkFitoutParking" runat="server" Text="Gửi Xe" />
                            <asp:CheckBox ID="chkFitoutService" runat="server" Text="Dịch vụ" />
                            <asp:CheckBox ID="chkFitoutElec" runat="server" Text="Điện" />
                            <asp:CheckBox ID="chkFitoutWater" runat="server" Text="Nước" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label2" Text="Phí Thuê-Quản Lý" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="14%" valign="top" class="text_label">
                            Diện tích thuê<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtRentArea" runat="server" MaxLength="100" Width="30%" />m2
                        </td>
                        <td width="14%" valign="top" class="text_label">
                            VAT<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtVAT" runat="server" MaxLength="100" Width="30%" />%
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            <asp:Label ID="lblRentPrice" runat="server" Text="Phí Thuê (/m2)"></asp:Label>
                            <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtRentPriceVND" runat="server" MaxLength="100" Width="30%" />VND
                            <asp:TextBox ID="txtRentPriceUSD" runat="server" MaxLength="100" Width="30%" />USD
                        </td>
                        <td width="14%" valign="top" class="text_label">
                            Trọn gói phí thuê<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:CheckBox ID="chkRentType" runat="server" AutoPostBack="true" OnCheckedChanged="chkRentTypeChange" /><font
                                color="red">※uncheck: phí thuê tính theo m2 ---- check: phí thuê tính theo tổng
                                diện tích</font>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            <asp:Label ID="lblManagerPrice" runat="server" Text="Phí Quản lý (/m2)" /><font
                                color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtManagerPriceVND" runat="server" MaxLength="100" Width="30%" />VND
                            <asp:TextBox ID="txtManagerPriceUSD" runat="server" MaxLength="100" Width="30%" />USD
                        </td>
                        <td width="14%" valign="top" class="text_label">
                            Trọn gói phí QL<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:CheckBox ID="chkManagerType" runat="server" AutoPostBack="true" OnCheckedChanged="chkRentTypeChange" /><font
                                color="red">※uncheck: phí QL tính theo m2 ---- check: phí QL tính theo tổng diện
                                tích</font>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label3" Text="Phí làm ngoài giờ" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            Phí Ngoài giờ (m2/h)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtHourExtraTimePriceVND" runat="server" MaxLength="100" Width="30%" />VND
                            <asp:TextBox ID="txtHourExtraTimePriceUsd" runat="server" MaxLength="100" Width="30%" />USD
                        </td>
                        <td valign="top" class="text_label">
                            Phí Ngoài giờ (diện tích/h)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMonthExtraTimePriceVND" runat="server" MaxLength="100" Width="30%" />VND
                            <asp:TextBox ID="txtMonthExtraTimePriceUSD" runat="server" MaxLength="100" Width="30%" />USD
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label4" Text="Biểu Phí Điện/Nước" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="14%" valign="top" class="text_label">
                            Biểu phí điện<font color="red">※</font>
                        </td>
                        <td class="input_form" width="20%">
                            <asp:DropDownList ID="drpTariffsOfElec" runat="server" MaxLength="100" Width="95%"
                                OnSelectedIndexChanged="drpRoom_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled" />
                        </td>
                        <td valign="top" class="text_label">
                            Tỉ lệ %(tiền)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtElecPricePercent" runat="server" Text="100" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="text_label">
                            Biểu phí nước<font color="red">※</font>
                        </td>
                        <td class="input_form" width="20%">
                            <asp:DropDownList ID="drpTariffsOfWater" runat="server" MaxLength="100" Width="95%"
                                OnSelectedIndexChanged="drpRoom_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled" />
                        </td>
                        <td valign="top" class="text_label">
                            Tỉ lệ %(tiền)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtWaterPricePercent" runat="server" Text="100" />
                        </td>
                    </tr>
                    <tr>
                        <td width="14%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="100" Width="95%" TextMode="MultiLine"
                                Rows="3" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Trở về" Style="white-space: nowrap;"
                                OnClientClick="javascript:history.back()" />
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Lưu" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật? Thông tin tính bill sẽ được thay đổi')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" Text="Đóng" />
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
