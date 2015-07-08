<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListUtaRegister.aspx.cs" Inherits="Man.MasterImport.ListUtaRegister"
    Title="SoftbankﾗｲｾﾝｽｷｰDB入れ込み" %>
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
    if (sender._postBackSettings.sourceElement.id.indexOf("btnDownloadCsv") != -1)
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
                        <table class="Tb100" border="0" borderColor="#c0c0c0" algin="right"  >
                            <tr>
                                <td class="Title" style="width:15%">フォルダバス</td>
                                <td><asp:Label ID="lblFolderPath" runat="server"></asp:Label> </td>
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
              <asp:MultiValidator ID="mvldMessage" runat="server" Align="Center"/>
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
                                    <cc:Pager ID="pager" runat="server" onpageindexchanged="pager_PageIndexChanged">
                                    </cc:Pager>
                                    <table class="GridDefault">
                                        <asp:Repeater id="rptList" runat="server"
                                            onitemdatabound="rptList_ItemDataBound"  OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="GridHeader">
                                                     <!--
                                                     <th class="GridHeader">
                                                        <input type="checkbox" id="all" name="chkAll" onclick="javascript:CheckAllDataGridCheckBoxes('chkItem',this)" runat="server"></th>
                                                     -->   
                                                     <th class="GridHeader"><asp:LinkButton CommandName="SortId" id="lnkId" runat="server" Text="ID" /></th>
                                                     <th class="GridHeader" runat="server" id="thExtension" >フルID</th>
                                                     <th class="GridHeader"></th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                     <!--
                                                     <td align="center">
                                                        <asp:CheckBox id="chkItem" runat="server"/>
                                                     </td>
                                                     -->
                                                     
                                                     <td align="center"><asp:Literal ID="ltrId" runat="server" ></asp:Literal></td>
                                                     <td align="right" runat="server" id="tdExtension"><asp:Literal ID="ltrExtension" runat="server" ></asp:Literal></td>
                                                     <td align="center"><asp:Button id="btnDelete" CommandName="Delete" runat="server" Text="削除" /></td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="SelectedList">
                                                     <!--
                                                     <td align="center">
                                                        <asp:CheckBox id="chkItem" runat="server"/>
                                                     </td>
                                                     -->
                                                     <td align="center"><asp:Literal ID="ltrId" runat="server" ></asp:Literal></td>
                                                     <td align="right" runat="server" id="tdExtension"><asp:Literal ID="ltrExtension" runat="server" ></asp:Literal></td>
                                                     <td align="center"><asp:Button id="btnDelete" CommandName="Delete" runat="server" Text="削除" /></td>
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
                       <td class="MiddleLeft"></td>
                       <td class="MiddleCenter">
                           <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSiteUpd" runat="server" Text="実行" OnClick="btnSiteUpd_Click" Width="80px" />
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
              
            <div>
                <asp:HiddenField ID = "hidFuncId" runat="server" />
                <asp:HiddenField ID = "hidTypeId" runat="server" />
                <asp:HiddenField ID = "hidCareer" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
