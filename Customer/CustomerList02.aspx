<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="CustomerList02.aspx.cs" Inherits="Man.Customer.CustomerList02" Title="Danh Sách Khách Hàng" %>

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
                                        <asp:Label ID="ltrPage" Text="Quản lý hoạt động &gt Khách hàng" runat="server"></asp:Label>
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
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td align="left" width="20%" class="text_label">
                                            Số ngày gửi xe Tháng
                                        </td>
                                        <td class="input_form" colspan="10">
                                            <asp:Button ID="Button4" runat="server" CssClass="btn_blue" Text="Định ngày nghỉ" OnClick="btnParkingOffDays_Click"/>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td align="left" width="10%" class="text_label">
                                            Tháng/Năm
                                        </td>
                                        <td class="input_form" colspan="10">
                                            <asp:DropDownList ID="drpMonth" runat="server" />
                                            <asp:DropDownList ID="drpYear" runat="server" />
                                            Có <asp:TextBox ID="txtRentDays" runat="server" Width="35px"></asp:TextBox>ngày
                                            
                                            <asp:Button ID="Button1" runat="server" CssClass="btn_blue" Text="Quyết sổ" OnClick="btnSave_Click"
                                                OnClientClick="javascript:return confirm('Hệ thống sẽ thực hiện quyết sổ Công Nợ Tháng?')" /><br />
                                            <asp:Button ID="Button5" runat="server" CssClass="btn_blue" Text="Xuất HĐ" OnClick="btnViewMulti_Click"
                                            OnClientClick="javascript:return confirm('Xuất file sẽ mất thời gian hơn 5 phút.')" /> Chú ý: Hóa đơn chỉ xuất cho những Khách Hàng đã được tạo Hóa Đơn Chi Tiết
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" width="10%" class="text_label">
                                            Báo cáo
                                        </td>
                                        <td class="input_form" colspan="10">
                                            <asp:Button ID="Button6" runat="server" CssClass="btn_blue" Text="Công nợ 1" OnClick="btnExport_Click" />
                                            <asp:Button ID="Button2" runat="server" CssClass="btn_blue" Text="Công nợ 2" OnClick="btnExport1_Click" />
                                            <asp:Button ID="Button3" runat="server" CssClass="btn_blue" Text="Công nợ 3" OnClick="btnExport2_Click" />
                                            <br />
                                            Công nợ 1: Nợ tồn động từng tháng
                                            <br />
                                            Công nợ 2: Nợ chi tiết từng tháng
                                            <br />
                                            Công nợ 3: Nợ tổng quát từng tháng
                                        </td>
                                    </tr>
                                </table>
                                <br />
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
                                                    Hóa Đơn
                                                </td>
                                                <td align="center" valign="middle">
                                                    Thu phí tháng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Xem hóa đơn
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
                                            <tr <asp:Literal ID="resultLine" runat="server"/>>
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
                                                    <asp:Button CssClass="btn_blue_short" ID="btnRevenue" CommandName="Revenue" runat="server"
                                                        Text="Chi Tiết" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnPayment" CommandName="Payment" runat="server"
                                                        Text="+" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button CssClass="btn_blue" ID="btnView" CommandName="BillDetail" runat="server"
                                                        Text="Xem" />
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
                                            <tr <asp:Literal ID="resultLine" runat="server"/>>
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
                                                    <asp:Button CssClass="btn_blue_short" ID="btnRevenue" CommandName="Revenue" runat="server"
                                                        Text="Chi Tiết" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnPayment" CommandName="Payment" runat="server"
                                                        Text="+" />
                                                </td>
                                                <td align="left">
                                                    <asp:Button CssClass="btn_blue" ID="btnView" CommandName="BillDetail" runat="server"
                                                        Text="Xem" />
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
