<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="CustomerList03.aspx.cs" Inherits="Man.Customer.CustomerList03" Title="Danh Sách Khách Hàng" %>

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
                                        <asp:Label ID="ltrPage" Text="Quản lý cho thuê phòng họp" runat="server"></asp:Label>
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
                                            <asp:TextBox ID="txtID" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtName" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPhone" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtContactName" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="left" colspan="6">
                                        <asp:RadioButton ID="rdoActive" Checked="true" runat="server" Text="Hoạt Động" GroupName="DelFlag" />
                                            <asp:RadioButton ID="rdoInActive" runat="server" Text="Ngưng Hoạt Động" GroupName="DelFlag" />
                                            <asp:RadioButton ID="rdoAll" runat="server" Text="Tất Cả" GroupName="DelFlag" />
                                            
                                            <asp:Button CssClass="btn_blue" ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    Mã KH
                                                </td>
                                                <td align="center" valign="middle">
                                                    Khách Hàng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phone
                                                </td>
                                                <td align="center" valign="middle">
                                                    Email
                                                </td>
                                                <td align="center" valign="middle">
                                                    Liên lạc
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đặt Phòng Họp
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
                                                    <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrContactName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnBooking" CommandName="Booking" runat="server"
                                                        Text="Chi Tiết" />
                                                    <asp:Button CssClass="btn_yellow_short" ID="btnBooking01" CommandName="Booking" runat="server"
                                                        Text="Chi Tiết" />
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
                                                    <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrContactName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnBooking" CommandName="Booking" runat="server"
                                                        Text="Chi Tiết" />
                                                    <asp:Button CssClass="btn_yellow_short" ID="btnBooking01" CommandName="Booking" runat="server"
                                                        Text="Chi Tiết" />
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
