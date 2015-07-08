<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_ProviderEvalEdit.aspx.cs" Inherits="Man.Building.Provider.BD_ProviderEvalEdit"
    Title="Thông Tin Đánh Giá Nhà Cung Cấp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Chi Tiết Đánh Giá Nhà Cung Cấp"></asp:Label></div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã Nhà Cung Cấp
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblProviderId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tên
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblName" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="title_form">
                                Đánh giá nhà cung cấp</div>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ngày đánh giá<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtEvalDate" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="txtEvalDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nội dung<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtContentEval" TextMode="MultiLine" Rows="3" runat="server" MaxLength="100"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="3" runat="server" MaxLength="100"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="text_label">
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Trở về" Style="white-space: nowrap;"
                                    OnClientClick="javascript:history.back()" />
                            <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Cập Nhật" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
