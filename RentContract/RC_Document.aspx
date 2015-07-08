<%@ Page Language="C#" MasterPageFile="~/MasterPage/Popup.Master" AutoEventWireup="true"
    CodeBehind="RC_Document.aspx.cs" Inherits="Man.RentContract.RC_Document" Title="Danh sách Hồ sơ" %>

<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPopUp" runat="server">
    <div class="content_form">
        <div class="title_form">
            <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Hồ Sơ"></asp:Label>
        </div>
        <table cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td width="25%" valign="top" class="text_label">
                    Tên hồ sơ<font color="red">※</font>
                </td>
                <td class="input_form">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%" />
                </td>
            </tr>
            <tr>
                <td width="25%" valign="top" class="text_label">
                    Chọn File<font color="red">※</font>
                </td>
                <td class="input_form">
                    <input type="file" id="File1" name="File1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="25%" valign="top" class="text_label">
                    Ghi chú
                </td>
                <td class="input_form">
                    <asp:TextBox ID="txtComment" runat="server" MaxLength="100" Width="95%" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:MultiValidator ID="mvMessage" runat="server" />
                    <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Thêm Mới" runat="server" OnClick="btnRegister_Click"
                        Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                    <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                        Style="white-space: nowrap;" Text="Đóng" />
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
                            ID
                        </td>
                        <td align="center" valign="middle">
                            Tài liệu
                        </td>
                        <td align="center" valign="middle">
                            Ghi chú
                        </td>
                        <td align="center" valign="middle">
                            Cập nhật
                        </td>
                        <td align="center" valign="middle">
                            Xóa
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
                            <asp:LinkButton CommandName="View" ID="btnView" runat="server" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="95%" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtComment" runat="server" runat="server" Width="95%" />
                        </td>
                        <td align="center">
                            <asp:Button CssClass="btn_blue" ID="btnUpdate" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                CommandName="Update" runat="server" Text="Cập nhật" />
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
                            <asp:TextBox ID="txtName" runat="server" Width="95%" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtComment" runat="server" runat="server" Width="95%" />
                        </td>
                        <td align="center">
                            <asp:Button CssClass="btn_blue" ID="btnUpdate" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                CommandName="Update" runat="server" Text="Cập nhật" />
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
        <div>
            <asp:HiddenField ID="hidId" runat="server" />
            <asp:HiddenField ID="hidAction" runat="server" />
            <asp:HiddenField ID="hidDocType" runat="server" />
        </div>
    </div>
</asp:Content>
