<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="UsedElectricRoomEdit.aspx.cs" Inherits="Man.RentContract.UsedElectricRoomEdit"
    Title="Thông Tin Hợp Đồng Thuê Phòng" %>

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
                                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Loại Phòng"></asp:Label>
                                </th>
                            </tr>
                    </td>
                </tr>
                <!----------------------------------------------------------------------->
                <div>
                    <tr>
                        <td class="Title" style="width: 10%">
                            Phòng<font color="red">※</font>
                        </td>
                        <td colspan='3'>
                            <asp:DropDownList ID="drpRoom" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="width: 10%">
                            Năm tháng<font color="red">※</font>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="drpMonth" runat="server" MaxLength="100" Width="95%" />
                            <asp:DropDownList ID="drpYear" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="width: 10%">
                            Chỉ số cữ<font color="red">※</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOldIndex" runat="server" MaxLength="100" Width="95%" />
                        </td>
                        <td class="Title" style="width: 10%">
                            Chỉ số mới<font color="red">※</font>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewIndex" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Title" style="width: 10%">
                            Ghi chú
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                </div>
                <!------------------------------------------------------------------------->
                <tr>
                    <td colspan="4">
                        <asp:MultiValidator ID="mvMessage" runat="server" />
                    </td>
                </tr>
                <tr class="Title">
                    <td align="center" colspan="4">
                        <table border="0" width="100%" class="Noboder" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnRegister" Text="Thêm Mới" runat="server" OnClick="btnRegister_Click"
                                        Style="white-space: nowrap;" Width="80px" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                                    <asp:Button ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                        Style="white-space: nowrap;" Width="80px" Text="Đóng" />
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
