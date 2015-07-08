<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_StaffList.aspx.cs" Inherits="Man.Building.Staff.BD_StaffList"
    Title="Danh sách Nhân viên" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Staff" runat="server">
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
                                        <asp:Label ID="ltrPage" runat="server"></asp:Label>
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
                                                    Mã Nhân Viên
                                                </td>
                                                <td align="center" valign="middle">
                                                    Họ Tên
                                                </td>
                                                <td align="center" valign="middle">
                                                    Địa chỉ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Điện thoại
                                                </td>
                                                <td align="center" valign="middle">
                                                    Chức vụ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Làm ngoài giờ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đánh giá
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
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrJobName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnExtraTime" runat="server" CommandName="extra"
                                                        Text="Làm thêm" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnEval" runat="server" CommandName="eval" Text="Đánh giá" />
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
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrJobName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnExtraTime" runat="server" CommandName="extra"
                                                        Text="Làm thêm" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnEval" runat="server" CommandName="eval" Text="Đánh giá" />
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
                                <asp:HiddenField ID="hidJobType" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
