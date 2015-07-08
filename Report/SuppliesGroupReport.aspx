<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="SuppliesGroupReport.aspx.cs" Inherits="Man.Report.SuppliesGroupReport"
    Title="Kế hoạch bảo trì" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Supplies" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Kế hoạch bảo trì" runat="server"></asp:Label>
                                    </a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                style="border-collapse: collapse">
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hidSuppliesType" runat="server" />
                                        <asp:DropDownList ID="drpYear" runat="server">
                                        </asp:DropDownList>
                                        <asp:Button CssClass="btn_blue" ID="btnSchedule" Text="Xuất file" OnClick="btnExport_Click"
                                            runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <!-- end mid content main -->
                            <!-- bottom content main -->
                            <div class="bgbottom_main">
                            </div>
                            <!-- end bottom content main -->
                        </div>
                        <!-- end box content main -->
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
