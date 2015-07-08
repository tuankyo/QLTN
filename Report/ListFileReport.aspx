<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListFileReport.aspx.cs" Inherits="Man.Report.ListFileReport" Title="Danh Sách File Export" %>

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
                                        <asp:Label ID="ltrPage" Text="Danh sách báo cáo đã xuất" runat="server"></asp:Label>
                                    </a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <div class="content_form">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td valign="top" class="text_label" width="20%">
                                            Loại báo cáo
                                        </td>
                                        <td>
                                            <select id="drpZone" runat="server">
                                                <option value="BaoCaoThang">Báo Cáo Tháng</option>
                                                <option value="NganSach">Ngân Sách</option>
                                                <option value="BaoCaoThuChiThang">Thu Chi Tháng</option>
                                                <option value="BaoCaoCongNo">Báo Cáo Công Nợ</option>
                                                <option value="BillPhongHop">Hóa Đơn Phòng Họp</option>
                                                <option value="Bill">Hóa Đơn Thu Phí Tháng</option>
                                                <option value="DienNangTieuThuThang">Điện Năng Tiêu Thụ Tháng</option>
                                                <option value="NuocTieuThuThang">Nước Tiêu Thụ Tháng</option>
                                                <option value="HopDongThueChiTiet">Tổng Hợp Hợp Đồng</option>
                                                <option value="KeHoachBaoTri">Kế Hoạch Bảo Trì</option>
                                                <option value="BaoTriDinhKy">Bảo Trì Định Kỳ</option>
                                                <option value="MayMocThietBi">Danh Sách Máy Móc Thiết Bị</option>
                                                <option value="NhatKyHangNgay">Nhật Ký Hằng Ngày</option>
                                                <option value="SuCoKyThuat">Sự Cố Kỹ Thuật</option>
                                                <option value="ThiCongNoiThat">Thi Công Nội Thất</option>
                                                <option value="ThiCongSuaChua">Sửa chữa Xây Dựng</option>
                                                <option value="GuixeThang">Gửi xe tháng</option>
                                                <option value="ThongTinVeXeLuot">Gửi xe lượt</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="text_label">
                                            Ngày xuất
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="100" Width="30%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            ~
                                            <asp:TextBox ID="txtToDate" runat="server" MaxLength="100" Width="30%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                TargetControlID="txtToDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button CssClass="btn_blue" runat="server" ID="btnSearch" Text="Lọc Dữ Liệu"
                                                OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    <asp:LinkButton CommandName="SortFileName" ID="lnkName" runat="server" Text="Tên File" />
                                                </td>
                                                <td align="center" valign="middle">
                                                    <asp:LinkButton CommandName="SortCreated" ID="lnkCreated" runat="server" Text="Ngày Tạo" />
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="ltrName" CommandName="FileName" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrCreated" runat="server" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="SelectedList">
                                                <td align="left">
                                                    <asp:LinkButton ID="ltrName" CommandName="FileName" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrCreated" runat="server" />
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
