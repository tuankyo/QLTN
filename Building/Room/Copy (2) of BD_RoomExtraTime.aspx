<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_RoomExtraTime.aspx.cs" Inherits="Man.Building.Room.BD_RoomExtraTime"
    Title="Phòng Đăng Ký Làm Ngoài Giờ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Phòng"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã Phòng
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblRoomId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Phòng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblName" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Khu vực<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblArea" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Lầu<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblFloor" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                </table>
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Làm ngoài giờ"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ngày làm việc <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtFromWD" runat="server" MaxLength="100" Width="40%"></asp:TextBox>-
                            <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtFromWD"
                                Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <asp:TextBox ID="txtEndWD" runat="server" MaxLength="100" Width="40%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                TargetControlID="txtEndWD" Format="dd/MM/yyyy">
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
                            Thời gian ngoài giờ(h)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtExtraHour" runat="server" MaxLength="100" Width="40%">
                            </asp:TextBox>(ghi chính xác số giờ VD: 2h30 -> 2,5)
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Khách Hàng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpCustomerId" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="100" Rows="3" TextMode="MultiLine"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
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
                                <td align="center" valign="middle">
                                    Ngày làm việc
                                </td>
                                <td align="center" valign="middle">
                                    Bill năm/tháng
                                </td>
                                <td align="center" valign="middle">
                                    Khách hàng
                                </td>
                                <td align="center" valign="middle">
                                    Thời gian làm ngoài giờ
                                </td>
                                <td align="center" valign="middle">
                                    Ghi chú
                                </td>
                                <td align="center" valign="middle">
                                    Xóa
                                </td>
                                <td align="center" valign="middle">
                                    Người Cập Nhật
                                </td>
                                <td align="center" valign="middle">
                                    Ngày Cập Nhật
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <asp:Literal ID="ltrWorkingDate" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrYearMonth" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrCustomerId" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrExtraHour" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                        runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
                                    <asp:Literal ID="ltrWorkingDate" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrYearMonth" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrCustomerId" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrExtraHour" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                        runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
