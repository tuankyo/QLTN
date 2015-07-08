<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="UpdateTextImport.aspx.cs" Inherits="Man.MasterImport.UpdateTextImport"
    Title="" %>

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

    <contenttemplate>
            <div>
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
                        <td class="MiddleLeft">
                        </td>
                        <td class="MiddleCenter">
                            <asp:MultiValidator ID="mvImportMaster" runat="server" />
                            <table class="Tb100">
                                <tr>
                                    <th colspan="4" style="background-color: #FBAA89">
                                         <asp:Label runat="server" ID="lblHeader" Text="曲【PRText】、アーティスト【プロフィール】、アルバム【コメント】一括更新"></asp:Label>
                        </td>
                    </tr>
<tr>
                        <td class="Title">
                            サイト
                        </td>
                        <td style="white-space: nowrap">
                            <asp:DropDownList ID="drpSite" runat="server" Width="205px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            配信開始日
                        </td>
                        <td>
                            <asp:TextBox ID="txtHaishinDate" runat="server" Width="70px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="txtHaishinDate" Format="yyyy/MM/dd">
                            </ajaxToolkit:CalendarExtender>
                            ～<asp:TextBox ID="txtHaishinEndDate" runat="server" Width="70px"></asp:TextBox><ajaxToolkit:CalendarExtender
                                ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtHaishinEndDate"
                                Format="yyyy/MM/dd">
                            </ajaxToolkit:CalendarExtender>
                            <asp:Button ID="btnDownloadCsv" runat="server" OnClick="btnDownload_Click" Width="80px"
                                Text="CSV出力" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            CSVファイル<font color="red">※</font>
                        </td>
                        <td>
                            <asp:RadioButton id="rdoSong" runat="server" Checked="true" GroupName="Type" Text="曲"/>
                            <asp:RadioButton id="rdoAlbum" runat="server" GroupName="Type" Text="アルバム"/>
                            <asp:RadioButton id="rdoArtist" runat="server" GroupName="Type" Text="アーティスト"/>
                            <br />
                            <asp:FileUpload ID="fileUpload" runat="server" Width="300px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                        </td>
                        <td>
                            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Width="80px"
                                Text="取込" />
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
            </div>
        </contenttemplate>
</asp:Content>
