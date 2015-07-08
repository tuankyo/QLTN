<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_SuppliesGroupList.aspx.cs" Inherits="Man.Building.Supplies.BD_SuppliesGroupList"
    Title="Nhóm Vật Tư-Thiết Bị" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Supplies" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Quản lý Nhóm" runat="server"></asp:Label>
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
                                                    Nhóm
                                                </td>
                                                <td align="center" valign="middle">
                                                    Bảo trì
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align="left">
                                                    <asp:Literal ID="ltrGroupName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Button CssClass="btn_blue" ID="btnSchedule" CommandName="Schedule" Text="Định kỳ"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="SelectedList">
                                                <td align="left">
                                                    <asp:Literal ID="ltrGroupName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Button CssClass="btn_blue" ID="btnSchedule" CommandName="Schedule" Text="Định kỳ"
                                                        runat="server" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <asp:HiddenField ID="hidSuppliesType" runat="server" />
                                <asp:DropDownList ID="drpYear" runat="server">
                                </asp:DropDownList>
                                <asp:Button CssClass="btn_blue" ID="btnSchedule" Text="Xuất file" OnClick="btnExport_Click"
                                    runat="server" />
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
