<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="NewListMeloImport.aspx.cs" Inherits="Man.ImportMaster.NewListMeloImport"
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
                        <table class="GridDefault">
                             <asp:Repeater id="rptList" runat="server"
                                   onitemdatabound="rptList_ItemDataBound"  OnItemCommand="rptList_ItemCommand">
                                   <HeaderTemplate>
                                        <tr class="GridHeader" id="line" runat="server">
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortSongMediaId" ID="lnkSongMediaId" runat="server" Text="WID" />
                                            </th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortSongId" id="lnkSongId" runat="server" Text="FID" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortTitle" id="lnkTitle" runat="server" Text="曲名" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortArtistId" id="lnkArtistId" runat="server" Text="アーティストID" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortGenreId" id="lnkGenreId" runat="server" Text="ジャンルID" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortAlbumId" id="lnkAlbumId" runat="server" Text="アルバムID" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortLabelId" id="lnkLabelId" runat="server" Text="レーベルID" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortContractorId" id="lnkContractorId" runat="server" Text="契約者" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortCopyrightOrg" id="lnkCopyrightOrg" runat="server" Text="著作権管理団体" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortJasracWorksCode" id="lnkJasracWorksCode" runat="server" Text="JASRAC作品コード" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortIsrcNo" id="lnkIsrcNo" runat="server" Text="ISRC" /></th>
                                            <th class="GridHeader">
                                                <asp:LinkButton CommandName="SortPrice" ID="lnkPrice" runat="server" Text="Price" />
                                            </th>
	        		                    </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                           <tr <asp:Literal ID="ltrBg" runat="server"></asp:Literal>>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongMediaId" runat="server"></asp:Literal>
                                               </td>
                                                <td align="left"><asp:Literal ID="ltrSongId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrTitle" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrArtistId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrGenreId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrAlbumId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrLabelId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrContractorId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrCopyrightOrg" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrJasracWorksCode" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrIsrcNo" runat="server" ></asp:Literal></td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPrice" runat="server"></asp:Literal>
                                               </td>
	        		                            
	        		                       </tr>
                                      </ItemTemplate>
                                      <AlternatingItemTemplate>
                                            <tr <asp:Literal ID="ltrBg" runat="server"></asp:Literal>>
                                               <td align="left">
                                                   <asp:Literal ID="ltrSongMediaId" runat="server"></asp:Literal>
                                               </td>
                                                <td align="left"><asp:Literal ID="ltrSongId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrTitle" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrArtistId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrGenreId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrAlbumId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrLabelId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrContractorId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrCopyrightOrg" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrJasracWorksCode" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrIsrcNo" runat="server" ></asp:Literal></td>
                                               <td align="left">
                                                   <asp:Literal ID="ltrPrice" runat="server"></asp:Literal>
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
                                <td>
                                    <asp:Button ID="btnRegister" runat="server" Text="登録" OnClick="btnRegister_Click"
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


