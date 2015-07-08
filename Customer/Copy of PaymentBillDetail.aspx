<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="PaymentBillDetail.aspx.cs" Inherits="Man.Customer.PaymentBillDetail"
    Title="Thông Tin Chi Tiết Hóa Đơn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upRentContract" runat="server">
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
                                        <asp:Label ID="Label3" Text="Xuất Hóa Đơn" runat="server"></asp:Label>
                                    </a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <!-- end content form-->
                            <!-- List views form-->
                            <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                            <div class="content_form">
                                <div class="title_form">
                                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Khách Hàng"></asp:Label>
                                </div>
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td width="20%" valign="top" class="text_label">
                                            Mã khách hàng
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblCustomerId" runat="server"></asp:Label>
                                        </td>
                                        <td width="25%" valign="top" class="text_label">
                                            Khách hàng
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblName" runat="server" MaxLength="100" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div class="title_form">
                                                Thông Tin Hóa Đơn</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Hóa đơn tháng/năm<font color="red">※</font>
                                        </td>
                                        <td class="input_form" colspan="3">
                                            <asp:DropDownList ID="drpMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="btnSelect_Click">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="drpYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="btnSelect_Click">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" valign="top" class="text_label">
                                            Số Hóa Đơn<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtBillNo" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                                        </td>
                                        <td width="20%" valign="top" class="text_label">
                                            Ngày Xuất<font color="red">※</font>
                                        </td>
                                        <td style="font-size: xx-small">
                                            <asp:TextBox ID="txtBillDate" runat="server" MaxLength="100"
                                                Width="95%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtBillDate"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" valign="top" class="text_label">
                                            Tỉ giá USD - VND<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox Style="text-align: right" ID="txtUsdExchange" runat="server" MaxLength="100"
                                                Width="95%"></asp:TextBox>
                                        </td>
                                        <td width="20%" valign="top" class="text_label">
                                            Áp dụng lúc (dd/MM/yyyy)<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtUsdExchangeDate" runat="server" MaxLength="100"
                                                Width="95%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtUsdExchangeDate" Format="dd/MM/yyyy hh:mm:ss">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button CssClass="btn_blue" ID="btnCreate" runat="server" Text="Tạo Hóa Đơn"
                                                OnClick="btnSave_Click" Style="white-space: nowrap;" />
                                            <asp:Button CssClass="btn_blue" ID="btnView" runat="server" Text="Xem Hóa Đơn" OnClick="btnView_Click"
                                                Style="white-space: nowrap;" />
                                        </td>
                                    </tr>
                                </table>
                                <div id="divDetail" runat="server">
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" style="border-collapse: collapse">
                                        <tr>
                                            <td colspan="10">
                                                <div class="title_form">
                                                    <asp:Label runat="server" ID="Label4" Text="Tiền Thuê Phòng"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <asp:Repeater ID="rptRoomRent" runat="server" OnItemDataBound="rptRoomRentList_ItemDataBound"
                                            OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td rowspan="2" align="center">
                                                        Danh mục
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Diện tích<br />
                                                        (1)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Đơn giá<br />
                                                        (2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (3)=(1)*(2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        VAT(%)<br />
                                                        (4)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (5)=(3)+(4)
                                                    </td>
                                                </tr>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
                                                        (m2)
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
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Tổng cộng
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblRentUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblRentVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Đã trả
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblRentPaidUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblRentPaidVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Còn
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtRentPaidUSD" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtRentPaidVND" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <div id="divRent" runat="server">
                                            <tr>
                                                <td align="right" colspan="10">
                                                    <asp:Button ID="btnRentPaid" runat="server" CssClass="btn_blue" Text="Thu tiền" OnClick="btnRent_Click" />
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                    <div class="title_form">
                                        <asp:Label runat="server" ID="Label2" Text="Phí Quản Lý"></asp:Label>
                                    </div>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptRoomManager" runat="server" OnItemDataBound="rptRoomManagerList_ItemDataBound"
                                            OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td rowspan="2" align="center">
                                                        Danh mục
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Diện tích<br />
                                                        (1)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Đơn giá<br />
                                                        (2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (3)=(1)*(2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        VAT(%)<br />
                                                        (4)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (5)=(3)+(4)
                                                    </td>
                                                </tr>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
                                                        (m2)
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
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                    <td align="left" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Tổng cộng
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblMangagerUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblMangagerVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Đã trả
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblMangagerPaidUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblMangagerPaidVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Còn
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtManagerPaidUSD" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtManagerPaidVND" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <div id="divManager" runat="server">
                                            <tr>
                                                <td align="right" colspan="10">
                                                    <asp:Button ID="Button1" runat="server" CssClass="btn_blue" Text="Thu tiền" OnClick="btnManager_Click" />
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                    <div class="title_form">
                                        <asp:Label runat="server" ID="Label1" Text="Phí Gửi Xe"></asp:Label>
                                    </div>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptParking" runat="server" OnItemDataBound="rptParking_ItemDataBound">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td rowspan="2" align="center">
                                                        Danh mục
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Số lượng<br />
                                                        (1)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Đơn giá<br />
                                                        (2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (3)=(1)*(2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        VAT(%)<br />
                                                        (4)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Tổng cộng<br />
                                                        (5)=(3)+(4)
                                                    </td>
                                                </tr>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
                                                        (Chiếc)
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
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrNum" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrNum" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Tổng cộng
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblParkingUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblParkingVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Đã trả
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblParkingPaidUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblParkingPaidVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Còn
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtParkingPaidUSD" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtParkingPaidVND" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <div id="divParking" runat="server">
                                            <tr>
                                                <td align="right" colspan="10">
                                                    <asp:Button ID="Button2" runat="server" CssClass="btn_blue" Text="Thu tiền" OnClick="btnParking_Click" />
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                    <div class="title_form">
                                        <asp:Label runat="server" ID="Label7" Text="Phí Ngoài Giờ"></asp:Label>
                                    </div>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptExtraTime" runat="server" OnItemDataBound="rptExtraTime_ItemDataBound">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td rowspan="2" align="center">
                                                        Danh mục
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Số lượng<br />
                                                        (1)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Đơn giá<br />
                                                        (2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (3)=(1)*(2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        VAT(%)<br />
                                                        (4)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Tổng Cộng<br />
                                                        (5)=(3)+(4)
                                                    </td>
                                                </tr>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
                                                        Giờ(h)
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
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrWorkingDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrExtraHour" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrWorkingDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrExtraHour" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Tổng cộng
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblExtraTimeUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblExtraTimeVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Đã trả
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblExtraTimePaidUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblExtraTimePaidVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                Còn
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtExtraTimePaidUSD" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtExtraTimePaidVND" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <div id="divExtraTime" runat="server">
                                            <tr>
                                                <td align="right" colspan="10">
                                                    <asp:Button ID="Button3" runat="server" CssClass="btn_blue" Text="Thu tiền" OnClick="btnExtraTime_Click" />
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                    <div class="title_form">
                                        <asp:Label runat="server" ID="Label17" Text="Tiền Điện"></asp:Label>
                                    </div>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptElec" runat="server" OnItemDataBound="rptElect_ItemDataBound"
                                            OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td rowspan="2" align="center">
                                                        Khu vực
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Từ ngày
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Đến ngày
                                                    </td>
                                                    <td align="center" valign="middle" rowspan="2">
                                                        Chỉ số cũ (kwh)<br />
                                                        (1)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Chỉ số mới (kwh)<br />
                                                        (2)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Hệ số<br />
                                                        (3)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Lượng tiêu thụ<br />
                                                        (4)=[(2)-(1)]*(3)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Đơn giá<br />
                                                        (5)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        VAT(%)<br />
                                                        (6)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (7)=[(6)+(5)]*(4)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Phụ Thu(%)<br />
                                                        (8)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Tổng cộng<br />
                                                        (9)=(7)+(8)
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
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrDateFrom" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrDateTo" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrFromIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrToIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrUsed" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrDateFrom" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrDateTo" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrFromIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrToIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrUsed" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="14" align="right">
                                                Tổng cộng
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblElecUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblElecVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="14" align="right">
                                                Đã trả
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblElecPaidUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblElecPaidVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="14" align="right">
                                                Còn
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtElecPaidUSD" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtElecPaidVND" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <div id="divElec" runat="server">
                                            <tr>
                                                <td align="right" colspan="16">
                                                    <asp:Button ID="Button4" runat="server" CssClass="btn_blue" Text="Thu tiền" OnClick="btnElec_Click" />
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                    <div class="title_form">
                                        <asp:Label runat="server" ID="Label6" Text="Tiền Nước"></asp:Label>
                                    </div>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptWater" runat="server" OnItemDataBound="rptWater_ItemDataBound"
                                            OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td rowspan="2" align="center">
                                                        Khu vực
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Từ ngày
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Đến ngày
                                                    </td>
                                                    <td align="center" valign="middle" rowspan="2">
                                                        Chỉ số cũ (m3)<br />
                                                        (1)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Chỉ số mới (m3)<br />
                                                        (2)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Lượng tiêu thụ<br />
                                                        (3)=[(2)-(1)]
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Đơn giá<br />
                                                        (4)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        BVMT (%)<br />
                                                        (5)
                                                    </td>

                                                    <td colspan="2" align="center">
                                                        VAT(%)<br />
                                                        (6)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (7)=[(4) + (5) + (6)] x (3)
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Phụ Thu(%)<br />
                                                        (8)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Tổng cộng<br />
                                                        (9)=(7)+(8)
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
                                                    <td align="right" width="20%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrDateFrom" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrDateTo" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrFromIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrToIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrUsed" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                    <td align="right" width="20%">
                                                        <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrDateFrom" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrDateTo" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrFromIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrToIndex" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrUsed" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="3%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="14" align="right">
                                                Tổng cộng
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblWaterUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblWaterVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="14" align="right">
                                                Đã trả
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblWaterPaidUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblWaterPaidVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="14" align="right">
                                                Còn
                                            </td>
                                            <td align="right">
                                                <asp:TextBox Style="text-align: right" ID="txtWaterPaidUSD" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtWaterPaidVND" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <div id="divWater" runat="server">
                                            <tr>
                                                <td align="right" colspan="16">
                                                    <asp:Button ID="Button5" runat="server" CssClass="btn_blue" Text="Thu tiền" OnClick="btnWater_Click" />
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                    <div class="title_form">
                                        <asp:Label runat="server" ID="Label8" Text="Phí Khác"></asp:Label>
                                    </div>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptService" runat="server" OnItemDataBound="rptService_ItemDataBound">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td rowspan="2" align="center">
                                                        Danh mục
                                                    </td>
                                                    <td rowspan="2" align="center">
                                                        Ngày
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Số lượng<br />
                                                        (1)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Đơn giá<br />
                                                        (2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Thành tiền<br />
                                                        (3)=(1)*(2)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        VAT(%)<br />
                                                        (4)
                                                    </td>
                                                    <td colspan="2" align="center">
                                                        Tổng Cộng<br />
                                                        (5)=(3)+(4)
                                                    </td>
                                                </tr>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
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
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrService" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrServiceDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrService" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrServiceDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrVatVND" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceUSD" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="right" width="10%">
                                                        <asp:Literal ID="ltrLastPriceVND" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="9" align="right">
                                                Tổng cộng
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblServiceUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblServiceVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="9" align="right">
                                                Đã trả
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblServicePaidUSD" runat="server" />
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label ID="lblServicePaidVND" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="9" align="right">
                                                Còn
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtServicePaidUSD" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:TextBox Style="text-align: right" ID="txtServicePaidVND" runat="server" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <div id="divService" runat="server">
                                            <tr>
                                                <td align="right" colspan="11">
                                                    <asp:Button ID="Button6" runat="server" CssClass="btn_blue" Text="Thu tiền" OnClick="btnService_Click" />
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                    <asp:HiddenField ID="hidId" runat="server" />
                                    <asp:HiddenField ID="hidBillId" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
