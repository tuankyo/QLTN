<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="VehicleTypeList.aspx.cs" Inherits="Man.MasterData.VehicleType.VehicleTypeList"
    Title="Danh Sách Loại Xe Được Phép Gửi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upVehicleType" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">Đang thực hiện yêu cầu...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <asp:MultiValidator ID="mvldMessage" runat="server" Align="Center" />
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
                        <cc:Pager ID="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                        </cc:Pager>
                        <table class="GridDefault">
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                OnItemCommand="rptList_ItemCommand">
                                <HeaderTemplate>
                                    <tr class="GridHeader">
                                        <th class="GridHeader">
                                            <asp:LinkButton CommandName="SortTenementID" ID="lnkId" runat="server" Text="ID" />
                                        </th>
                                        <th class="GridHeader">
                                            <asp:LinkButton CommandName="SortName" ID="lnkName" runat="server" Text="Vật Dụng" />
                                        </th>
                                        <th class="GridHeader">
                                            Ghi chú
                                        </th>
                                        <th class="GridHeader">
                                            <asp:LinkButton CommandName="SortModifiedBy" ID="lnkModifiedBy" runat="server" Text="Cập Nhật" />
                                        </th>
                                        <th class="GridHeader">
                                            <asp:LinkButton CommandName="SortModified" ID="lnkModified" runat="server" Text="Ngày Cập Nhật" />
                                        </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrName" runat="server"></asp:Literal>
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
                                            <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            <asp:Literal ID="ltrName" runat="server"></asp:Literal>
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
                                    <asp:Button ID="Button2" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click" Width="80px" />
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
