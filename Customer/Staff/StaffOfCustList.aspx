<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="StaffOfCustList.aspx.cs" Inherits="Man.Customer.Staff.StaffOfCustList"
    Title="Danh sách Nhân viên Của Khách Hàng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdateProgress ID="upList" runat="server">
        <ProgressTemplate>
            <font color="Red">Đang thực hiện yêu cầu...</font>
        </ProgressTemplate>
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
                                <asp:Label ID="ltrPage" runat="server">Nhân Viên Của Khách Hàng</asp:Label>
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
                        <div class="title_form">
                            <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Nhân Viên"></asp:Label>
                        </div>
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Họ Tên<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Địa chỉ<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Số điện thoại<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="15%" valign="top" class="text_label">
                                    Mail
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtMail" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="text_label">
                                    Ghi Chú
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="3" TextMode="MultiLine"
                                        Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="text_label">
                                <td align="center" colspan="2">
                                    <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Trở về" Style="white-space: nowrap;"
                                        OnClientClick="javascript:history.back()" />
                                    <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                                        Text="Thêm Mới" Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
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
                                            Họ Tên
                                        </td>
                                        <td align="center" valign="middle">
                                            Địa chỉ
                                        </td>
                                        <td align="center" valign="middle">
                                            Điện thoại
                                        </td>
                                        <td align="center" valign="middle">
                                            Mail
                                        </td>
                                        <td align="center" valign="middle">
                                            Ghi chú
                                        </td>
                                        <td align="center" valign="middle">
                                            Xóa
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
                                        <td align="left">
                                            <asp:LinkButton ID="btnName" CommandName="Edit" runat="server"></asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrMail" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center">
                                            <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                                runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
                                        <td align="left">
                                            <asp:LinkButton ID="btnName" CommandName="Edit" runat="server"></asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrMail" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center">
                                            <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                                runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
                        <asp:HiddenField ID="hidID" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
