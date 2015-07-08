<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListUser.aspx.cs" Inherits="Man.User.ListUser" Title="Danh Sách Người Dùng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upListUser" runat="server">
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
                                        <asp:Label ID="ltrPage" runat="server" Text="Danh Sách Người Dùng"></asp:Label>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <!-- end content form-->
                            <!-- List views form-->
                            <asp:MultiValidator ID="MultiValidator1" runat="server" Align="Center" />
                            <div class="content_form">
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td class="text_label">
                                            Tên Truy Cập
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox runat="server" ID="txtUserName" Width="100px" />
                                        </td>
                                        <td class="text_label" style="width: 50px">
                                            Quyền hạn
                                        </td>
                                        <td class="input_form">
                                            <asp:DropDownList ID="drpUserType" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="center">
                                            <asp:Button CssClass="btn_blue" runat="server" ID="btnSearch" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:MultiValidator ID="mvMessage" runat="server" />
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    Tên Truy Cập
                                                </td>
                                                <td align="center" valign="middle">
                                                    Tên Đầy Đủ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Quản lý tòa nhà
                                                </td>
                                                <td align="center" valign="middle">
                                                    Email
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đang sử dụng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Truy Cập Lần Cuối
                                                </td>
                                                <td colspan="2" align="center" align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnAdd" runat="server" Text="Thêm Mới"/>
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="height: 22px;">
                                                    <asp:Literal ID="ltrUserId" runat="server" Visible="false"></asp:Literal>
                                                    <asp:Literal ID="ltrUserName" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltrFullName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center" style="white-space: nowrap; width: 90px;">
                                                    <asp:Literal ID="ltrBuildingName" runat="server"></asp:Literal>
                                                </td>
                                                <td style="white-space: nowrap;" align="center">
                                                    <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                                </td>
                                                <td style="white-space: nowrap; width: 50px;" align="center">
                                                    <asp:CheckBox ID="chkOnline" runat="server" Enabled="false" />
                                                </td>
                                                <td style="white-space: nowrap; width: 120px;" align="center">
                                                    <asp:Literal ID="ltrLastLoginDate" runat="server"></asp:Literal>
                                                </td>
                                                <td style="white-space: nowrap;" align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server" Text="Sửa" />
                                                </td>
                                                <td style="white-space: nowrap;" align="center">
                                                    <asp:LinkButton ID="btnDelete" CommandName="Delete" runat="server" Text="Xóa" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="SelectedList">
                                                <td style="height: 22px;">
                                                    <asp:Literal ID="ltrUserId" runat="server" Visible="false"></asp:Literal>
                                                    <asp:Literal ID="ltrUserName" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltrFullName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center" style="white-space: nowrap; width: 90px;">
                                                    <asp:Literal ID="ltrBuildingName" runat="server"></asp:Literal>
                                                </td>
                                                <td style="white-space: nowrap;" align="center">
                                                    <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                                </td>
                                                <td style="white-space: nowrap; width: 50px;" align="center">
                                                    <asp:CheckBox ID="chkOnline" runat="server" Enabled="false" />
                                                </td>
                                                <td style="white-space: nowrap; width: 120px;" align="center">
                                                    <asp:Literal ID="ltrLastLoginDate" runat="server"></asp:Literal>
                                                </td>
                                                <td style="white-space: nowrap;" align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server" Text="Sửa" />
                                                </td>
                                                <td style="white-space: nowrap;" align="center">
                                                    <asp:LinkButton ID="btnDelete" CommandName="Delete" runat="server" Text="Xóa" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
