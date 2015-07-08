<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_TarrifsElecWaterList.aspx.cs" Inherits="Man.Building.TarrifsElecWater.BD_TarrifsElecWaterList"
    Title="Danh Sách Biểu Phí" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upTarrifsElecWater" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Kỹ thuật &gt Nhập chỉ số Điện-Nước" runat="server"></asp:Label>
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
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    ID
                                                </td>
                                                <td align="center" valign="middle">
                                                    Nhóm biểu phí
                                                </td>
                                                <td align="center" valign="middle">
                                                    Định mức
                                                </td>
                                                <td align="center" valign="middle">
                                                    Chỉ số
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đơn giá (VND)
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đơn giá (USD)
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
                                                    <asp:Literal ID="ltrGroup" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrIndexFrom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
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
                                                    <asp:Literal ID="ltrGroup" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrIndexFrom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                                </td>
                                                <td align="right">
                                                    <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
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
                                        <td>
                                            <asp:Button CssClass="btn_blue_long" ID="Button1" runat="server" Text="Thêm Mới Nhóm Biểu Phí"
                                                OnClick="btnAddFeeGroup_Click" />
                                        </td>
                                        <td>
                                            <asp:Button CssClass="btn_blue_long" ID="Button2" runat="server" Text="Chỉnh Sửa Nhóm Biểu Phí"
                                                OnClick="btnUpdateFeeGroup_Click" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpFeeGroup" runat="server" Width="205px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hidType" runat="server" />
                                            <asp:Button CssClass="btn_blue_long" ID="btnAdd" runat="server" Text="Thêm Mới Định Mức Nhóm"
                                                OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
