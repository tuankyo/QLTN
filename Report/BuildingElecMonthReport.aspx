﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BuildingElecMonthReport.aspx.cs" Inherits="Man.Report.BuildingElecMonthReport"
    Title="Báo Cáo" %>

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
                                        <asp:Label ID="ltrPage" runat="server">Báo cáo Điện năng tiêu thụ</asp:Label>
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
                                        <td valign="top" class="text_label">
                                            Từ ngày<font color="red">※</font>
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="100" Width="30%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>~
                                            <asp:TextBox ID="txtToDate" runat="server" MaxLength="100" Width="30%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                                TargetControlID="txtToDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:Button CssClass="btn_blue" runat="server" ID="btnExport" Text="Xuất Report"
                                                OnClick="btnExport_Click" />                                            
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
