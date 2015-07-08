<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_Maintenance.aspx.cs" Inherits="Man.Building.Maintenance.BD_Maintenance"
    Title="KẾ HOẠCH BẢO TRÌ HỆ THỐNG KỸ THUẬT TÒA NHÀ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdateProgress ID="upList" runat="server">
        <ProgressTemplate>
            <font color="Red">Đang thực hiện yêu cầu...</font>
        </ProgressTemplate>
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
                                <asp:Label ID="ltrPage" runat="server">KẾ HOẠCH BẢO TRÌ HỆ THỐNG KỸ THUẬT TÒA NHÀ</asp:Label>
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
                                <td width="15%" valign="top" class="text_label">
                                    Tháng<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:DropDownList ID="drpMonth" runat="server"/>
                                    <asp:DropDownList ID="drpYear" runat="server"/>
                                </td>
                            </tr>
                        </table>
                        <div class="title_form">
                            <asp:Label runat="server" ID="Label1" Text="Import File Lịch Làm Việc"></asp:Label>
                        </div>
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    File Import<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <input type="file" id="File1" name="File1" runat="server" />
                                    <asp:Button CssClass="btn_blue" ID="Button1" Text="Import Lịch" runat="server" OnClick="btnImport_Click"
                                        Style="white-space: nowrap;" />(file Excel:form mẫu đã cập nhật lịch làm việc)
                                </td>
                            </tr>
                        </table>
                        <div class="title_form">
                            <asp:Label runat="server" ID="Label2" Text="Xem và Cập nhật ngày bảo trì"></asp:Label>
                        </div>
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Ngày bảo trì
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtExecDateFrom" runat="server" Width="15%"></asp:TextBox>
                                    <asp:TextBox ID="txtExecDateTo" runat="server" Width="15%"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtExecDateFrom"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                        TargetControlID="txtExecDateTo" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Hệ thống
                                </td>
                                <td class="input_form">
                                    <asp:DropDownList ID="drpMainName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpMainName_OnSelectedIndexChanged" />
                                    Nội dung công việc
                                    <asp:DropDownList ID="drpSubName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button CssClass="btn_blue" ID="Button2" Text="Tìm kiếm" runat="server" OnClick="btnView_Click"
                                        Style="white-space: nowrap;" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td colspan="2">
                                    <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                    </cc:Pager>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                            OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
                                                        Hệ thống
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Nội dung công việc
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Tuần
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Bảo trì
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Ngày thực hiện
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Công ty thực hiện
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Mô tả
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Người giám sát
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Ghi chú
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Cập nhật
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
                                                        <asp:Literal ID="ltrMainName" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrSubName" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrWeek" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrIsMaintenance" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecDate" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecCompany" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecDescription" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecConfirmer" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnUpdate" runat="server"
                                                            Text="Cập nhật" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                                            CommandName="Delete" runat="server" Text="Xóa" />
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
                                                        <asp:Literal ID="ltrMainName" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrSubName" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrWeek" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrIsMaintenance" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecDate" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecCompany" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecDescription" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecConfirmer" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrExecComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnUpdate" runat="server"
                                                            Text="Cập nhật" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                                            CommandName="Delete" runat="server" Text="Xóa" />
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
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
