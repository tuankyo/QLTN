<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListBuilding.aspx.cs" Inherits="Man.Admin.ListBuilding"  Title="Danh Sách Chung Cư" %>
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
            if (sender._postBackSettings.sourceElement.id.indexOf("btnDownloadCsv") != -1 ||
                sender._postBackSettings.sourceElement.id.indexOf("btnGetTempOpenDB") != -1) {
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

    <asp:UpdatePanel ID="upListArtist" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">Đang thực hiện yêu cầu...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <div class="row_midpages">
                <div class="width_midpages">
                    <!-- box content main -->
                    <div class="box_contentmain">
                        <!-- end title content main -->
                        <div class="bgtitle_main">
                            <div class="tabs_menu">
                                <ul>
                                    <li class="current"><a href="">
                                        <asp:Label ID="ltrPage" runat="server">Danh sách Tòa Nhà</asp:Label>
                                    </a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <!-- end content form-->
                            <!-- List views form-->
                            <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                            <div class="content_form">
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td class="text_label">
                                            ID
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtId" runat="server" Width="90%"></asp:TextBox>
                                        </td>
                                        <td class="text_label" width="10%">
                                            Tên
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Width="90%"></asp:TextBox>
                                        </td>
                                        <td class="text_label" width="10%">
                                            Địa Chỉ
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress" runat="server" Width="90%"></asp:TextBox>
                                        </td>
                                        <td class="text_label" width="10%">
                                            Ghi Chú
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtComment" runat="server" Width="90%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label" width="15%">
                                            Người Cập Nhật
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpUpdator" runat="server" Width="95%">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="text_label" width="15%">
                                            Ngày Cập Nhật
                                        </td>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtUpdatedFrom" runat="server" Width="70px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                                Enabled="True" TargetControlID="txtUpdatedFrom" Format="yyyy/MM/dd">
                                            </ajaxToolkit:CalendarExtender>
                                            ～
                                            <asp:TextBox ID="txtUpdatedTo" runat="server" Width="70px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                                TargetControlID="txtUpdatedTo" Format="yyyy/MM/dd">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="8">
                                            <asp:Button CssClass="btn_blue" ID="btnSearch" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td>
                                                    <asp:LinkButton CommandName="SortBuildingID" ID="lnkId" runat="server" Text="ID" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton CommandName="SortName" ID="lnkName" runat="server" Text="Tên" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton CommandName="SortAddress" ID="lnkAddress" runat="server" Text="Địa chỉ" />
                                                </td>
                                                <td>
                                                    Chú thích
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="SelectedList">
                                                <td align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
