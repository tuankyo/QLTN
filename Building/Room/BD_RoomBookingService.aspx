<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_RoomBookingService.aspx.cs" Inherits="Man.Building.Room.BD_RoomBookingService"
    Title="Thông Tin Đặt phòng họp - Dịch vụ cộng thêm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Đặt phòng họp - Dịch vụ cộng thêm"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Dịch vụ<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtService" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số lượng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMount" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Đơn vị<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtUnit" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Đơn giá(VND)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPriceVND" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Đơn giá(USD)<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPriceUSD" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            VAT<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtVAT" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
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
                                    Dịch vụ
                                </td>
                                <td align="center" valign="middle">
                                    Số lượng
                                </td>
                                <td align="center" valign="middle">
                                    Đơn giá<br />
                                    (VND)
                                </td>
                                <td align="center" valign="middle">
                                    Đơn giá<br />
                                    (USD)
                                </td>
                                <td align="center" valign="middle">
                                    VAT
                                </td>
                                <td align="center" valign="middle">
                                    Ghi chú
                                </td>
                                <td align="center" valign="middle">
                                    Xóa
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
                                <td align="right">
                                    <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrVAT" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"/>
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
                                <td align="right">
                                    <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrVAT" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"/>
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
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
