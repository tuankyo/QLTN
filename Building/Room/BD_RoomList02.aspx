<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_RoomList02.aspx.cs" Inherits="Man.Building.Room.BD_RoomList02"
    Title="Danh sách Phòng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Room" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Hành chánh - Tiếp tân &gt Làm việc ngoài giờ"
                                            runat="server"></asp:Label>
                                    </a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <!-- end content form-->
                            <!-- List views form-->
                            <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td valign="top" class="text_label" width="50%">
                                        Tháng/Năm (Chọn kiểm tra đã Nhập thời gian làm ngoài giờ cho Hóa Đơn Tháng)
                                    </td>
                                    <td class="input_form">
                                        <asp:DropDownList ID="drpMonth" runat="server" />
                                        <asp:DropDownList ID="drpYear" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <div class="content_form">
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtID" runat="server" Width="95%" />
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtName" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:CheckBox ID="chkMeetingRoom" runat="server" Width="95%" />
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtRegional" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtFloor" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtAreaFrom" runat="server" Width="40%"></asp:TextBox>
                                            <asp:TextBox ID="txtAreaTo" runat="server" Width="40%"></asp:TextBox>
                                        </td>
                                        <td align="center" colspan="3">
                                        <asp:RadioButton ID="rdoActive" Checked="true" runat="server" Text="Hoạt Động" GroupName="DelFlag" />
                                            <asp:RadioButton ID="rdoInActive" runat="server" Text="Ngưng Hoạt Động" GroupName="DelFlag" />
                                            <asp:RadioButton ID="rdoAll" runat="server" Text="Tất Cả" GroupName="DelFlag" />
                                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    ID
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phòng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phòng Họp
                                                </td>
                                                <td align="center" valign="middle">
                                                    Khu Vực
                                                </td>
                                                <td align="center" valign="middle">
                                                    Lầu
                                                </td>
                                                <td align="center" valign="middle" width="10%">
                                                    Diện tích
                                                </td>
                                                <td align="center" valign="middle">
                                                    Thời gian làm ngoài giờ
                                                </td>
                                                <td align="center" valign="middle">
                                                    KH đã đăng ký
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
                                                    <asp:CheckBox ID="chkMeetingRoom" runat="server" Width="95%" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRegional" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnExtraTime" Text="+" runat="server" />
                                                    <asp:Button CssClass="btn_yellow_short" ID="btnExtraTime01" Text="+" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrCustomerId" runat="server"></asp:Literal>
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
                                                    <asp:CheckBox ID="chkMeetingRoom" runat="server" Width="95%" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRegional" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnExtraTime" Text="+" runat="server" />
                                                    <asp:Button CssClass="btn_yellow_short" ID="btnExtraTime01" Text="+" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrCustomerId" runat="server"></asp:Literal>
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
                                <asp:HiddenField ID="hidTarrifsType" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
