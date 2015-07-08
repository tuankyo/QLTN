<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="Help.aspx.cs" Inherits="Man.Help.Help" Title="Danh Sách Tòa Nhà Cho Thuê" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBuilding" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Hướng Dẫn Sử Dụng" runat="server" /></a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <!-- end content form-->
                            <!-- List views form-->
                            <div class="content_form">
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr class="row_title">
                                        <td align="center" valign="middle">
                                            <a href="javascript: void(0)" onclick="window.open('/Help/1_THONG TIN TOA NHA.pdf', 
  'windowname1'); 
   return false;">Thông Tin Tòa Nhà</a>
                                        </td>
                                    </tr>
                                    <tr class="row_title">
                                        <td align="center" valign="middle">
                                            <a href="javascript: void(0)" onclick="window.open('/Help/2_QUAN LY HOAT DONG.pdf', 
  'windowname1'); 
   return false;">Quản Lý Hoạt Động</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="bgbottom_main">
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
