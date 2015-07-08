<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_FeeGroup.aspx.cs" Inherits="Man.Building.TarrifsElecWater.BD_FeeGroup"
    Title="Thông Tin Biểu Phí Tiền Điện-Nước" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Nhóm Biểu Phí"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nhóm biểu phí
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" Width="95%"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label" style="width: 10%">
                            VAT<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtVAT" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label" style="width: 10%">
                            <asp:Label ID="lblOtherFee1" runat="server"></asp:Label> <font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOtherFee1" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label" style="width: 10%">
                            <asp:Label ID="lblOtherFee2" runat="server"/><font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOtherFee2" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Ghi Chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="3" TextMode="MultiLine"
                                Width="98%"></asp:TextBox>
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
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Style="white-space: nowrap;"
                                Width="80px" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" Width="80px" />
                        </td>
                    </tr>
                </table>
                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                </cc:Pager>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                        OnItemCommand="rptList_ItemCommand">
                        <HeaderTemplate>
                            <tr class="row_title">
                                <td align="center" valign="middle">
                                    Nhóm biểu phí
                                </td>
                                <td align="center" valign="middle">
                                    VAT
                                </td>
                                <td align="center" valign="middle">
                                    Phụ thu khác
                                </td>
                                <td align="center" valign="middle">
                                    Phụ thu khác
                                </td>
                                <td>
                                    Cập nhật
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
                                    <asp:TextBox ID="txtName" runat="server" />
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrVAT" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
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
                                    <asp:TextBox ID="txtName" runat="server" />
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrVAT" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrOtherFee01" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrOtherFee02" runat="server"></asp:Literal>
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
                <div>
                    <asp:HiddenField ID="hidId" runat="server" />
                    <asp:HiddenField ID="hidAction" runat="server" />
                    <asp:HiddenField ID="hidFeeGroup" runat="server" />
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
