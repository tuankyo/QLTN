<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_SuppliesStatus.aspx.cs" Inherits="Man.Building.Supplies.BD_SuppliesStatus"
    Title="Thông Tin Tình Trạng Thiết Bị" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="edit_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Trạng Thái"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mã
                        </td>
                        <td class="input_form">
                            <asp:Label ID="lblCreatedId" runat="server" />
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
                </table>
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Tình Trạng"></asp:Label>
                </div>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Khu vực<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtRegion" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Lầu<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtFloor" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Phòng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtRoom" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Hệ thống<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtSystem" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ngày<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtProcessDate" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="txtProcessDate" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Tình Trạng<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpSuppliesStatus" runat="server" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Mô tả<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" MaxLength="200"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Hướng xử lý<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" Rows="3" MaxLength="100"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Người xử lý<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtSolutioner" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="250" TextMode="MultiLine"
                                Rows="3" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    </td>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" />
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
                                <td align="center" valign="middle">
                                    Trạng thái
                                </td>
                                <td align="center" valign="middle">
                                    Ngày
                                </td>
                                <td align="center" valign="middle">
                                    Mô tả
                                </td>
                                <td align="center" valign="middle">
                                    Ghi chú
                                </td>
                                <td align="center" valign="middle">
                                    Cập nhật
                                </td>
                                <td align="center" valign="middle">
                                    Xóa
                                </td>
                                <td align="center" valign="middle">
                                    Người Cập Nhật
                                </td>
                                <td align="center" valign="middle">
                                    Ngày Cập Nhật
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="left">
                                    <asp:Literal ID="ltrSuppliesStatus" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrProcessDate" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnUpdate" Text="Cập nhật" CommandName="Update"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                        runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
                                    <asp:Literal ID="ltrSuppliesStatus" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrProcessDate" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                </td>
                                <td align="left">
                                    <asp:Literal ID="ltrComment" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnUpdate" Text="Cập nhật" CommandName="Update"
                                        runat="server" />
                                </td>
                                <td align="center">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" Text="Xóa" CommandName="Delete"
                                        runat="server" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')" />
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
                <asp:HiddenField ID="hidId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
