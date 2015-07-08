<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_StaffSchedule.aspx.cs" Inherits="Man.Building.Staff.BD_StaffSchedule"
    Title="Lịch làm việc Nhân viên" %>

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
                                <asp:Label ID="ltrPage" runat="server"></asp:Label>
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
                        <div class="title_form">
                            <asp:Label runat="server" ID="lblHeader" Text="Xuất File Lịch Làm Việc"></asp:Label>
                        </div>
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Tháng<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:DropDownList ID="drpMonth" runat="server" />
                                    <asp:DropDownList ID="drpYear" runat="server" />
                                    <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Xuất Lịch" runat="server"
                                        OnClick="btnExport_Click" Style="white-space: nowrap;" />
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
                                        Style="white-space: nowrap;"/>
                                </td>
                            </tr>
                        </table>
                        <div class="title_form">
                            <asp:Label runat="server" ID="Label2" Text="Xem và Cập nhật Lịch Làm Việc"></asp:Label>
                        </div>
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Ngày
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtWorkingDate" runat="server" Width="15%"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtWorkingDate"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    Nhân viên
                                    <asp:DropDownList ID="drpStaff" runat="server" />
                                    <asp:Button CssClass="btn_blue" ID="Button2" Text="Xem Lịch" runat="server" OnClick="btnView_Click"
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
                                                        Mã nhân viên
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Họ tên
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Ngày làm việc
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Vị trí
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Ca
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
                                                        <asp:LinkButton CommandName="View" ID="btnView" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrName" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrWorkingDate" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpWorkingPlace" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrWorkingHour" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue" ID="btnUpdate" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                                            CommandName="Update" runat="server" Text="Cập nhật" />
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
                                                        <asp:LinkButton CommandName="View" ID="btnView" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrName" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrWorkingDate" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpWorkingPlace" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrWorkingHour" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue" ID="btnUpdate" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                                            CommandName="Update" runat="server" Text="Cập nhật" />
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
                        <div>
                            <asp:HiddenField ID="hidId" runat="server" />
                            <asp:HiddenField ID="hidAction" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="hidJobType" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
