<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" 
CodeBehind="ErrorDemandData.aspx.cs" Inherits="Man.MasterImport.ErrorDemandData" %>
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
                iframe.src = "../CSV/DownloadZipFile.aspx";
                // This makes the IFRAME invisible to the user.
                iframe.style.display = "none";
                // Add the IFRAME to the page.  This will trigger
                //   a request to GenerateFile now.
                document.body.appendChild(iframe);
            }
            if (sender._postBackSettings.sourceElement.id.indexOf("btnGetTempOpenDB") != -1) {
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

  
        <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="TbNoHeader">
                    <tr>
                        <td class="TopLeft">
                        </td>
                        <td class="TopHeader">
                        </td>
                        <td class="TopRight">
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="MiddleLeft"></td>
                        <td class="MiddleCenter">
                            <asp:MultiValidator ID="mvImportMaster" runat="server" />
                            <table class="Tb100">
                            <tr>
                                <th colspan="2" style="background-color: #FBAA89">
                                <asp:Label runat="server" ID="lblHeader" Text="AUエラー請求データ入出"></asp:Label>
                                </td>
                        </tr>
                    <tr>
                        <td class="Title"> 明細ファイル<font color="red">※</font> </td>
                        <td><asp:FileUpload ID="fileUploadFile" runat="server"/></td>
                    </tr>
                    
                    <tr>
                        <td class="Title"></td>
                        <td>
                            <asp:Button ID="btnUpload" runat="server" Width="80px"
                                Text="取込" onclick="btnUpload_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            サイト</td>
                        <td style="white-space: nowrap">
                            <asp:DropDownList ID="drpSite" runat="server" Width="205px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            年月</td>
                        <td style="white-space: nowrap">
                            <asp:TextBox ID="txtErrorDate" runat="server" Width="80px" MaxLength="10"></asp:TextBox>                                                                                                                
                                <ajaxToolkit:MaskedEditExtender runat="server" ID="MaskedEditExtender2"  
                                    Mask="9999/99" Enabled="true" TargetControlID="txtErrorDate">
                                </ajaxToolkit:MaskedEditExtender>
                            <asp:Button ID="btnSearch" runat="server" Text ="検索" Width="80px" 
                                onclick="btnSearch_Click"/>
                        </td>
                    </tr>
                </table>
                <asp:MultiValidator ID="mvldMessage" runat="server" Align="Center" />
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">実行中...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <div id="divResult" runat="server" visible="False">
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
                            <cc:Pager ID="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                            </cc:Pager>
                            <asp:Panel ID="pan1" runat="server" Width="1024px" Height="500px" ScrollBars="Both">
                                <table class="GridDefault">
                                    <tr>
                                        <td>
                                            <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand" 
                                                onitemdatabound="rptList_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr class="GridHeader">
                                                        <th class="GridHeader">
                                                            <asp:LinkButton CommandName="SortSite" ID="lnkSite" runat="server" Text="サイト名" />
                                                        </th>
                                                        <th class="GridHeader">
                                                            <asp:LinkButton CommandName="SortErrorDate" ID="lnkErrorDate" runat="server" Text="請求エラー処理日" />
                                                        </th>
                                                        <th class="GridHeader">
                                                            <asp:LinkButton CommandName="SortPointTotal" ID="lnkPointTotal" runat="server" Text="課金（税抜）" />
                                                        </th>
                                                        <!-- QDo start 110131 -->
                                                        <th class="GridHeader">
                                                            課金（税込）
                                                        </th>
                                                        <!-- QDo end 110131 -->
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Literal ID="ltrSite" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Literal ID="ltrErrorDate" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Literal ID="ltrPointTotal" runat="server" />
                                                        </td>
                                                        
                                                        <!-- QDo start 110131 -->
                                                        <td align="left">
                                                            <asp:Literal ID="ltrPointZeiKomiTotal" runat="server" />
                                                        </td>
                                                        <!-- QDo end 110131 -->
                                                        
                                                    </tr>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Literal ID="ltrSite" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Literal ID="ltrErrorDate" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Literal ID="ltrPointTotal" runat="server" />
                                                        </td>
                                                        
                                                        <!-- QDo start 110131 -->
                                                        <td align="left">
                                                            <asp:Literal ID="ltrPointZeiKomiTotal" runat="server" />
                                                        </td>
                                                        
                                                        
                                                    </tr>
                                                </AlternatingItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                         <th align="left"><asp:Label ID="Label1" runat="server" Text="合計" Width="100px"></asp:Label></th>
                                         <th></th>
                                         <th align="left"><asp:Label ID="lblZeiNukiTotal" runat="server" Text="" Width="100px"></asp:Label></th>
                                         <th align="left"><asp:Label ID="lblZeiKomiTotal" runat="server" Text="" Width="100px"></asp:Label></th>
                                    </tr>
                                    <!-- QDo end 110131 -->
                                    
                                </table>
                            </asp:Panel>
                </div>            
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
                </table>
        </ContentTemplate>
</asp:Content>
