<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="PaymentList.aspx.cs" Inherits="Man.Customer.PaymentList" Title="Danh Sách Thu Chi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upCustomer" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Quản lý tài chính &gt Quản lý Thu Chi" runat="server"></asp:Label>
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
                                        <td align="center" width="150px">
                                            <asp:TextBox ID="txtDateFrom" runat="server" Width="65px"></asp:TextBox>
                                            <asp:TextBox ID="txtDateTo" runat="server" Width="65px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                TargetControlID="txtDateFrom" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtDateTo" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td align="left" width="110px">
                                            <asp:DropDownList ID="drpMonth" runat="server" />
                                            <asp:DropDownList ID="drpYear" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCustomerId" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="drpPaymentType" runat="server" Width="100px" />
                                        </td>
                                        <td align="left">
                                            <select id="drpPaidType" runat="server">
                                                <option value=""></option>
                                                <option value="1">Thu</option>
                                                <option value="0">Chi</option>
                                            </select>
                                        </td>
                                        <td align="center" colspan="8">
                                            <asp:Button CssClass="btn_blue" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    Ngày
                                                </td>
                                                <td align="center" valign="middle">
                                                    Hóa đơn tháng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Mã KH
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phí
                                                </td>
                                                <td align="center" valign="middle">
                                                    Thu/Chi
                                                </td>
                                                <td align="center" valign="middle">
                                                    Số tiền (USD)
                                                </td>
                                                <td align="center" valign="middle">
                                                    Số tiền (VND)
                                                </td>
                                                <td align="center" valign="middle">
                                                    Xóa
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
                                                    <asp:LinkButton ID="btnView" CommandName="View" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrYearMonth" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrCustomerId" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrPaymentType" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrPaidType" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrMoneyUSD" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrMoneyVND" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" runat="server" Text="Xóa" CommandName="Delete"
                                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
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
                                                    <asp:LinkButton ID="btnView" CommandName="View" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrYearMonth" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrCustomerId" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrPaymentType" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrPaidType" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrMoneyUSD" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrMoneyVND" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" runat="server" Text="Xóa" CommandName="Delete"
                                                        OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
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
                            <!-- end List views form-->
                        </div>
                        <!-- end mid content main -->
                        <!-- bottom content main -->
                        <div class="bgbottom_main">
                        </div>
                        <!-- end bottom content main -->
                    </div>
                    <!-- end box content main -->
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
