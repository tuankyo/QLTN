<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ReportView.aspx.cs" Inherits="Man.Report.ReportReview"
    Title="Báo cáo" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <div class="row_midpages">
        <div class="width_midpages">
            <!-- box content main -->
            <div class="box_contentmain">
                <div class="content_form">
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                        PrintMode="ActiveX" DisplayGroupTree="False" HasRefreshButton="True" ReuseParameterValuesOnRefresh="True"
                        BackColor="White" Width="350px" Height="50px" />
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    </CR:CrystalReportSource>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidId" runat="server" />
</asp:Content>
