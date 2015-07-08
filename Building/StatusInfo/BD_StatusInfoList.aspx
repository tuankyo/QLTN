<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_StatusInfoList.aspx.cs" Inherits="Man.Building.StatusInfo.BD_StatusInfoList"
    Title="Thông tin lịch sử tòa nhà" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_StatusInfo" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Quản lý hoạt động &gt Tình Trạng Lịch Sử" runat="server"></asp:Label>
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
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1">
                                    <tr class="text_label">
                                        <td align="center" width="20%">
                                            <asp:TextBox ID="txtStatusDateFrom" Width="45%" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtStatusDateTo" Width="45%" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtStatusDateFrom" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                TargetControlID="txtStatusDateTo" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td align="left" width="10%">
                                            <asp:TextBox ID="txtStatus" Width="100%" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="left" width="10%">
                                            <asp:TextBox ID="txtRegion" Width="100%" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="left" width="10%">
                                            <asp:TextBox ID="txtFloor" Width="100%" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="center" width="10%">
                                            <asp:TextBox ID="txtRoom" Width="100%" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="center" width="10%">
                                            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="left" width="10%">
                                            <asp:TextBox ID="txtComment" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="center" colspan="2">
                                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
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
                                                    Tình trạng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Khu vực
                                                </td>
                                                <td align="center" valign="middle">
                                                    Lầu
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phòng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Mô tả
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
                                                    <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRegion" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrRoom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
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
                                                    <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRegion" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrRoom" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
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
                                <asp:HiddenField ID="hidType" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
