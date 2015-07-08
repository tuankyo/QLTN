<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="RC_HandoverPaid.aspx.cs" Inherits="Man.RentContract.RC_HandoverPaid"
    Title="Thông Tin Trả Phần Bàn Giao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="content_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Hợp Đồng"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Mã hợp đồng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblId" runat="server" MaxLength="100" Width="95%"></asp:Label>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Khách hàng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblCustomerId" runat="server" MaxLength="100" Width="95%"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Thông Tin Bàn Giao"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Trả Bàn giao<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox Enabled="false" ID="txtItem" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                        <td width="20%" valign="top" class="text_label">
                            Số lượng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtMount" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" valign="top" class="text_label">
                            Ngày trả<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPaidDate" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                TargetControlID="txtPaidDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td width="15%" valign="top" class="text_label">
                            Từ Ông/Bà<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPayer" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" valign="top" class="text_label">
                            Người nhận<font color="red">※</font>
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtReceiver" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" valign="top" class="text_label">
                            Mô tả<font color="red">※</font>
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" MaxLength="100"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="3" MaxLength="100"
                                Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Trở về" Style="white-space: nowrap;"
                                OnClientClick="javascript:history.back()" />
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
                                <td align="center" valign="middle" width="8%">
                                    Ngày trả
                                </td>
                                <td align="center" valign="middle" width="8%">
                                    Số lượng
                                </td>
                                <td align="center" valign="middle">
                                    Nhận từ Ông/Bà
                                </td>
                                <td align="center" valign="middle">
                                    Người nhận
                                </td>
                                <td align="center" valign="middle" width="7%">
                                    Mô tả
                                </td>
                                <td align="center" valign="middle">
                                    Ghi chú
                                </td>
                                <td align="center" valign="middle">
                                    Hủy
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
                                    <asp:Literal ID="ltrPaidDate" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrPayer" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrReceiver" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
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
                                    <asp:Literal ID="ltrPaidDate" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrMount" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrPayer" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrReceiver" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
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
                </table>
            </div>
            <div>
                <asp:HiddenField ID="hidRcID" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hidAction" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
