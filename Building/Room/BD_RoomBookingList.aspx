<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_RoomBookingList.aspx.cs" Inherits="Man.Building.Room.BD_RoomBookingList"
    Title="Thông Tin HĐ Thuê Phòng Họp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Room" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">Đang thực hiện yêu cầu...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <div class="row_midpages">
                <div class="width_midpages">
                    <!-- box content main -->
                    <div class="box_contentmain">
                        <!-- end title content main -->
                        <div class="bgtitle_main">
                            <div class="tabs_menu">
                                <ul>
                                    <li class="current"><a href="">
                                        <asp:Label ID="ltrPage" Text="Danh sách Hóa đơn thuê phòng họp" runat="server"></asp:Label>
                                    </a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <div class="content_form">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td colspan="4">
                                            <div class="title_form">
                                                <asp:Label runat="server" ID="Label2" Text="Danh sách Khu vực Phòng họp: Được đặt thuê/Đã xác nhận thuê"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="text_label">
                                            Ngày thuê<font color="red">※</font>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="100" Width="30%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            ~
                                            <asp:TextBox ID="txtToDate" runat="server" MaxLength="100" Width="30%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                TargetControlID="txtToDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td width="10%" class="text_label">
                                            Khách Hàng
                                        </td>
                                        <td class="input_form" align="left">
                                            <asp:TextBox ID="txtCustomer" runat="server" Width="98%"></asp:TextBox>
                                        </td>
                                        <td width="10%" class="text_label" align="left">
                                            Phòng họp
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtRoomName" runat="server" Width="98%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td class="text_label">
                                            Tình trạng
                                        </td>
                                        <td class="input_form" colspan="3" align="left">
                                            <asp:RadioButton ID="optBook" runat="server" Text="Đặt chưa Xác nhận"
                                                GroupName="Dept" />&nbsp;&nbsp;
                                            <asp:RadioButton ID="optDept" runat="server" Text="Đã xác nhận nhưng còn nợ"
                                                GroupName="Dept" />&nbsp;&nbsp;
                                            <asp:RadioButton ID="optNoDept" runat="server" Text="Đã xác nhận không nợ" GroupName="Dept" />&nbsp;&nbsp;
                                            <asp:RadioButton ID="optAll" Checked="true" runat="server" Text="Tất cả" GroupName="Dept" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button CssClass="btn_blue" ID="btnSearch" runat="server" Text="Lọc Dữ Liệu"
                                                OnClick="btnSearch_Click" />
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
                                                <td align="center" valign="middle" rowspan="2">
                                                    Khách Hàng
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
                                                <td align="center" valign="middle" rowspan="2">
                                                    Chi Tiết
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
                                                    <asp:Literal ID="ltrCustomerName" runat="server"></asp:Literal>
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
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrDeptVND" runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDetail" runat="server" Text="Chi tiết"
                                                        CommandName="Detail" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="SelectedList">
                                                <td align="center">
                                                    <asp:Literal ID="ltrBookingId" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrCustomerName" runat="server"></asp:Literal>
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
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrDeptVND" runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDetail" runat="server" Text="Chi tiết"
                                                        CommandName="Detail" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
