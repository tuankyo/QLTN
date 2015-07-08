<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_DocumentEdit.aspx.cs" Inherits="Man.Building.Document.BD_DocumentEdit"
    Title="Cập nhật thông tin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdateProgress ID="upList" runat="server">
        <ProgressTemplate>
            <font color="Red">Đang thực hiện yêu cầu...</font>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="edit_form">
        <div class="title_form">
            <asp:Label runat="server" ID="lblHeader" Text="Cập nhật hồ sơ"></asp:Label>
        </div>
        <table cellpadding="1" cellspacing="1" width="100%">
            <tr>
                <td valign="top" class="text_label">
                    Nhóm hồ sơ (cấp 1)<font color="red">※</font>
                </td>
                <td class="input_form">
                    <asp:DropDownList ID="drpParentId" runat="server" Width="80%" AutoPostBack="true"
                        OnSelectedIndexChanged="drpParentIdSelectedIndexChanged" />
                </td>
            </tr>
            <tr>
                <td valign="top" class="text_label">
                    Phân nhóm hồ sơ<font color="red">※</font>
                </td>
                <td class="input_form">
                    <asp:DropDownList ID="drpDocSubject" runat="server" Width="80%" />
                </td>
            </tr>
            <tr>
                <td valign="top" class="text_label" width="20%">
                    Nhóm hồ sơ<font color="red">※</font>
                </td>
                <td class="input_form">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="80%" />
                    (50 ký tự)
                </td>
            </tr>
            <tr>
                <td valign="top" class="text_label">
                    Tên/Nội dung
                </td>
                <td class="input_form">
                    <asp:TextBox ID="txtAppeal" runat="server" MaxLength="250" TextMode="MultiLine" Rows="3"
                        Width="80%" />
                    (250 ký tự)
                </td>
            </tr>
            <tr>
                <td valign="top" class="text_label">
                    Ngày hồ sơ
                </td>
                <td class="input_form">
                    <asp:TextBox ID="txtDocDate" runat="server" Width="90%" />
                    <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                        Enabled="True" TargetControlID="txtDocDate" Format="dd/MM/yyyy">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td valign="top" class="text_label">
                    Chọn File<font color="red">※</font>
                </td>
                <td class="input_form">
                    <input type="file" id="File1" name="File1" runat="server" />(tên file không có dấu
                    Tiếng Việt, khoảng cách)
                </td>
            </tr>
            <tr>
                <td width="20%" valign="top" class="text_label">
                    Ghi chú
                </td>
                <td class="input_form">
                    <asp:TextBox ID="txtComment" runat="server" MaxLength="250" TextMode="MultiLine"
                        Rows="3" Width="80%" />(250 ký tự)
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                    <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Cập Nhật" runat="server"
                        OnClick="btnRegister_Click" Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                    <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                        Style="white-space: nowrap;" Text="Đóng" />
                </td>
            </tr>
        </table>
        <div>
            <asp:HiddenField ID="hidDocType" runat="server" />
            <asp:HiddenField ID="hidId" runat="server" />
        </div>
    </div>
</asp:Content>
