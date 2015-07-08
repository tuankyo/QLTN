<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="RentContractList.aspx.cs" Inherits="Man.RentContract.RentContractList"
    Title="Danh Sách Hợp Đồng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upRentContract" runat="server">
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
                                        <asp:Label ID="Label1" Text="Hơp đồng thuê" runat="server"></asp:Label>
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
                                        <td width="25%" valign="top" class="text_label">
                                            Mã khách hàng
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblCustomerId" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%" valign="top" class="text_label">
                                            Khách hàng
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblName" runat="server" MaxLength="100" Width="95%"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text_label">
                                            Ghi Chú
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblComment" runat="server" MaxLength="200" Rows="10" TextMode="MultiLine"
                                                Width="95%"></asp:Label>
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
                                                <td align="center" valign="middle">
                                                    Mã HĐ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Ngày HĐ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Kết thúc HĐ
                                                </td>
                                                <td align="center" valign="middle">
                                                    HĐ thuê
                                                </td>
                                                <td align="center" valign="middle">
                                                    Ngày bàn giao
                                                </td>
                                                <td align="center" valign="middle">
                                                    Bàn giao - Trả
                                                </td>
                                                <td align="center" valign="middle">
                                                    Bồi thường
                                                </td>
                                                <td align="center" valign="middle">
                                                    Hồ sơ
                                                </td>
                                                <td align="center" valign="middle">
                                                    Cập Nhật
                                                </td>
                                                <td align="center" valign="middle">
                                                    Ngày Cập Nhật
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrContractDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrContractEndDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnRoom" runat="server" CommandName="RoomSetting"
                                                        Text="+" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrReceiveDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnHandover" runat="server" CommandName="RoomSetting"
                                                        Text="Chi tiết" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnIndemnify" runat="server" CommandName="RoomSetting"
                                                        Text="Chi tiết" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDoc" runat="server" CommandName="Document"
                                                        Text="+" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrModifiedBy" runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrModified" runat="server" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="SelectedList">
                                                <td align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrContractDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrContractEndDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnRoom" runat="server" CommandName="RoomSetting"
                                                        Text="+" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrReceiveDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnHandover" runat="server" CommandName="RoomSetting"
                                                        Text="Chi tiết" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnIndemnify" runat="server" CommandName="RoomSetting"
                                                        Text="Chi tiết" />
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue_short" ID="btnDoc" runat="server" CommandName="Document"
                                                        Text="+" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrModifiedBy" runat="server" />
                                                </td>
                                                <td align="center">
                                                    <asp:Literal ID="ltrModified" runat="server" />
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <br />
                                <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Trở về" Style="white-space: nowrap;"
                                    OnClientClick="javascript:history.back()" />
                                <asp:Button CssClass="btn_blue" ID="btnGetId" runat="server" Text="Cấp Phát ID" OnClick="btnAutoId_Click"
                                    Width="100px" />
                                <asp:TextBox ID="txtAutoId" Enabled="false" runat="server"></asp:TextBox>
                                <asp:Button CssClass="btn_blue" ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click" />
                                <asp:HiddenField ID="hidID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
