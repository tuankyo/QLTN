<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListRbtDownloadImportAu.aspx.cs" Inherits="Man.ImportMaster.ListRbtDownloadImportAu"
    Title="一括登録曲一覧" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="SystemFramework" namespace="Gnt.Web.UI.WebControls" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
<script  type="text/javascript">
  // Get a PageRequestManager reference.
  var prm = Sys.WebForms.PageRequestManager.getInstance();
  // Hook the _initializeRequest event and add our own handler.
  prm.add_pageLoading(CreateIFrame);
  function CreateIFrame(sender, args)
  {
    // Check to be sure this async postback is actually 
    //   requesting the file download.
      if (sender._postBackSettings.sourceElement.id.indexOf("btnDownloadCsv") != -1 ||
          sender._postBackSettings.sourceElement.id.indexOf("btnGetExistsID") != -1)
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
            <asp:MultiValidator ID="mvldMessage" runat="server" Align="Center"/>
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
                        <cc:Pager ID="pager" runat="server" onpageindexchanged="pager_PageIndexChanged">
                        </cc:Pager>
                        <asp:Panel ID="pan1" runat="server" Width="1024px" Height="500px" ScrollBars="Both">
                        <table class="GridDefault">
                             <asp:Repeater id="rptList" runat="server"
                                   onitemdatabound="rptList_ItemDataBound"  OnItemCommand="rptList_ItemCommand">
                                   <HeaderTemplate>
                                        <tr class="GridHeader" id="line" runat="server">
                                            <th class="GridHeader">
                                                Myリスト登録日時
                                            </th>
                                            <th class="GridHeader">
                                                サービス提供者コード
                                            </th>
                                            <th class="GridHeader">
                                                サービス提供者名
                                            </th>
                                            <th class="GridHeader">
                                                サービスコード
                                            </th>
                                            <th class="GridHeader">
                                                サービス名
                                            </th>
                                            <th class="GridHeader">
                                                課金種別
                                            </th>
                                            <th class="GridHeader">
                                                金額
                                            </th>
                                            <th class="GridHeader">
                                                商品コード
                                            </th>
                                            <th class="GridHeader">
                                                商品名
                                            </th>
                                            <th class="GridHeader">
                                                サブスクライバID
                                            </th>
                                            <th class="GridHeader">
                                                コンテンツコード
                                            </th>
                                            <th class="GridHeader">
                                                無償端末有無
                                            </th>
                                            <th class="GridHeader">
                                                同一月再購入有無
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                           <tr>
                                               <td align="center">
                                                   <asp:Literal ID="ltrDownloadDate" runat="server"></asp:Literal>
                                               </td>
                                               <td align="center">
                                                   <asp:Literal ID="ltrServiceSupportCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrServiceSupportName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="center">
                                                   <asp:Literal ID="ltrServiceCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrServiceName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrChargeType" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrPrice" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrSiteCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSiteName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrUserId" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrContentCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrTerminalFlag" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrBeginMonth" runat="server"></asp:Literal>
                                               </td>
                                           </tr>
                                      </ItemTemplate>
                                      <AlternatingItemTemplate>
                                          <tr class ="SelectedList">
                                              <td align="center">
                                                   <asp:Literal ID="ltrDownloadDate" runat="server"></asp:Literal>
                                               </td>
                                               <td align="center">
                                                   <asp:Literal ID="ltrServiceSupportCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrServiceSupportName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="center">
                                                   <asp:Literal ID="ltrServiceCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrServiceName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrChargeType" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrPrice" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrSiteCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSiteName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrUserId" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrContentCode" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrTerminalFlag" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrBeginMonth" runat="server"></asp:Literal>
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
            <div id="divUpdate" runat="server">
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
                   <td class="MiddleLeft"></td>
                   <td class="MiddleCenter">
                       <table>
                            <tr>
                                <td class="Title" style="white-space: nowrap; width: 100px">
                                    実績年月
                                </td>
                                <td style="white-space: nowrap; width: 100px">
                                    <asp:TextBox ID="txtPayMonth" runat="server" Width="80px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender runat="server" ID="MaskedEditExtender1" Mask="9999年99月" Enabled="true" TargetControlID="txtPayMonth">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnRegister" runat="server" Text="インポート" OnClick="btnRegister_Click" Width="80px" />
                                </td>
                            </tr>
                       </table>
                   </td>
                   <td class="MiddleRight"></td>
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
            </div>
            <asp:HiddenField ID="hidImportType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


