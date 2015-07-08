<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="AllPay.aspx.cs" Inherits="Man.Customer.AllPay" Title="Thông Tin HĐ Thuê Phòng" %>

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
                        <td width="20%" valign="top" class="text_label">
                            Mã Khách hàng
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblCustomerId" runat="server" MaxLength="100" Width="95%"></asp:Label>
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
                </table>
                <asp:MultiValidator ID="mvMessage" runat="server" />
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Thông Tin Tiền Phải Thu"></asp:Label>
                </div>
                <table>
                    <tr>
                        <td valign="top" class="text_label">
                            Bill Tháng/Năm<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpMonth" runat="server" />
                            <asp:DropDownList ID="drpYear" runat="server" />
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button CssClass="btn_blue" ID="btnView" Text="Xem" runat="server" OnClick="btnView_Click"
                                Style="white-space: nowrap;" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" Text="Đóng" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="8">
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label2" Text="Thông Tin Thu Tiền"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr align="center">
                        <td width="15%" valign="top" class="text_label">
                            Thu tiền từ<font color="red">※</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPaymenter" runat="server" MaxLength="100" Width="100px"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Người/Công ty nhận<font color="red">※</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceiver" runat="server" MaxLength="100" Width="100px"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Ngày thu tiền<font color="red">※</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPaymentDate" runat="server" MaxLength="100" Width="80px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                TargetControlID="txtPaymentDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Tỉ giá USD/VND<font color="red">※</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRateChange" runat="server" MaxLength="100" Width="50px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                </cc:Pager>
                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                    style="border-collapse: collapse">
                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                        OnItemCommand="rptList_ItemCommand">
                        <HeaderTemplate>
                            <tr class="row_title">
                                <td align="center" valign="middle" rowspan="2">
                                    Tháng/Năm
                                </td>
                                <td align="center" valign="middle" width="8%" colspan="2">
                                    Phí thuê
                                </td>
                                <td align="center" valign="middle" width="8%" colspan="2">
                                    Phí Quản lý
                                </td>
                                <td align="center" valign="middle" colspan="2">
                                    Phí gửi xe
                                </td>
                                <td align="center" valign="middle" colspan="2">
                                    Phí ngoài giờ
                                </td>
                                <td align="center" valign="middle">
                                    Tiền Điện
                                </td>
                                <td align="center" valign="middle">
                                    Tiền Nước
                                </td>
                                <td align="center" valign="middle" colspan="2">
                                    Phí Khác
                                </td>
                            </tr>
                            <tr class="row_title">
                                <td align="center" valign="middle">
                                    USD
                                </td>
                                <td align="center" valign="middle">
                                    VND
                                </td>
                                <td align="center" valign="middle">
                                    USD
                                </td>
                                <td align="center" valign="middle">
                                    VND
                                </td>
                                <td align="center" valign="middle">
                                    USD
                                </td>
                                <td align="center" valign="middle">
                                    VND
                                </td>
                                <td align="center" valign="middle">
                                    USD
                                </td>
                                <td align="center" valign="middle">
                                    VND
                                </td>
                                <td align="center" valign="middle">
                                    USD
                                </td>
                                <td align="center" valign="middle">
                                    VND
                                </td>
                                <td align="center" valign="middle">
                                    VND
                                </td>
                                <td align="center" valign="middle">
                                    VND
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:Literal ID="ltrYearMonth" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrRentUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnRentUsd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="RentUsdPaid" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrRentVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnRentVnd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="RentVndPaid" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrManagerUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnManagerUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ManagerUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrManagerVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnManagerVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ManagerVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrParkingUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnParkingUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ParkingUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrParkingVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnParkingVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ParkingVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrExtraTimeUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnExtraTimeUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ExtraTimeUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrExtraTimeVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnExtraTimeVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ExtraTimeVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrElecVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnElecVnd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="ElecVndPaid" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrWaterVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnWaterVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="WaterVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnServiceUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ServiceUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnServiceVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ServiceVndPaid"
                                        runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="SelectedList">
                                <td align="center">
                                    <asp:Literal ID="ltrYearMonth" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrRentUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnRentUsd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="RentUsdPaid" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrRentVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnRentVnd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="RentVndPaid" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrManagerUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnManagerUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ManagerUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrManagerVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnManagerVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ManagerVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrParkingUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnParkingUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ParkingUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrParkingVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnParkingVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ParkingVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrExtraTimeUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnExtraTimeUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ExtraTimeUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrExtraTimeVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnExtraTimeVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ExtraTimeVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrElecVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnElecVnd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="ElecVndPaid" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrWaterVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnWaterVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="WaterVndPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceUsd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnServiceUsd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ServiceUsdPaid"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceVnd" runat="server" /><br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnServiceVnd" runat="server" Text="Thu"
                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" CommandName="ServiceVndPaid"
                                        runat="server" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
                </table>
            </div>
            <div>
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
