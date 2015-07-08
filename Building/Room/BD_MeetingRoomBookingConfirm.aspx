<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_MeetingRoomBookingConfirm.aspx.cs" Inherits="Man.Building.Room.BD_MeetingRoomBookingConfirm"
    Title="Xác Nhận Đặt Phòng Họp" %>

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
                                        <asp:Label ID="Label1" runat="server" Text="Xác nhận đặt phòng họp"></asp:Label>
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
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td colspan="12">
                                            <div class="title_form">
                                                Thông tin Phòng họp
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label" width="20%">
                                            Phòng
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </td>
                                        <td class="text_label">
                                            Khu vực
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblRegional" runat="server"></asp:Label>
                                        </td>
                                        <td class="text_label">
                                            Lầu
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblFloor" runat="server"></asp:Label>
                                        </td>
                                        <td class="text_label">
                                            Diện tích
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblArea" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Phí thuê
                                        </td>
                                        <td colspan="7" class="input_form">
                                            <asp:Label ID="lblHourManagerPriceVND" runat="server" Style="text-align: right"></asp:Label>(VND)
                                            <asp:Label ID="lblHourManagerPriceUSD" runat="server" Style="text-align: right"></asp:Label>(USD)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            VAT
                                        </td>
                                        <td colspan="7" class="input_form">
                                            <asp:Label ID="lblVat" runat="server" Style="text-align: right"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Ghi Chú
                                        </td>
                                        <td colspan="7" class="input_form">
                                            <asp:Label ID="lblComment" runat="server" MaxLength="200" Width="98%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="text_label" colspan="6">
                                            <div class="title_form">
                                                <asp:Label runat="server" ID="Label2" Text="Thông tin đặt Phhòng Họp"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Khách hàng
                                        </td>
                                        <td colspan="5" class="input_form">
                                            <asp:LinkButton ID="lnbCustomerId" runat="server" Width="98%" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Ngày đặt
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblBookingDate" runat="server" Width="100%" />
                                        </td>
                                        <td class="text_label">
                                            Từ<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:DropDownList ID="drpHourFrom" runat="server">
                                            </asp:DropDownList>
                                            <select id="drpMinuteFrom" runat="server">
                                                <option value="00">00</option>
                                                <option value="30">30</option>
                                            </select>
                                        </td>
                                        <td class="text_label">
                                            Đến<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:DropDownList ID="drpHourTo" runat="server">
                                            </asp:DropDownList>
                                            <select id="drpMinuteTo" runat="server">
                                                <option value="00">00</option>
                                                <option value="30">30</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Thuê trọn buổi
                                        </td>
                                        <td colspan="5" class="input_form">
                                            <asp:CheckBox ID="chkBookingType" runat="server" Enabled="false" />
                                            <font color="red">Chọn: Tiền = Phí Thuê + VAT, Không chọn: Tiền = Phí Thuê x Giờ
                                                Thuê + VAT</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Phí thuê<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtPriceVND" runat="server" Width="98%"></asp:TextBox>
                                        </td>
                                        <td class="labelNormal">
                                            VND
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtPriceUSD" runat="server" Width="98%"></asp:TextBox>
                                        </td>
                                        <td class="labelNormal">
                                            USD
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            VAT<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtVat" runat="server" Width="98%" Style="text-align: right"></asp:TextBox>
                                        </td>
                                        <td colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Ghi chú
                                        </td>
                                        <td colspan="5" class="input_form">
                                            <asp:TextBox ID="txtComment" runat="server" Width="98%"></asp:TextBox>
                                        </td>
                                    </tr>
                            </div>
                            </table>
                            <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                style="border-collapse: collapse">
                                <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                    OnItemCommand="rptList_ItemCommand">
                                    <HeaderTemplate>
                                        <tr>
                                            <td class="text_label" colspan="10">
                                                <div class="title_form">
                                                    <asp:Label runat="server" ID="Label2" Text="Thông tin Dịch vụ cộng thêm"></asp:Label></div>
                                            </td>
                                        </tr>
                                        <tr class="row_title">
                                            <td align="center" valign="middle">
                                                Dịch vụ
                                            </td>
                                            <td align="center" valign="middle">
                                                Số lượng
                                            </td>
                                            <td align="center" valign="middle">
                                                VAT
                                            </td>
                                            <td align="center" valign="middle">
                                                Đơn giá(VND)
                                            </td>
                                            <td align="center" valign="middle">
                                                Đơn giá(USD)
                                            </td>
                                            <td align="center" valign="middle">
                                                Tổng(VND)
                                            </td>
                                            <td align="center" valign="middle">
                                                Tổng(USD)
                                            </td>
                                            <td align="center" valign="middle">
                                                Ghi chú
                                            </td>
                                            <td align="center" valign="middle">
                                                Cập Nhật
                                            </td>
                                            <td align="center" valign="middle">
                                                Ngày Cập Nhật
                                            </td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td align="left">
                                                <asp:Literal ID="ltrService" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrVAT" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                            </td>
                                            <td align="left">
                                                <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrModifiedBy" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrModified" runat="server" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="SelectedList">
                                            <td align="left">
                                                <asp:Literal ID="ltrService" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrVAT" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrSumVND" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrSumUSD" runat="server"></asp:Literal>
                                            </td>
                                            <td align="left">
                                                <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrModifiedBy" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrModified" runat="server" />
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                            </table>
                            <table>
                                <tr>
                                    <td class="text_label" colspan="6">
                                        <div class="title_form">
                                            <asp:Label runat="server" ID="Label5" Text="Thông tin Tổng phí phải thu"></asp:Label></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text_label">
                                        Tiền thuê phòng họp
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblSumUSD" runat="server" />
                                    </td>
                                    <td class="labelNormal">
                                        USD
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblSumVND" runat="server" />
                                    </td>
                                    <td class="labelNormal" colspan="2">
                                        VND
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text_label">
                                        Tiền dịch vụ cộng thêm
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblSumServiceUSD" runat="server" />
                                    </td>
                                    <td class="labelNormal">
                                        USD
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblSumServiceVND" runat="server" />
                                    </td>
                                    <td colspan="2" class="labelNormal">
                                        VND
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text_label">
                                        Tổng số tiền phải trả
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblSumPriceUSD" runat="server" />
                                    </td>
                                    <td class="labelNormal">
                                        USD
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblSumPriceVND" runat="server" />
                                    </td>
                                    <td class="labelNormal">
                                        VND
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text_label">
                                        Tổng số tiền đã trả
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblPaidUSD" runat="server" />
                                    </td>
                                    <td class="labelNormal">
                                        USD
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:Label ID="lblPaidVND" runat="server" />
                                    </td>
                                    <td class="labelNormal">
                                        VND
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text_label">
                                        Còn nợ
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:TextBox ID="txtPaidUSD" runat="server" Width="98%" Style="text-align: right" />
                                    </td>
                                    <td class="labelNormal">
                                        USD
                                    </td>
                                    <td class="input_form" align="right">
                                        <asp:TextBox ID="txtPaidVND" runat="server" Width="98%" Style="text-align: right" />
                                    </td>
                                    <td class="labelNormal">
                                        VND
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <div class="title_form">
                                            <asp:Label runat="server" ID="Label3" Text="Thông tin hóa đơn"></asp:Label></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text_label">
                                        Ngày xuất Hóa Đơn<font color="red">※</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtContractDate" runat="server" Width="98%" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                                            TargetControlID="txtContractDate" Format="dd/MM/yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td class="text_label">
                                        Hóa Đơn số<font color="red">※</font>
                                    </td>
                                    <td colspan="3" class="input_form" align="left">
                                        <asp:TextBox ID="txtContractNo" runat="server" Width="98%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text_label">
                                        Tỉ giá quy đổi USD->VND<font color="red">※</font>
                                    </td>
                                    <td class="input_form" align="left">
                                        <asp:TextBox ID="txtRate" runat="server" Width="98%" />
                                    </td>
                                    <td class="text_label">
                                        Thời gian quy đổi<font color="red">※</font>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:TextBox ID="txtRateDate" runat="server" Width="98%" />
                                        <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtRateDate"
                                            Format="dd/MM/yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="4" class="labelNormal">
                                        <asp:Button CssClass="btn_blue" ID="btnConfirm" runat="server" Text="Xác nhận đặt"
                                            OnClick="btnConfirm_Click" OnClientClick="javascript:return confirm('Thông tin Xác nhận đặt phòng được lưu trữ?')" />
                                        <asp:Button CssClass="btn_blue" ID="btnDelete" runat="server" Text="Hủy đặt" OnClick="btnDelete_Click"
                                            OnClientClick="javascript:return confirm('Thông tin Xác nhận đặt phòng sẽ được hủy?')" />
                                    </td>
                                </tr>
                                <div id="divPaid" runat="server">
                                    <tr>
                                        <td colspan="6">
                                            <div class="title_form">
                                                <asp:Label runat="server" ID="lblBill" Text="Xuất hóa đơn"></asp:Label></div>
                                            <asp:Button CssClass="btn_blue" ID="btnPaid" runat="server" Text="Thu Tiền" OnClick="btnPaid_Click" />
                                            <asp:Button CssClass="btn_blue" ID="btnView" runat="server" Text="Xem Hóa Đơn" OnClick="btnView_Click" />
                                        </td>
                                    </tr>
                                </div>
                            </table>
                            <asp:HiddenField ID="hidId" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
