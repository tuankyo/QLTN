<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="UsedWaterRoom.aspx.cs" Inherits="Man.RentContract.UsedWaterRoom"
    Title="Chỉ số sử dụng nước" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upRentContract" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">Đang thực hiện yêu cầu...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
            <table class="TableNoHeader" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="TopLeft">
                    </td>
                    <td class="TopCenter">
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
                                <td class="Title" style="width: 10%">
                                    Mã tòa nhà
                                </td>
                                <td>
                                    <asp:Label ID="lblBuildingId" runat="server"></asp:Label>
                                </td>
                                <td class="Title" style="width: 10%">
                                    Tòa nhà
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </td>
                                <td class="Title" style="width: 10%">
                                    Tên chủ đầu tư
                                </td>
                                <td>
                                    <asp:Label ID="lblInvestor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="Title" style="width: 10%">
                                    Địa chỉ
                                </td>
                                <td>
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                </td>
                                <td class="Title" style="width: 10%">
                                    Người đại diện
                                </td>
                                <td>
                                    <asp:Label ID="lblOwner" runat="server"></asp:Label>
                                </td>
                                <td class="Title" style="width: 10%">
                                    Số điện thoại
                                </td>
                                <td>
                                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="Title" style="width: 10%">
                                    Công ty quả lý
                                </td>
                                <td>
                                    <asp:Label ID="lblManagerCompany" runat="server"></asp:Label>
                                </td>
                                <td class="Title" style="width: 10%">
                                    Người đại diện công ty
                                </td>
                                <td>
                                    <asp:Label ID="lblManagerCompanyAgent" runat="server"></asp:Label>
                                </td>
                                <td class="Title" style="width: 10%">
                                    Số điện thoại công ty
                                </td>
                                <td>
                                    <asp:Label ID="lblManagerCompanyPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="Title">
                                    Ghi Chú
                                </td>
                                <td colspan="5">
                                    <asp:Label ID="lblComment" runat="server" MaxLength="200" Rows="10" Width="95%"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="MiddleRight">
                    </td>
                </tr>
                <tr>
                    <td class="MiddleLeft">
                    </td>
                    <td class="MiddleCenter">
                        <cc:Pager ID="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                        </cc:Pager>
                        <table class="GridDefault">
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                OnItemCommand="rptList_ItemCommand">
                                <HeaderTemplate>
                                    <tr class="GridHeader">
                                        <th class="GridHeader">
                                            Tháng/Năm
                                        </th>
                                        <th class="GridHeader">
                                            Khu vực
                                        </th>
                                        <th class="GridHeader">
                                            Lầu
                                        </th>
                                        <th class="GridHeader">
                                            Phòng
                                        </th>
                                        <th class="GridHeader">
                                            Chỉ số cũ
                                        </th>
                                        <th class="GridHeader">
                                            Chỉ số mới
                                        </th>
                                        <th>
                                            Xóa
                                        </th>
                                        <th class="GridHeader">
                                            Ghi chú
                                        </th>
                                        <th class="GridHeader">
                                            Cập Nhật
                                        </th>
                                        <th class="GridHeader">
                                            Ngày Cập Nhật
                                        </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <asp:Literal ID="ltrYearMonth" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrRegional" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrRoomName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrOldIndex" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrNewIndex" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btnDelete" CommandName="Delete" Text="Xóa" runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
                                        <td align="center">
                                            <asp:Literal ID="ltrYearMonth" runat="server" />
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrRegional" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrRoomName" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrOldIndex" runat="server"></asp:Literal>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrNewIndex" runat="server"></asp:Literal>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btnDelete" CommandName="Delete" Text="Xóa" runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
            <table class="TbNoHeader" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="TopLeft">
                    </td>
                    <td class="TopCenter">
                    </td>
                    <td class="TopRight">
                    </td>
                </tr>
                <tr>
                    <td class="MiddleLeft">
                    </td>
                    <td class="MiddleCenter">
                        <table class="Tb100" border="1" bordercolor="#c0c0c0" algin="right">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click" Width="80px" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
