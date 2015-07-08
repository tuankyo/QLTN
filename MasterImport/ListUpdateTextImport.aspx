<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListUpdateTextImport.aspx.cs" Inherits="Man.MasterImport.ListUpdateTextImport"
    Title="テキスト一括更新" %>

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
            if (sender._postBackSettings.sourceElement.id.indexOf("btnDownloadCsv") != -1) {
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

    <asp:UpdatePanel ID="upListFileSize" runat="server">
        <ContentTemplate>
            <table class="TableNoHeader" cellpadding="0" cellspacing="0">
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
                        <table class="Tb100" border="0" bordercolor="#c0c0c0" algin="right">
                            <tr>
                                <td class="Title" style="width: 15%">
                                    フォルダバス
                                </td>
                                <td>
                                    <asp:Label ID="lblFolderPath" runat="server"></asp:Label>
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
            <asp:MultiValidator ID="mvldMessage" runat="server" Align="Center" />
            <asp:MultiValidator ID="MultiValidator1" runat="server" Align="Center" />
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">実行中...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <table class="TableNoHeader" cellpadding="0" cellspacing="0">
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
                        <cc:Pager ID="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                        </cc:Pager>
                        <table class="GridDefault">
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                OnItemCommand="rptList_ItemCommand">
                                <HeaderTemplate>
                                    <tr class="GridHeader">
                                        <th class="GridHeader">
                                            <asp:LinkButton CommandName="SortId" ID="lnkId" runat="server" Text="ID" />
                                        </th>
                                        <th class="GridHeader" id="thTitle" runat="server">
                                            <asp:LinkButton CommandName="SortTitle" ID="lnkTitle" runat="server" Text="曲タイトル" />
                                        </th>
                                        <th class="GridHeader" id="thArtistId" runat="server">
                                            <asp:LinkButton CommandName="SortArtistId" ID="lnkArtistId" runat="server" Text="アーティストID" />
                                        </th>
                                        <th class="GridHeader" id="thArtistName" runat="server">
                                            <asp:LinkButton CommandName="SortArtistName" ID="lnkArtistName" runat="server" Text="アーティスト名" />
                                        </th>
                                        <th class="GridHeader" id="thAlbumId" runat="server">
                                            <asp:LinkButton CommandName="SortAlbumId" ID="lnkAlbumId" runat="server" Text="アルバムID" />
                                        </th>
                                        <th class="GridHeader" id="thAlbumName" runat="server">
                                            <asp:LinkButton CommandName="SortAlbumName" ID="lnkAlbumName" runat="server" Text="アルバム名" />
                                        </th>
                                        <th class="GridHeader" id="thContractorId" runat="server">
                                            <asp:LinkButton CommandName="SortContractorId" ID="lnkContractorId" runat="server"
                                                Text="契約者ID" />
                                        </th>
                                        <th class="GridHeader" id="thContractorName" runat="server">
                                            <asp:LinkButton CommandName="SortContractorName" ID="lnkContractorName" runat="server"
                                                Text="契約者名" />
                                        </th>
                                        <th class="GridHeader" id="thPRText" runat="server">
                                            <asp:LinkButton CommandName="SortPRText" ID="lnkPRText" runat="server" Text="PRText" />
                                        </th>
                                        <th class="GridHeader" id="thCDID" runat="server">
                                            <asp:LinkButton CommandName="SortCDID" ID="lnkCDID" runat="server" Text="CdID" />
                                        </th>
                                        <th class="GridHeader" id="thSaleDate" runat="server">
                                            <asp:LinkButton CommandName="SortSaleDate" ID="lnkSaleDate" runat="server" Text="発売日" />
                                        </th>
                                        <th class="GridHeader" id="thComment" runat="server">
                                            コメント
                                        </th>
                                        <th class="GridHeader" id="thProfile" runat="server">
                                            プロフィール
                                        </th>
                                        <th class="GridHeader" id="thGenre01" runat="server">
                                            ｼﾞｬﾝﾙ-01
                                        </th>
                                        <th class="GridHeader" id="thGenre02" runat="server">
                                            ｼﾞｬﾝﾙ-02
                                        </th>
                                        <th class="GridHeader" id="thJacket" runat="server">
                                            写FL
                                        </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center" runat="server" id="tdId">
                                            <asp:Literal ID="ltrId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdTitle">
                                            <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdArtistId">
                                            <asp:Literal ID="ltrArtistId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdArtistName">
                                            <asp:Literal ID="ltrArtistName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdAlbumId">
                                            <asp:Literal ID="ltrAlbumId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdAlbumName">
                                            <asp:Literal ID="ltrAlbumName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdContractorId">
                                            <asp:Literal ID="ltrContractorId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdContractorName">
                                            <asp:Literal ID="ltrContractorName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdPRText">
                                            <asp:Literal ID="ltrPRText" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdCdID">
                                            <asp:Literal ID="ltrCDID" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSaleDate">
                                            <asp:Literal ID="ltrSaleDate" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdComment">
                                            <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProfile">
                                            <asp:Literal ID="ltrProfile" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdGenre01">
                                            <asp:Literal ID="ltrGenre01" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdGenre02">
                                            <asp:Literal ID="ltrGenre02" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdJacket">
                                            <asp:Literal ID="ltrJacket" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="SelectedList">
                                        <td align="center" runat="server" id="tdId">
                                            <asp:Literal ID="ltrId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdTitle">
                                            <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdArtistId">
                                            <asp:Literal ID="ltrArtistId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdArtistName">
                                            <asp:Literal ID="ltrArtistName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdAlbumId">
                                            <asp:Literal ID="ltrAlbumId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdAlbumName">
                                            <asp:Literal ID="ltrAlbumName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdContractorId">
                                            <asp:Literal ID="ltrContractorId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdContractorName">
                                            <asp:Literal ID="ltrContractorName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdPRText">
                                            <asp:Literal ID="ltrPRText" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdCdID">
                                            <asp:Literal ID="ltrCDID" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSaleDate">
                                            <asp:Literal ID="ltrSaleDate" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdComment">
                                            <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProfile">
                                            <asp:Literal ID="ltrProfile" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdGenre01">
                                            <asp:Literal ID="ltrGenre01" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdGenre02">
                                            <asp:Literal ID="ltrGenre02" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdJacket">
                                            <asp:Literal ID="ltrJacket" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
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
                        <table>
                            <tr>
                            <!--
                                <td>
                                    <asp:ListBox ID="lstSiteSend" Width="200px" runat="server" SelectionMode="Multiple">
                                    </asp:ListBox>
                                </td>
                            -->
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click"
                                        Width="80px" />
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
            <div>
                <asp:HiddenField ID="hidImportType" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
