<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_Document.aspx.cs" Inherits="Man.Building.Document.BD_Document"
    Title="Danh sách Hồ sơ" %>

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
                                <asp:Label ID="ltrPage" runat="server"></asp:Label>
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
                                <td valign="top" class="text_label">
                                    Tên hồ sơ<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Nhóm hồ sơ<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:DropDownList ID="drpDocSubject" runat="server" Width="90%" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Công văn<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:RadioButton ID="rdoOutDoc" Checked="true" runat="server" Text="Đi" GroupName="InOutDoc" />
                                    <asp:RadioButton ID="rdoInDoc" runat="server" Text="Đến" GroupName="InOutDoc" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Công văn từ<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:RadioButton ID="rdoCDT" Checked="true" runat="server" Text="Chủ đầu tư" GroupName="DocFrom" />
                                    <asp:RadioButton ID="rdoCustomer" runat="server" Text="Khách Hàng" GroupName="DocFrom" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Nội dung
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtAppeal" runat="server" MaxLength="250" TextMode="MultiLine" Rows="3"
                                        Width="95%" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Chọn File<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <input type="file" id="File1" name="File1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td width="10%" valign="top" class="text_label">
                                    Ghi chú
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtComment" runat="server" MaxLength="250" TextMode="MultiLine"
                                        Rows="3" Width="95%" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Thêm Mới" runat="server" OnClick="btnRegister_Click"
                                        Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                                    <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                        Style="white-space: nowrap;" Text="Đóng" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td colspan="2">
                                    <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                    </cc:Pager>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                            OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
                                                        Tên hồ sơ
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Nhóm
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Công văn
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Công văn từ
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Nội dung
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Ghi chú
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Cập nhật
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Xóa
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Người Cập Nhật
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Ngày Cập Nhật
                                                    </td>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="left">
                                                        <asp:LinkButton CommandName="View" ID="btnView" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocSubject" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrInOutDoc" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocFrom" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrAppeal" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:LinkButton CommandName="View" ID="btnEdit" runat="server" Text="Cập nhật" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                                            CommandName="Delete" runat="server" Text="Xóa" />
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
                                                        <asp:LinkButton CommandName="View" ID="btnView" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocSubject" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrInOutDoc" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocFrom" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrAppeal" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:LinkButton CommandName="View" ID="btnEdit" runat="server" Text="Cập nhật" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                                            CommandName="Delete" runat="server" Text="Xóa" />
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
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:HiddenField ID="hidId" runat="server" />
                            <asp:HiddenField ID="hidAction" runat="server" />
                            <asp:HiddenField ID="hidDocType" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
