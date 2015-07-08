<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="DeptReport.aspx.cs" Inherits="Man.Report.DeptReport" Title="Danh Sách Nợ" %>

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
                                        <asp:Label ID="ltrPage" Text="Báo Cáo Công Nợ" runat="server"></asp:Label>
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
                                        <td align="left" width="10%" class="text_label">
                                            Tháng/Năm
                                        </td>
                                        <td class="input_form" colspan="10">
                                            <asp:DropDownList ID="drpMonth" runat="server" />
                                            <asp:DropDownList ID="drpYear" runat="server" />
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
