<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="AllPayRoomBooking.aspx.cs" Inherits="Man.Building.Room.AllPayRoomBooking"
    Title="Thông Tin HĐ Thuê Phòng Họp" %>

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
                                    Mã HĐ
                                </td>
                                <td align="center" valign="middle" width="8%" rowspan="2">
                                    Số HĐ
                                </td>
                                <td align="center" valign="middle" width="8%" rowspan="2">
                                    Ngày thuê
                                </td>
                                <td align="center" valign="middle" rowspan="2">
                                    Khu vực thuê
                                </td>
                                <td align="center" valign="middle" rowspan="2">
                                    Thời gian
                                </td>
                                <td align="center" valign="middle" rowspan="2">
                                    Tỉ giá USD/VND
                                </td>
                                <td align="center" valign="middle" colspan="2">
                                    Phí thuê phòng
                                </td>
                                <td align="center" valign="middle" colspan="2">
                                    Dịch vụ cộng thêm
                                </td>
                                <td align="center" valign="middle" colspan="2">
                                    Đã trả
                                </td>
                                <td align="center" valign="middle" colspan="2">
                                    Nợ
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
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:Literal ID="ltrBookingId" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrContractNo" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrContractDate" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrName" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrTime" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrRate" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrLastPriceUSD" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrLastPriceVND" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceLastPriceUSD" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceLastPriceVND" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrPaidUSD" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrPaidVND" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrDeptUSD" runat="server" />
                                    <br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnDeptUsd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="DeptUsdPaid"/>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrDeptVND" runat="server" />
                                    <br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnDeptVnd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="DeptVndPaid"/>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="SelectedList">
                                <td align="center">
                                    <asp:Literal ID="ltrBookingId" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrContractNo" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrContractDate" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrName" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrTime" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrRate" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrLastPriceUSD" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrLastPriceVND" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceLastPriceUSD" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrServiceLastPriceVND" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrPaidUSD" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrPaidVND" runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrDeptUSD" runat="server" />
                                    <br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnDeptUsd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="DeptUsdPaid"/>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrDeptVND" runat="server" />
                                    <br />
                                    <asp:Button CssClass="btn_blue_short" ID="btnDeptVnd" runat="server" Text="Thu" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="DeptVndPaid"/>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
                </table>
            </div>
            <div>
                <asp:HiddenField ID="hidCustomerId" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
