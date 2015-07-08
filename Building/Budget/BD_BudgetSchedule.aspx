<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_BudgetSchedule.aspx.cs" Inherits="Man.Building.Budget.BD_BudgetSchedule"
    Title="Kế hoạch Ngân sách" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
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
                                <asp:Label ID="ltrPage" Text="Kế hoạch ngân sách" runat="server"></asp:Label>
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
                        <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                            style="border-collapse: collapse">
                            <tr>
                                <td align="left">
                                    Tháng/Năm<font color="red">※</font>
                                    <asp:DropDownList ID="drpYear" runat="server" />
                                    <asp:DropDownList ID="drpBudgetExport" runat="server" Width="20%" />
                                    <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Xuất file" OnClick="btnExport_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Ngân sách kỳ
                                    <asp:TextBox ID="txtBudget" runat="server" Width="20%"></asp:TextBox>
                                    <asp:Button CssClass="btn_blue" ID="Button2" runat="server" Text="Thêm mới" OnClick="btnAdd_Click"
                                        OnClientClick="javascript:return confirm('Kỳ ngân sách sẽ được thêm mới?')" />
                                    <asp:Button CssClass="btn_blue" ID="Button4" runat="server" Text="Cập nhật cho"
                                        OnClick="btnUpdate_Click" OnClientClick="javascript:return confirm('Kỳ ngân sách sẽ cập nhật cho Kỳ đang được chọn?')" />
                                    <asp:DropDownList ID="drpBudget" runat="server" Width="20%" />
                                    <asp:Button CssClass="btn_blue" ID="Button3" runat="server" Text="Xóa" OnClick="btnDelete_Click"
                                        OnClientClick="javascript:return confirm('Thông tin Kỳ đang chọn sẽ được xóa?')" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Import Ngân sách
                                    <input type="file" id="File1" name="File1" runat="server" />
                                    <asp:Button CssClass="btn_blue" ID="Button5" Text="Import File" runat="server" OnClick="btnImport_Click"
                                        Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                                    <font color="red">File import phải có định dạng từ file được xuất</font>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <font color="red">Hướng dẫn thực hiện Tạo Ngân sách<br />
                                        1) Tạo ngân sách kỳ
                                        <br />
                                        2) Xuất file ngân sách kỳ
                                        <br />
                                        3) Từ file ngân sách, thiết lập các giá trị và Import lại vào Hệ thống</font>
                                </td>
                            </tr>
                        </table>
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
</asp:Content>
