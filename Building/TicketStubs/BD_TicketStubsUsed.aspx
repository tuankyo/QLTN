<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_TicketStubsUsed.aspx.cs" Inherits="Man.Building.TicketStubs.BD_TicketStubsUsed"
    Title="Thông Tin Vé Giữ Xe Lượt Được Sử Dụng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="content_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Thông Tin Vé Gửi Xe Đã Sử Dụng"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số seri
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblSeriNumber" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số seri đã sử dụng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPaidSeriNumber" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ngày sử dụng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUsedDate" runat="server" MaxLength="100" Width="95%" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                TargetControlID="txtUsedDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nhận từ<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUsedReceiveFrom" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Người nhận<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUsedReceiver" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số lượng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUsedMount" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Đơn giá<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUsedPrice" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi chú<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUsedComment" TextMode="MultiLine" Rows="3" runat="server" MaxLength="100"
                                Width="95%"></asp:TextBox>
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
                                    Số seri sử dụng
                                </td>
                                <td align="center" valign="middle">
                                    Ngày sử dụng
                                </td>
                                <td align="center" valign="middle">
                                    Nhận từ
                                </td>
                                <td align="center" valign="middle">
                                    Người nhận
                                </td>
                                <td align="center" valign="middle">
                                    Số lượng vé
                                </td>
                                <td align="center" valign="middle">
                                    Đơn giá
                                </td>
                                <td align="center" valign="middle">
                                    Tổng số tiền
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
                                <td align="left">
                                    <asp:Literal ID="ltrPaidSeriNumber" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedDate" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedReceiveFrom" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedReceiver" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedMount" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedPrice" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedSum" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue_short" CommandName="Delete" ID="btnDelete" runat="server"
                                        Text="Xóa" OnClientClick="javascript:return confirm('Thông tin sẽ được Xóa?')" />
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
                                    <asp:Literal ID="ltrPaidSeriNumber" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedDate" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedReceiveFrom" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedReceiver" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedMount" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedPrice" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrUsedSum" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue_short" CommandName="Delete" ID="btnDelete" runat="server"
                                        Text="Xóa" OnClientClick="javascript:return confirm('Thông tin sẽ được Xóa?')" />
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
                <div>
                    <asp:HiddenField ID="hidId" runat="server" />
                    <asp:HiddenField ID="hidAction" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
