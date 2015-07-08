<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUpPrint.Master" AutoEventWireup="true"
    CodeBehind="PaymentBillDetailReview.aspx.cs" Inherits="Man.Customer.PaymentBillDetailReview"
    Title="Thông Tin Chi Tiết Hóa Đơn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function displayMessage(printContent) {
            var inf = printContent;
            win = window.open("print.htm", 'toolbar = no, status = no');
            win.document.write(inf);
            win.document.close(); // new line
        }
        function printdiv(printpage) {
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body>";
            var newstr = document.forms.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdateProgress ID="upList" runat="server">
        <ProgressTemplate>
            <font color="Red">Đang thực hiện yêu cầu...</font>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <table>
        <tr>
            <td>
                Nếu Browser đang dùng là FireFox thì Chọn <asp:Button runat="server" Text="Print Preview" ID="Button1" OnClientClick="javascript:displayMessage(content_form.innerHTML)" /> hiển thị nội dung cần in, sau đó chọn Print từ Browser
            </td>
        </tr>
    </table>
    <div class="content_form" id="content_form">
        <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
        <table cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td colspan="4">
                    <div class="title_form">
                        Thông Tin Hóa Đơn</div>
                </td>
            </tr>
            <tr>
                <td width="15%" valign="middle" class="text_label">
                    Khách hàng
                </td>
                <td class="input_form" colspan="9">
                    <asp:Label ID="lblCustomerId" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text_label">
                    Hóa đơn tháng/năm
                </td>
                <td class="input_form">
                    <asp:Label ID="lblYearMonth" runat="server"></asp:Label>
                </td>
                <td valign="middle" class="text_label">
                    Số Hóa Đơn
                </td>
                <td class="input_form">
                    <asp:Label ID="lblBillNo" runat="server"></asp:Label>
                </td>
                <td valign="middle" class="text_label">
                    Ngày Xuất
                </td>
                <td class="input_form">
                    <asp:Label ID="lblBillDate" runat="server"></asp:Label>
                </td>
                <td valign="middle" class="text_label">
                    Tỉ giá Usd-Vnd
                </td>
                <td class="input_form">
                    <asp:Label ID="lblUsdExchange" runat="server"></asp:Label>
                </td>
                <td valign="middle" class="text_label">
                    Áp dụng lúc
                </td>
                <td class="input_form">
                    <asp:Label ID="lblUsdExchangeDate" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        </br>
        <br />
        <div id="divDetail" runat="server">
            <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                style="border-collapse: collapse">
                <tr>
                    <td colspan="10">
                        <div class="title_form">
                            <asp:Label runat="server" ID="Label4" Text="Tiền Thuê"></asp:Label>
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
                                Tổng cộng<br />
                                (5)=(3)+(4)
                            </td>
                        </tr>
                        <tr class="row_title">
                            <td align="center" valign="middle" width="6%">
                                (m2)
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="SelectedList">
                            <td align="left">
                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="8" align="right">
                        Tổng cộng
                    </td>
                    <td align="right">
                        <asp:Label ID="lblRentUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblRentVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" align="right">
                        Đã trả
                    </td>
                    <td align="right">
                        <asp:Label ID="lblRentPaidUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblRentPaidVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" align="right">
                        Còn
                    </td>
                    <td align="right">
                        <asp:Label ID="lblRentPaidUsdRemain" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblRentPaidVndRemain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
            <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                style="border-collapse: collapse">
                <tr>
                    <td colspan="10">
                        <div class="title_form">
                            <asp:Label runat="server" ID="Label2" Text="Phí Quản Lý"></asp:Label>
                        </div>
                    </td>
                </tr>
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
                                Tổng cộng<br />
                                (5)=(3)+(4)
                            </td>
                        </tr>
                        <tr class="row_title">
                            <td align="center" valign="middle" width="6%">
                                (m2)
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="SelectedList">
                            <td align="left">
                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="8" align="right">
                        Tổng cộng
                    </td>
                    <td align="right">
                        <asp:Label ID="lblManagerUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblManagerVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" align="right">
                        Đã trả
                    </td>
                    <td align="right">
                        <asp:Label ID="lblManagerPaidUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblManagerPaidVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" align="right">
                        Còn
                    </td>
                    <td align="right">
                        <asp:Label ID="lblManagerPaidUsdRemain" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblManagerPaidVndRemain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
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
                            <td align="center" valign="middle" width="6%">
                                (Chiếc)
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrNum" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="SelectedList">
                            <td align="left">
                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrNum" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="8" align="right">
                        Tổng cộng
                    </td>
                    <td align="right">
                        <asp:Label ID="lblParkingUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblParkingVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" align="right">
                        Đã trả
                    </td>
                    <td align="right">
                        <asp:Label ID="lblParkingPaidUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblParkingPaidVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="8" align="right">
                        Còn
                    </td>
                    <td align="right">
                        <asp:Label ID="lblParkingPaidUsdRemain" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblParkingPaidVndRemain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
            <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                style="border-collapse: collapse">
                <tr>
                    <td colspan="11">
                        <div class="title_form">
                            <asp:Label runat="server" ID="Label7" Text="Phí Ngoài Giờ"></asp:Label>
                        </div>
                    </td>
                </tr>
                <asp:Repeater ID="rptExtraTime" runat="server" OnItemDataBound="rptExtraTime_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="row_title">
                            <td rowspan="2" align="center">
                                Danh mục
                            </td>
                            <td rowspan="2" align="center">
                                Loại
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
                            <td align="center" valign="middle" width="6%">
                                Giờ(h)
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                <asp:Literal ID="ltrWorkingDate" runat="server"></asp:Literal>
                            </td>
                            <td align="left">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrExtraHour" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="SelectedList">
                            <td align="left">
                                <asp:Literal ID="ltrWorkingDate" runat="server"></asp:Literal>
                            </td>
                            <td align="left">
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrExtraHour" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="9" align="right">
                        Tổng cộng
                    </td>
                    <td align="right">
                        <asp:Label ID="lblExtraTimeUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblExtraTimeVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9" align="right">
                        Đã trả
                    </td>
                    <td align="right">
                        <asp:Label ID="lblExtraTimePaidUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblExtraTimePaidVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9" align="right">
                        Còn
                    </td>
                    <td align="right">
                        <asp:Label ID="lblExtraTimePaidUsdRemain" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblExtraTimePaidVndRemain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
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
                            <td align="center">
                                Đơn giá<br />
                                (5)
                            </td>
                            <td align="center">
                                VAT(%)<br />
                                (6)
                            </td>
                            <td align="center">
                                Thành tiền<br />
                                (7)=[(6)+(5)]*(4)
                            </td>
                            <td rowspan="2" align="center">
                                Hao phí(%)<br />
                                (8)
                            </td>
                            <td rowspan="2" align="center">
                                Tỉ lệ dùng(%)<br />
                                (9)
                            </td>
                            <td align="center">
                                Tổng cộng<br />
                                (10)=((7)+(8))*(9)/100
                            </td>
                        </tr>
                        <tr class="row_title">
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="right">
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
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrElecPricePercent" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="SelectedList">
                            <td align="right">
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
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrElecPricePercent" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="12" align="right">
                        Tổng cộng
                    </td>
                    <td align="right">
                        <asp:Label ID="lblElecVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="12" align="right">
                        Đã trả
                    </td>
                    <td align="right">
                        <asp:Label ID="lblElecPaidVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="12" align="right">
                        Còn
                    </td>
                    <td align="right">
                        <asp:Label ID="lblElecPaidVndRemain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
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
                            <td rowspan="2" align="center">
                                Đơn giá<br />
                                (4)
                            </td>
                            <td align="center">
                                BVMT (%)<br />
                                (5)
                            </td>
                            <td align="center">
                                VAT(%)<br />
                                (6)
                            </td>
                            <td align="center">
                                Thành tiền<br />
                                (7)=[(6)+(5)]*(4)
                            </td>
                            <td rowspan="2" align="center">
                                Phụ thu(%)<br />
                                (8)
                            </td>
                            <td rowspan="2" align="center">
                                Tỉ lệ dùng(%)<br />
                                (9)
                            </td>
                            <td align="center">
                                Tổng cộng<br />
                                (10)=((7)+(8))*(9)/100
                            </td>
                        </tr>
                        <tr class="row_title">
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="right">
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
                                <asp:Literal ID="ltrUsed" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrWaterPricePercent" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="SelectedList">
                            <td align="right">
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
                                <asp:Literal ID="ltrUsed" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrWaterPricePercent" runat="server"></asp:Literal>
                            </td>
                            <td align="right" width="3%">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="12" align="right">
                        Tổng cộng
                    </td>
                    <td align="right">
                        <asp:Label ID="lblWaterVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="12" align="right">
                        Đã trả
                    </td>
                    <td align="right">
                        <asp:Label ID="lblWaterPaidVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="12" align="right">
                        Còn
                    </td>
                    <td align="right">
                        <asp:Label ID="lblWaterPaidVndRemain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
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
                                Tổng cộng<br />
                                (5)=(3)+(4)
                            </td>
                        </tr>
                        <tr class="row_title">
                            <td align="center" valign="middle" width="6%">
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                            <td align="center" valign="middle" width="6%">
                                Usd
                            </td>
                            <td align="center" valign="middle" width="10%">
                                Vnd
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="right">
                                <asp:Literal ID="ltrService" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrServiceDate" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="SelectedList">
                            <td align="right">
                                <asp:Literal ID="ltrService" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrServiceDate" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrPriceVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrSumVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrVatVnd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceUsd" runat="server"></asp:Literal>
                            </td>
                            <td align="right">
                                <asp:Literal ID="ltrLastPriceVnd" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="9" align="right">
                        Tổng cộng
                    </td>
                    <td align="right">
                        <asp:Label ID="lblServiceUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblServiceVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9" align="right">
                        Đã trả
                    </td>
                    <td align="right">
                        <asp:Label ID="lblServicePaidUsd" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="lblServicePaidVnd" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="9" align="right">
                        Còn
                    </td>
                    <td align="right">
                        <asp:Label ID="lblServicePaidUsdRemain" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblServicePaidVndRemain" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
            <asp:HiddenField ID="hidId" runat="server" />
            <asp:HiddenField ID="hidYearMonths" runat="server" />
        </div>
    </div>
</asp:Content>
