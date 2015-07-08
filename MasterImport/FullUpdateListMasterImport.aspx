<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="FullUpdateListMasterImport.aspx.cs" Inherits="Man.ImportMaster.FullUpdateListMasterImport"
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
          sender._postBackSettings.sourceElement.id.indexOf("btnGetNotExistsID") != -1)
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
                        <table class="Tb100" border="1" bordercolor="#c0c0c0" algin="right">
                            <tr style="background-color: ThreeDFace">
                                <td colspan="15">
                                    <font color="Red">更新項目</font>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkTitle" runat="server" Text="タイトル" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkAlphabetTitle" runat="server" Text="曲名英表記" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkFileName" runat="server" Text="ファイル名" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsrcNo" runat="server" Text="ISRC番号" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkPrice" runat="server" Text="Price" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkHaishinDate" runat="server" Text="配信日" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkHaishinEndDate" runat="server" Text="配信停止日" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIVT" runat="server" Text="歌詞区分" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkFlag" runat="server" Text="fineflag" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkPoint1" runat="server" Text="切り出し表記1" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chksabi1" runat="server" Text="cut開始1" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSabi1End" runat="server" Text="cut終了1" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkPoint2" runat="server" Text="切り出し表記2" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSabi2" runat="server" Text="cut開始2" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSabi2End" runat="server" Text="cut終了2" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkPoint3" runat="server" Text="切り出し表記3" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSabi3" runat="server" Text="cut開始3" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkSabi3End" runat="server" Text="cut終了3" />
                                </td>
                            </tr>
                        </table>
                        <cc:Pager ID="pager" runat="server" onpageindexchanged="pager_PageIndexChanged">
                        </cc:Pager>
                        <table class="GridDefault">
                             <asp:Repeater id="rptList" runat="server"
                                   onitemdatabound="rptList_ItemDataBound"  OnItemCommand="rptList_ItemCommand">
                                   <HeaderTemplate>
                                        <tr class="GridHeader" id="line" runat="server">
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSongId" id="lnkSongId" runat="server" Text="ID" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSongTitle" ID="lnkSongTitle" runat="server" Text="曲名" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSongTitleYomFullChar" ID="lnkSongTitleReading" runat="server"
                                                    Text="曲名ﾖﾐ" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortRemoveDateFull" ID="lnkRemoveDateFull" runat="server"
                                                    Text="配信日" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortHaishinEndDate" ID="lnkHaishinEndDate" runat="server"
                                                    Text="配信停止日" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortPrice" ID="lnkPrice" runat="server" Text="Price" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortIsrcNo" ID="lnkIsrcNo" runat="server" Text="ISRC" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortPoint1" ID="lnkPoint1" runat="server" Text="切り出し表記1" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSabi1" ID="lnkSabi1" runat="server" Text="cut開始1" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSabi1End" ID="lnkSabi1End" runat="server" Text="cut終了1" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortPoint2" ID="lnkPoint2" runat="server" Text="切り出し表記2" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSabi2" ID="lnkSabi2" runat="server" Text="cut開始2" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSabi2End" ID="lnkSabi2End" runat="server" Text="cut終了2" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortPoint3" ID="lnkPoint3" runat="server" Text="切り出し表記3" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSabi3" ID="lnkSabi3" runat="server" Text="cut開始3" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSabi3End" ID="lnkSabi3End" runat="server" Text="cut終了3" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortFlag" ID="lnkFlag" runat="server" Text="fineFlag" />
                                            </th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortFullFileName" ID="lnkFullFileName" runat="server"
                                                    Text="ファイル名" />
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                           <tr <asp:Literal ID="ltrBg" runat="server"></asp:Literal>>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongId" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongTitle" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongTitleReading" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrRemoveDateFull" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrHaishinEndDate" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPrice" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrIsrcNo" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPoint1" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi1" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi1End" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPoint2" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi2" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi2End" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPoint3" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi3" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi3End" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrFlag" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrFullFileName" runat="server" />
                                               </td>
	        		                       </tr>
                                      </ItemTemplate>
                                      <AlternatingItemTemplate>
                                            <tr <asp:Literal ID="ltrBg" runat="server"></asp:Literal>>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongId" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongTitle" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongTitleReading" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrRemoveDateFull" runat="server" />
                                               </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrHaishinEndDate" runat="server" />
                                                </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPrice" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrIsrcNo" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPoint1" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi1" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi1End" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPoint2" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi2" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi2End" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPoint3" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi3" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSabi3End" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrFlag" runat="server" />
                                               </td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrFullFileName" runat="server" />
                                               </td>
	        		                       </tr>
                                      </AlternatingItemTemplate>
                                      <FooterTemplate>
                                                <tr class="GridHeader">
                                                     <th colspan=18 align=left>
                                                        <asp:Button ID="btnDownloadCsv" runat="server" Text="CSV出力" onclick="btnDownload_Click"/>                                                     
	        		                                 </th>
	        		                            </tr>
                                      </FooterTemplate>
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
                                <td>
                                    <asp:Button ID="btnRegister" runat="server" Text="登録" OnClick="btnRegister_Click"
                                        Width="150px" />
                                </td>
                                <td>
                                    <asp:Button ID="btnGetNotExistsID" runat="server" Text="既存しない曲ID" OnClick="btnGetNotExistsID_Click"
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


