<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListRbtDownloadImport.aspx.cs" Inherits="Man.ImportMaster.ListRbtDownloadImport"
    Title="�ꊇ�o�^�Ȉꗗ" %>
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
                                                �R���e���cID
                                            </th>
                                            <th class="GridHeader">
                                                CP-ID
                                            </th>
                                            <th class="GridHeader">
                                                �T�C�gID
                                            </th>
                                            <th class="GridHeader">
                                                �R���e���c��
                                            </th>
                                            <th class="GridHeader">
                                                �A�[�e�B�X�g��
                                            </th>
                                            <th class="GridHeader">
                                                �L���t���O
                                            </th>
                                            <th class="GridHeader">
                                                �ۋ��z
                                            </th>
                                            <th class="GridHeader">
                                                �����ݒ�
                                            </th>
                                            <th class="GridHeader">
                                                1��
                                            </th>
                                            <th class="GridHeader">
                                                2��
                                            </th>
                                            <th class="GridHeader">
                                                3��
                                            </th>
                                            <th class="GridHeader">
                                                4��
                                            </th>
                                            <th class="GridHeader">
                                                5��
                                            </th>
                                            <th class="GridHeader">
                                                6��
                                            </th>
                                            <th class="GridHeader">
                                                7��
                                            </th>
                                            <th class="GridHeader">
                                                8��
                                            </th>
                                            <th class="GridHeader">
                                                9��
                                            </th>
                                            <th class="GridHeader">
                                                10��
                                            </th>
                                            <th class="GridHeader">
                                                11��
                                            </th>
                                            <th class="GridHeader">
                                                12��
                                            </th>
                                            <th class="GridHeader">
                                                13��
                                            </th>
                                            <th class="GridHeader">
                                                14��
                                            </th>
                                            <th class="GridHeader">
                                                15��
                                            </th>
                                            <th class="GridHeader">
                                                16��
                                            </th>
                                            <th class="GridHeader">
                                                17��
                                            </th>
                                            <th class="GridHeader">
                                                18��
                                            </th>
                                            <th class="GridHeader">
                                                19��
                                            </th>
                                            <th class="GridHeader">
                                                20��
                                            </th>
                                            <th class="GridHeader">
                                                21��
                                            </th>
                                            <th class="GridHeader">
                                                22��
                                            </th>
                                            <th class="GridHeader">
                                                23��
                                            </th>
                                            <th class="GridHeader">
                                                24��
                                            </th>
                                            <th class="GridHeader">
                                                25��
                                            </th>
                                            <th class="GridHeader">
                                                26��
                                            </th>
                                            <th class="GridHeader">
                                                27��
                                            </th>
                                            <th class="GridHeader">
                                                28��
                                            </th>
                                            <th class="GridHeader">
                                                29��
                                            </th>
                                            <th class="GridHeader">
                                                30��
                                            </th>
                                            <th class="GridHeader">
                                                31��
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
                                    �T�C�g
                                </td>
                                <td style="white-space: nowrap" colspan="5">
                                    <asp:DropDownList ID="drpSite" runat="server" Width="205px">
                                    </asp:DropDownList>
                                </td>
                                <td class="Title" style="white-space: nowrap; width: 100px">
                                    ���єN��
                                </td>
                                <td style="white-space: nowrap; width: 100px">
                                    <asp:TextBox ID="txtPayMonth" runat="server" Width="80px"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender runat="server" ID="MaskedEditExtender1" Mask="9999�N99��"
                                        Enabled="true" TargetControlID="txtPayMonth">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                                
                                <td>
                                    <asp:Button ID="btnRegister" runat="server" Text="�C���|�[�g" OnClick="btnRegister_Click"
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


