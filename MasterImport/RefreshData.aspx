<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="RefreshData.aspx.cs" Inherits="Man.Song.RefreshData" Title="曲一覧" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="SystemFramework" Namespace="Gnt.Web.UI.WebControls" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">

    <script type="text/javascript">
        // Get a PageRequestManager reference.
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        // Hook the _initializeRequest event and add our own handler.
        prm.add_pageLoading(CreateIFrame);
        function CreateIFrame(sender, args) {
            // Check to be sure this async postback is actually 
            //   requesting the file download.
            if (sender._postBackSettings.sourceElement.id.indexOf("btnDownloadCsv") != -1)
            {
                // Create an IFRAME.
                var iframe = document.createElement("iframe");
                iframe.src = "../CSV/DownloadZipFile.aspx";
                // This makes the IFRAME invisible to the user.
                iframe.style.display = "none";
                // Add the IFRAME to the page.  This will trigger
                //   a request to GenerateFile now.
                document.body.appendChild(iframe);
            }
            if (sender._postBackSettings.sourceElement.id.indexOf("btnGetTempOpenDB") != -1 ||
                sender._postBackSettings.sourceElement.id.indexOf("btnRbtDownload") != -1)
             {
                // Create an IFRAME.
                var iframe = document.createElement("iframe");
                iframe.src = "../CSV/DownloadCsv.aspx";
                // This makes the IFRAME invisible to the user.
                iframe.style.display = "none";
                // Add the IFRAME to the page.  This will trigger
                //   a request to GenerateFile now.
                document.body.appendChild(iframe);
            }
        }

    </script>

    <asp:UpdatePanel ID="upListSong" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">実行中...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <table class="TbNoHeader" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="TopLeft">
                    </td>
                    <td class="TopCenter">
                    </td>
                    <td class="TopRight">
                    </td>
                </tr>
                <tr>
                    <td class="MiddleLeft">
                    </td>
                    <td class="MiddleCenter">
                        <table class="Tb100" border="1" bordercolor="#c0c0c0" algin="right">
                            <tr>
                                <td colspan="8">
                                        <asp:Button ID="btnRefresh" runat="server" Text="最新マスターデータを取得" OnClick="btnMasterGet_Click"/>
                                </td>
                                <td colspan="8">
                                    <asp:Button ID="Button1" runat="server" Text="最新データ【フル】を取得" OnClick="btnFullGet_Click" />
                                </td>
                                <td colspan="8">
                                    <asp:Button ID="Button2" runat="server" Text="最新データ【うた】を取得" OnClick="btnUtaGet_Click" />
                                </td>
                                <td colspan="8">
                                    <asp:Button ID="Button3" runat="server" Text="最新データ【ﾋﾞﾃﾞｵ】を取得" OnClick="btnVideoGet_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="MiddleRight">
                    </td>
                </tr>
                <tr>
                    <td class="BottomLeft">
                    </td>
                    <td class="BottomCenter">
                    </td>
                    <td class="BottomRight">
                    </td>
                </tr>
            </table>            
            <td class="MiddleRight">
            </td>
            <tr>
                <td class="BottomLeft">
                </td>
                <td class="BottomCenter">
                </td>
                <td class="BottomRight">
                </td>
            </tr>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
