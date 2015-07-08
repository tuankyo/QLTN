<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListRbtDownloadImport.aspx.cs" Inherits="Man.ImportMaster.ListRbtDownloadImport"
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
                                                コンテンツID
                                            </th>
                                            <th class="GridHeader">
                                                CP-ID
                                            </th>
                                            <th class="GridHeader">
                                                サイトID
                                            </th>
                                            <th class="GridHeader">
                                                コンテンツ名
                                            </th>
                                            <th class="GridHeader">
                                                アーティスト名
                                            </th>
                                            <th class="GridHeader">
                                                有料フラグ
                                            </th>
                                            <th class="GridHeader">
                                                課金額
                                            </th>
                                            <th class="GridHeader">
                                                月初設定
                                            </th>
                                            <th class="GridHeader">
                                                1日
                                            </th>
                                            <th class="GridHeader">
                                                2日
                                            </th>
                                            <th class="GridHeader">
                                                3日
                                            </th>
                                            <th class="GridHeader">
                                                4日
                                            </th>
                                            <th class="GridHeader">
                                                5日
                                            </th>
                                            <th class="GridHeader">
                                                6日
                                            </th>
                                            <th class="GridHeader">
                                                7日
                                            </th>
                                            <th class="GridHeader">
                                                8日
                                            </th>
                                            <th class="GridHeader">
                                                9日
                                            </th>
                                            <th class="GridHeader">
                                                10日
                                            </th>
                                            <th class="GridHeader">
                                                11日
                                            </th>
                                            <th class="GridHeader">
                                                12日
                                            </th>
                                            <th class="GridHeader">
                                                13日
                                            </th>
                                            <th class="GridHeader">
                                                14日
                                            </th>
                                            <th class="GridHeader">
                                                15日
                                            </th>
                                            <th class="GridHeader">
                                                16日
                                            </th>
                                            <th class="GridHeader">
                                                17日
                                            </th>
                                            <th class="GridHeader">
                                                18日
                                            </th>
                                            <th class="GridHeader">
                                                19日
                                            </th>
                                            <th class="GridHeader">
                                                20日
                                            </th>
                                            <th class="GridHeader">
                                                21日
                                            </th>
                                            <th class="GridHeader">
                                                22日
                                            </th>
                                            <th class="GridHeader">
                                                23日
                                            </th>
                                            <th class="GridHeader">
                                                24日
                                            </th>
                                            <th class="GridHeader">
                                                25日
                                            </th>
                                            <th class="GridHeader">
                                                26日
                                            </th>
                                            <th class="GridHeader">
                                                27日
                                            </th>
                                            <th class="GridHeader">
                                                28日
                                            </th>
                                            <th class="GridHeader">
                                                29日
                                            </th>
                                            <th class="GridHeader">
                                                30日
                                            </th>
                                            <th class="GridHeader">
                                                31日
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                           <tr>
                                               <td align="left">
                                                   <asp:Literal ID="ltrContentId" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrCpId" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSiteId" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrContentName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrArtistName" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrFeeFlag" runat="server"></asp:Literal>
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrCharge" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrBeginMonth" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay01" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay02" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay03" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay04" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay05" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay06" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay07" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay08" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay09" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay10" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay11" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay12" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay13" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay14" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay15" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay16" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay17" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay18" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay19" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay20" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay21" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay22" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay23" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay24" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay25" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay26" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay27" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay28" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay29" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay30" runat="server"></asp:Literal>
                                               </td>
                                               <td align="right">
                                                   <asp:Literal ID="ltrDay31" runat="server"></asp:Literal>
                                               </td>
                                           </tr>
                                      </ItemTemplate>
                                      <AlternatingItemTemplate>
                                          <tr class ="SelectedList">
                                              <td align="left">
                                                  <asp:Literal ID="ltrContentId" runat="server"></asp:Literal>
                                              </td>
                                              <td align="left">
                                                  <asp:Literal ID="ltrCpId" runat="server"></asp:Literal>
                                              </td>
                                              <td align="left">
                                                  <asp:Literal ID="ltrSiteId" runat="server"></asp:Literal>
                                              </td>
                                              <td align="left">
                                                  <asp:Literal ID="ltrContentName" runat="server"></asp:Literal>
                                              </td>
                                              <td align="left">
                                                  <asp:Literal ID="ltrArtistName" runat="server"></asp:Literal>
                                              </td>
                                              <td align="left">
                                                  <asp:Literal ID="ltrFeeFlag" runat="server"></asp:Literal>
                                              </td>
                                              <td align="left">
                                                  <asp:Literal ID="ltrCharge" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrBeginMonth" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay01" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay02" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay03" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay04" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay05" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay06" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay07" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay08" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay09" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay10" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay11" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay12" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay13" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay14" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay15" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay16" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay17" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay18" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay19" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay20" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay21" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay22" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay23" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay24" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay25" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay26" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay27" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay28" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay29" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay30" runat="server"></asp:Literal>
                                              </td>
                                              <td align="right">
                                                  <asp:Literal ID="ltrDay31" runat="server"></asp:Literal>
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
                            <!--
                                <td>
                                    <asp:ListBox ID="lstSiteSend" Width="200px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                </td>
                                <td>
                                </td>                                    
                             -->
                                <td class="Title" style="width: 100px">
                                    サイト
                                </td>
                                <td style="white-space: nowrap" colspan="5">
                                    <asp:DropDownList ID="drpSite" runat="server" Width="205px">
                                    </asp:DropDownList>
                                </td>
                                <td class="Title" style="white-space: nowrap; width: 100px">
                                    実績年月
                                </td>
                                <td style="white-space: nowrap; width: 100px">
                                    <asp:TextBox ID="txtPayMonth" runat="server" Width="80px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender runat="server" ID="MaskedEditExtender1" Mask="9999年99月"
                                        Enabled="true" TargetControlID="txtPayMonth">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                                
                                <td>
                                    <asp:Button ID="btnRegister" runat="server" Text="インポート" OnClick="btnRegister_Click"
                                        Width="150px" />
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


