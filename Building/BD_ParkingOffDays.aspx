<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_ParkingOffDays.aspx.cs" Inherits="Man.Building.BD_ParkingOffDays"
    Title="Thiết lập ngày không tính tiền gửi xe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">Đang thực hiện yêu cầu...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <div class="edit_form">
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td colspan="4">
                            <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="title_form">
                                Thiết lập ngày nghỉ</div>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label" width="20%">
                            Thiết lập ngày nghỉ tháng
                        </td>
                        <td class="input_form" colspan="3">
                            <asp:DropDownList ID="drpMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="btnSelectYM_Click">
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="btnSelectYM_Click">
                            </asp:DropDownList>
                            bao gồm các ngày
                            <asp:Button ID="Button1" runat="server" Text="T7" Width="50px" OnClick="btnT7_Click" />
                            <asp:Button ID="Button3" runat="server" Text="CN" Width="50px" OnClick="btnCN_Click" />
                            <asp:Button ID="Button4" runat="server" Text="Lễ" Width="50px" OnClick="btnLE_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                        </td>
                        <td align="center" class="input_form" width="30%">
                            Ngày trong tháng
                        </td>
                        <td align="center" class="input_form" width="20%">
                            Chọn/Hủy ngày nghỉ
                        </td>
                        <td align="center" class="input_form" width="30%">
                            Ngày nghỉ
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Thiết lập
                        </td>
                        <td align="left" class="input_form" width="30%">
                            <asp:ListBox ID="lstYearMonth" runat="server" SelectionMode="Multiple" Width="95%"
                                Height="450px"></asp:ListBox>
                        </td>
                        <td align="center" class="input_form" width="20%">
                            <asp:Button ID="btnSelect" runat="server" Text=">" Width="50px" OnClick="btnSelect_Click" /><br />
                            <br />
                            <asp:Button ID="btnUnSelect" runat="server" Text="<" Width="50px" OnClick="btnUnSelect_Click" /><br />
                        </td>
                        <td align="left" class="input_form" width="30%">
                            <asp:ListBox ID="lstSelectedYearMonth" runat="server" SelectionMode="Multiple" Width="95%"
                                Height="450px"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
