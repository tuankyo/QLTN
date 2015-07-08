<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_MeetingRoomBooking.aspx.cs" Inherits="Man.Building.Room.BD_MeetingRoomBooking"
    Title="Đặt phòng họp" %>

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
                                        <asp:Label ID="ltrPage" runat="server" Text="Quản lý đặt phòng họp"></asp:Label>
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
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td colspan="12" align="center">
                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label" width="13%">
                                            Phòng
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </td>
                                        <td class="text_label" width="7%">
                                            Khu vực
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblRegional" runat="server"></asp:Label>
                                        </td>
                                        <td class="text_label" width="7%">
                                            Lầu
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblFloor" runat="server"></asp:Label>
                                        </td>
                                        <td class="text_label" width="10%">
                                            Diện tích
                                        </td>
                                        <td class="input_form" width="10%">
                                            <asp:Label ID="lblArea" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Phí thuê
                                        </td>
                                        <td colspan="11" class="input_form">
                                            <asp:Label ID="lblHourManagerPriceVND" runat="server"></asp:Label>VND
                                            <asp:Label ID="lblHourManagerPriceUSD" runat="server"></asp:Label>USD
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Ghi Chú
                                        </td>
                                        <td colspan="11" class="input_form">
                                            <asp:Label ID="lblComment" runat="server" MaxLength="200" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Khách hàng<font color="red">※</font>
                                        </td>
                                        <td colspan="5" class="input_form">
                                            <asp:DropDownList ID="drpCustomerId" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Ngày đặt<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtBookingDate" runat="server" Width="40%" AutoPostBack="true" OnTextChanged="txtBookingDate_TextChanged"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtBookingDate"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
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
                                            <asp:CheckBox ID="chkBookingType" runat="server" />
                                            <font color="red">Chọn: Tiền = Phí Thuê + VAT, Không chọn: Tiền = Phí
                                                Thuê x Giờ Thuê + VAT</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Phí thuê<font color="red">※</font>
                                        </td>
                                        <td colspan="5" class="input_form">
                                            <asp:TextBox ID="txtPriceVND" runat="server" Width="20%"></asp:TextBox>
                                            (VND)
                                            <asp:TextBox ID="txtPriceUSD" runat="server" Width="20%"></asp:TextBox>(USD)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            VAT<font color="red">※</font>
                                        </td>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtVAT" runat="server" Width="20%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Ghi chú
                                        </td>
                                        <td colspan="7">
                                            <asp:TextBox ID="txtComment" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="9">
                                            <asp:Button CssClass="btn_blue" ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click"
                                                OnClientClick="javascript:return confirm('Phòng họp sẽ được đặt?')" />
                                            <asp:HiddenField ID="hidId" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="content_form">
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    Khách hàng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Ngày đặt
                                                </td>
                                                <td align="center" valign="middle">
                                                    Từ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đến
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phí<br />
                                                    (VND/h)
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phí<br />
                                                    (USD/h)
                                                </td>
                                                <td align="center" valign="middle">
                                                    Dịch vụ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Xác nhận đặt
                                                </td>
                                                <td align="center" valign="middle">
                                                    Hủy
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
                                                <td align="center">
                                                    <asp:LinkButton ID="btnCustomer" runat="server" CommandName="EditCustomer" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrBookingDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrBookingHourFrom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrBookingHourTo" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnService" Text="+" CommandName="Service"
                                                        runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnConfirm" Text="Xác Nhận" CommandName="Confirm"
                                                        runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Hủy" CommandName="Delete"
                                                        runat="server" OnClientClick="javascript:return confirm('Thông tin đặt phòng sẽ được hủy?')" />
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
                                                <td align="center">
                                                    <asp:LinkButton ID="btnCustomer" runat="server" CommandName="EditCustomer" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrBookingDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrBookingHourFrom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrBookingHourTo" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnService" Text="+" CommandName="Service"
                                                        runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnConfirm" Text="Xác Nhận" CommandName="Confirm"
                                                        runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Hủy" CommandName="Delete"
                                                        runat="server" OnClientClick="javascript:return confirm('Thông tin đặt phòng sẽ được hủy?')" />
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
