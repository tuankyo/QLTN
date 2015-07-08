<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_TicketStubsList.aspx.cs" Inherits="Man.Building.TicketStubs.BD_TicketStubsList"
    Title="Danh sách Vé Giữ Xe Lượt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_TicketStubs" runat="server">
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
                                        <asp:Label ID="ltrPage" runat="server">Vé gửi xe</asp:Label>
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
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtSerialNo" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="left" width="20%">
                                            <asp:TextBox ID="txtReceiveDateFrom" runat="server" Width="45%"></asp:TextBox>
                                            <asp:TextBox ID="txtReceiveDateTo" runat="server" Width="45%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtReceiveDateFrom" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                TargetControlID="txtReceiveDateTo" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtReceiveFrom" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtReceiver" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="center" colspan="6">
                                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    Số seri
                                                </td>
                                                <td align="center" valign="middle">
                                                    Ngày nhận
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
                                                    Tổng số tiền
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đã sử dụng
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
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrReceiveDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrReceiveFrom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrReceiver" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrSum" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Button CssClass="btn_blue" ID="btnUsed" runat="server" Text="Ghi nhận" />
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
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrReceiveDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrReceiveFrom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrReceiver" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrSum" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Button CssClass="btn_blue" ID="btnUsed" runat="server" Text="Ghi nhận" />
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
                                <br />
                                <asp:Button CssClass="btn_blue" ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
