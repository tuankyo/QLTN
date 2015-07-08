<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_TarrifsElecWaterEdit.aspx.cs" Inherits="Man.Building.TarrifsElecWater.BD_TarrifsElecWaterEdit"
    Title="Thông Tin Biểu Phí Tiền Điện-Nước" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Thông Tin Định Mức Thuộc Nhóm Biểu Phí"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nhóm biểu phí
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpFeeGroup" runat="server" Width="96%" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Định mức<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Chỉ số<font color="red">※</font> (chỉ nhập chỉ số đầu của định mức)
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtIndexFrom" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Đơn giá<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtPriceVND" runat="server" MaxLength="100" Width="20%"></asp:TextBox>VND
                            <asp:TextBox ID="txtPriceUSD" runat="server" MaxLength="100" Width="20%"></asp:TextBox>USD
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
                    <tr>
                        <td class="text_label">
                            Hoạt động
                        </td>
                        <td class="input_form">
                            <asp:CheckBox ID="chkDelFlag" Enabled="false" Checked="true" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Thông Tin Thêm Mới
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblCreated" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Thông Tin Cập Nhật
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                        </td>
                    </tr>
                    <tr class="text_label">
                        <td align="center" colspan="2">
                            <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
                        </td>
                    </tr>
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
                                                Biểu phí
                                            </td>
                                            <td align="center" valign="middle">
                                                Định mức
                                            </td>
                                            <td align="center" valign="middle">
                                                Đơn giá (VND)
                                            </td>
                                            <td align="center" valign="middle">
                                                Đơn giá (USD)
                                            </td>
                                            <td align="center" valign="middle">
                                                Xóa
                                            </td>
                                            <td align="center" valign="middle">
                                                Ghi chú
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
                                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrIndexFrom" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                                    runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
                                            </td>
                                            <td align="left">
                                                <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
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
                                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrIndexFrom" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrPriceVND" runat="server"></asp:Literal>
                                            </td>
                                            <td align="right">
                                                <asp:Literal ID="ltrPriceUSD" runat="server"></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                                    runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
                                            </td>
                                            <td align="left">
                                                <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
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
                    <asp:HiddenField ID="hidFeeGroup" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
