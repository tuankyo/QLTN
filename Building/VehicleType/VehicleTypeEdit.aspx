<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="VehicleTypeEdit.aspx.cs" Inherits="Man.MasterData.VehicleType.VehicleTypeEdit"
    Title="Thông Tin Loại Xe Được Phép Gửi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <table class="TbNoHeader" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="TopLeft">
                    </td>
                    <td class="TopHeader">
                    </td>
                    <td class="TopRight">
                    </td>
                </tr>
                <tr>
                    <td class="MiddleLeft">
                    </td>
                    <td class="MiddleCenter">
                        <table class="Tb100">
                            <tr>
                                <th colspan="4">
                                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Chi Tiết Loại Phí Giữ Xe"></asp:Label>
                                </th>
                            </tr>
                    </td>
                </tr>
                <div>
                    <tr>
                        <td class="Title" style="width: 10%">
                            Mã Loại Xe
                        </td>
                        <td>
                            <asp:TextBox ReadOnly="true" ID="txtId" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="width: 10%">
                            Tên Loại Xe<font color="red">※</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            Ghi Chú
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="10" TextMode="MultiLine"
                                Width="98%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            Hoạt động
                        </td>
                        <td colspan="3">
                            <asp:CheckBox ID="chkDelFlag" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            Thông Tin Thêm Mới
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblCreated" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="Title">
                            Thông Tin Cập Nhật
                        </td>
                        <td colspan="3">
                            <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </div>
                <tr>
                    <td colspan="2">
                        <asp:MultiValidator ID="mvVehicleTypeEdit" runat="server" />
                    </td>
                </tr>
                <tr class="Title">
                    <td align="center" colspan="4">
                        <table border="0" width="100%" class="Noboder" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Style="white-space: nowrap;"
                                        Width="80px" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                                    <asp:Button ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                        Style="white-space: nowrap;" Width="80px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </td>
            <td class="MiddleRight">
            </td>
            </tr>
            <tr>
                <td class="BottomLeft">
                </td>
                <td class="BottomCenter">
                </td>
                <td class="BottomRight">
                </td>
            </tr>
            </table>
            <div>
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hidAction" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
