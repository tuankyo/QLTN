<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="ListErrorDemandData.aspx.cs" Inherits="Man.MasterImport.ListErrorDemandData" %>
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
                        <asp:Panel ID="pan1" runat="server" Width="1024px" Height="420px" ScrollBars="Both">
                        <table class="GridDefault">
                             <asp:Repeater ID="rptErrorDemandDataList" runat="server" 
                                 onitemcommand="rptErrorDemandDataList_ItemCommand" 
                                 onitemdatabound="rptErrorDemandDataList_ItemDataBound">
                                <HeaderTemplate>
                                    <tr class="GridHeader">
                                        <th class="GridHeader"  id="thBuyInfoId" runat="server">
                                            <asp:LinkButton CommandName="SortBuyInfoId" ID="lnkBuyInfoId" runat="server" Text="購入情報番号" />
                                        </th>
                                        <th class="GridHeader" id="thSeviceProviderDemandID" runat="server">
                                            <asp:LinkButton CommandName="SortSeviceProviderDemandID" ID="lnkSeviceProviderDemandID" runat="server" Text="サービス提供者側要求ID" />
                                        </th>
                                        <th class="GridHeader" id="thServiceType" runat="server">
                                            <asp:LinkButton CommandName="SortServiceType" ID="lnkServiceType" runat="server" Text="サービス分類" />
                                        </th>
                                        <th class="GridHeader" id="thCalculateCatagoryName" runat="server">
                                            <asp:LinkButton CommandName="SortCalculateCatagoryName" ID="lnkCalculateCatagoryName" runat="server" Text="集計カテゴリ名" />
                                        </th>
                                        <th class="GridHeader" id="thSeviceProviderCode" runat="server">
                                            <asp:LinkButton CommandName="SortSeviceProviderCode" ID="lnkSeviceProviderCode" runat="server" Text="サービス提供者コード" />
                                        </th>
                                        <th class="GridHeader" id="thSeviceProviderName" runat="server">
                                            <asp:LinkButton CommandName="SortSeviceProviderName" ID="lnkSeviceProviderName" runat="server" Text="サービス提供者名" />
                                        </th>
                                        <th class="GridHeader" id="thSeviceCode" runat="server">
                                            <asp:LinkButton CommandName="SortSeviceCode" ID="lnkSeviceCode" runat="server" Text="サービスコード" />
                                        </th>
                                        <th class="GridHeader" id="thSeviceName" runat="server">
                                            <asp:LinkButton CommandName="SortSeviceName" ID="lnkSeviceName" runat="server" Text="サービス名" />
                                        </th>
                                        <th class="GridHeader" id="thMoneyType" runat="server">
                                            <asp:LinkButton CommandName="SortMoneyType" ID="lnkMoneyType" runat="server" Text="課金種別" />
                                        </th>
                                        <th class="GridHeader" id="thMoneyPattern" runat="server">
                                            <asp:LinkButton CommandName="SortMoneyPattern" ID="lnkMoneyPattern" runat="server" Text="課金パターン" />
                                        </th>
                                        <th class="GridHeader" id="thMoneyTotalSum" runat="server">
                                            <asp:LinkButton CommandName="SortMoneyTotalSum" ID="lnkMoneyTotalSum" runat="server" Text="課金合計金額" />
                                        </th>
                                        <th class="GridHeader" id="thOrderDetailNum" runat="server">
                                            <asp:LinkButton CommandName="SortOrderDetailNum" ID="lnkOrderDetailNum" runat="server" Text="注文明細数" />
                                        </th>
                                        <th class="GridHeader" id="thProductCode" runat="server">
                                            <asp:LinkButton CommandName="SortProductCode" ID="lnkProductCode" runat="server" Text="商品コード" />
                                        </th>
                                        <th class="GridHeader" id="thProductName" runat="server">
                                            <asp:LinkButton CommandName="SortProductName" ID="lnkProductName" runat="server" Text="商品名(EZ表示用)" />
                                        </th>
                                        <th class="GridHeader" id="thServiceProviderProductCode" runat="server">
                                            <asp:LinkButton CommandName="SortServiceProviderProductCode" ID="lnkServiceProviderProductCode" runat="server" Text="サービス提供者側商品コード" />
                                        </th>
                                        <th class="GridHeader" id="thProductQuantity" runat="server">
                                            <asp:LinkButton CommandName="SortProductQuantity" ID="lnkProductQuantity" runat="server" Text="商品数量" />
                                        </th>
                                        <th class="GridHeader" id="thQuantityUnit" runat="server">
                                            <asp:LinkButton CommandName="SortQuantityUnit" ID="lnkQuantityUnit" runat="server" Text="数量単位" />
                                        </th>
                                        <th class="GridHeader" id="thSubscriberId" runat="server">
                                            <asp:LinkButton CommandName="SortSubscriberId" ID="lnkSubscriberId" runat="server" Text="サブスクライバID" />
                                        </th>
                                        <th class="GridHeader" id="thMoneyStatus" runat="server">
                                            <asp:LinkButton CommandName="SortMoneyStatus" ID="lnkMoneyStatus" runat="server" Text="課金ステータス" />
                                        </th>
                                        <th class="GridHeader" id="thAuBusinessType" runat="server">
                                            <asp:LinkButton CommandName="SortAuBusinessType" ID="lnkAuBusinessType" runat="server" Text="au事業者区分" />
                                        </th>
                                        <th class="GridHeader" id="thMoneyDateTime" runat="server">
                                            <asp:LinkButton CommandName="SortMoneyDateTime" ID="lnkMoneyDateTime" runat="server" Text="課金日時" />
                                        </th>
                                        <th class="GridHeader" id="thReceiptYearMonthDate" runat="server">
                                            <asp:LinkButton CommandName="SortReceiptYearMonthDate" ID="lnkReceiptYearMonthDate" runat="server" Text="収納年月日" />
                                        </th>
                                        <th class="GridHeader" id="thDeleteYearMonthDate" runat="server">
                                            <asp:LinkButton CommandName="SortDeleteYearMonthDate" ID="lnkDeleteYearMonthDate" runat="server" Text="取消年月日" />
                                        </th>
                                        <th class="GridHeader" id="thReplyYearMonth" runat="server">
                                            <asp:LinkButton CommandName="SortReplyYearMonth" ID="lnkReplyYearMonth" runat="server" Text="返戻年月" />
                                        </th>
                                        <th class="GridHeader" id="thBranchId" runat="server">
                                            <asp:LinkButton CommandName="SortBranchId" ID="lnkBranchId" runat="server" Text="枝番" />
                                        </th>
                                        <th class="GridHeader" id="thContentCode" runat="server">
                                            <asp:LinkButton CommandName="SortContentCode" ID="lnkContentCode" runat="server" Text="コンテンツコード" />
                                        </th>
                                        <th class="GridHeader" id="thCopyWriterType" runat="server">
                                            <asp:LinkButton CommandName="SortCopyWriterType" ID="lnkCopyWriterType" runat="server" Text="債権区分" />
                                        </th>
                                        <th class="GridHeader" id="thExactCalcProcessYearMonth" runat="server">
                                            <asp:LinkButton CommandName="SortExactCalcProcessYearMonth" ID="lnkExactCalcProcessYearMonth" runat="server" Text="精算処理年月" />
                                        </th>
                                        <th class="GridHeader" id="thDemandErrorProcessDateTime" runat="server">
                                            <asp:LinkButton CommandName="SortDemandErrorProcessDateTime" ID="lnkDemandErrorProcessDateTime" runat="server" Text="請求エラー処理日時" />
                                        </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center" runat="server" id="tdBuyInfoId">
                                            <asp:Literal ID="ltrBuyInfoId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceProviderDemandID">
                                            <asp:Literal ID="ltrSeviceProviderDemandID" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdServiceType">
                                            <asp:Literal ID="ltrServiceType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdCalculateCatagoryName">
                                            <asp:Literal ID="ltrCalculateCatagoryName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceProviderCode">
                                            <asp:Literal ID="ltrSeviceProviderCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceProviderName">
                                            <asp:Literal ID="ltrSeviceProviderName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceCode">
                                            <asp:Literal ID="ltrSeviceCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceName">
                                            <asp:Literal ID="ltrSeviceName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyType">
                                            <asp:Literal ID="ltrMoneyType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyPattern">
                                            <asp:Literal ID="ltrMoneyPattern" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyTotalSum">
                                            <asp:Literal ID="ltrMoneyTotalSum" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdOrderDetailNum">
                                            <asp:Literal ID="ltrOrderDetailNum" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProductCode">
                                            <asp:Literal ID="ltrProductCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProductName">
                                            <asp:Literal ID="ltrProductName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdServiceProviderProductCode">
                                            <asp:Literal ID="ltrServiceProviderProductCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProductQuantity">
                                            <asp:Literal ID="ltrProductQuantity" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdQuantityUnit">
                                            <asp:Literal ID="ltrQuantityUnit" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSubscriberId">
                                            <asp:Literal ID="ltrSubscriberId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyStatus">
                                            <asp:Literal ID="ltrMoneyStatus" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdAuBusinessType">
                                            <asp:Literal ID="ltrAuBusinessType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyDateTime">
                                            <asp:Literal ID="ltrMoneyDateTime" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdReceiptYearMonthDate">
                                            <asp:Literal ID="ltrReceiptYearMonthDate" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdDeleteYearMonthDate">
                                            <asp:Literal ID="ltrDeleteYearMonthDate" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdReplyYearMonth">
                                            <asp:Literal ID="ltrReplyYearMonth" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdBranchId">
                                            <asp:Literal ID="ltrBranchId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdContentCode">
                                            <asp:Literal ID="ltrContentCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdCopyWriterType">
                                            <asp:Literal ID="ltrCopyWriterType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdExactCalcProcessYearMonth">
                                            <asp:Literal ID="ltrExactCalcProcessYearMonth" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdDemandErrorProcessDateTime">
                                            <asp:Literal ID="ltrDemandErrorProcessDateTime" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr class="SelectedList">
                                       <td align="center" runat="server" id="tdBuyInfoId">
                                            <asp:Literal ID="ltrBuyInfoId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceProviderDemandID">
                                            <asp:Literal ID="ltrSeviceProviderDemandID" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdServiceType">
                                            <asp:Literal ID="ltrServiceType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdCalculateCatagoryName">
                                            <asp:Literal ID="ltrCalculateCatagoryName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceProviderCode">
                                            <asp:Literal ID="ltrSeviceProviderCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceProviderName">
                                            <asp:Literal ID="ltrSeviceProviderName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceCode">
                                            <asp:Literal ID="ltrSeviceCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSeviceName">
                                            <asp:Literal ID="ltrSeviceName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyType">
                                            <asp:Literal ID="ltrMoneyType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyPattern">
                                            <asp:Literal ID="ltrMoneyPattern" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyTotalSum">
                                            <asp:Literal ID="ltrMoneyTotalSum" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdOrderDetailNum">
                                            <asp:Literal ID="ltrOrderDetailNum" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProductCode">
                                            <asp:Literal ID="ltrProductCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProductName">
                                            <asp:Literal ID="ltrProductName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdServiceProviderProductCode">
                                            <asp:Literal ID="ltrServiceProviderProductCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdProductQuantity">
                                            <asp:Literal ID="ltrProductQuantity" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdQuantityUnit">
                                            <asp:Literal ID="ltrQuantityUnit" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdSubscriberId">
                                            <asp:Literal ID="ltrSubscriberId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyStatus">
                                            <asp:Literal ID="ltrMoneyStatus" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdAuBusinessType">
                                            <asp:Literal ID="ltrAuBusinessType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdMoneyDateTime">
                                            <asp:Literal ID="ltrMoneyDateTime" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdReceiptYearMonthDate">
                                            <asp:Literal ID="ltrReceiptYearMonthDate" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdDeleteYearMonthDate">
                                            <asp:Literal ID="ltrDeleteYearMonthDate" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdReplyYearMonth">
                                            <asp:Literal ID="ltrReplyYearMonth" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdBranchId">
                                            <asp:Literal ID="ltrBranchId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdContentCode">
                                            <asp:Literal ID="ltrContentCode" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdCopyWriterType">
                                            <asp:Literal ID="ltrCopyWriterType" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdExactCalcProcessYearMonth">
                                            <asp:Literal ID="ltrExactCalcProcessYearMonth" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center" runat="server" id="tdDemandErrorProcessDateTime">
                                            <asp:Literal ID="ltrDemandErrorProcessDateTime" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </table>
                        </asp:Panel>
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
