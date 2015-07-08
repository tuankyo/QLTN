<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="CustomerParking.aspx.cs" Inherits="Man.Customer.CustomerParking"
    Title="Thông Tin Gửi Xe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <div class="content_form">
                <div class="title_form">
                    <asp:Label runat="server" ID="Label1" Text="Số lượng xe Khách Hàng được gửi tối đa"></asp:Label>
                </div>
                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                    style="border-collapse: collapse">
                    <tr>
                        <td width="10%" valign="top" class="text_label">
                            Ôtô
                        </td>
                        <td class="input_form" width="10%">
                            <asp:Label ID="lblCarParkingMount" runat="server" MaxLength="100" Width="95%" />
                        </td>
                        <td width="10%" valign="top" class="text_label">
                            Xe máy
                        </td>
                        <td class="input_form" width="10%">
                            <asp:Label ID="lblMotorParkingMount" runat="server" MaxLength="100" Width="95%" />
                        </td>
                        <td width="10%" valign="top" class="text_label">
                            Xe đạp
                        </td>
                        <td class="input_form" width="10%">
                            <asp:Label ID="lblBycParkingMount" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                    style="border-collapse: collapse">
                    <tr>
                        <td>
                            <div class="title_form">
                                <asp:Label runat="server" ID="Label2" Text="Số xe đang được gửi đến cuối tháng"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="input_form" align="center">
                            <asp:Label runat="server" ID="lblVehicleCount"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td colspan="4">
                        
                            <div class="title_form">
                                <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Gửi Xe"></asp:Label>
                            </div>
                            <asp:MultiValidator ID="mvMessage" runat="server" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Loại Xe<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:DropDownList ID="drpVehicleType" runat="server" MaxLength="100" Width="95%" />
                        </td>
                        <td width="25%" valign="top" class="text_label">
                            Biển số<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtVehicleCode" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Hiệu xe<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtVehicleName" runat="server" MaxLength="100" Width="95%" />
                        </td>
                        <td width="25%" valign="top" class="text_label">
                            Chủ sở hữu<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOwnerName" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Số ĐT<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtOwnerPhone" runat="server" MaxLength="100" Width="95%" />
                        </td>
                        <td width="25%" valign="top" class="text_label">
                            Ghi chú
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="100" Width="95%" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Ngày bắt đầu gửi<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtParkingBegin" runat="server" MaxLength="100" Width="95%" />
                            <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                Enabled="True" TargetControlID="txtParkingBegin" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td width="25%" valign="top" class="text_label">
                            Ngày kết thúc gửi
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtParkingEnd" runat="server" MaxLength="100" Width="95%" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                TargetControlID="txtParkingEnd" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Thêm Mới" runat="server" OnClick="btnRegister_Click"
                                Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                            <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                Style="white-space: nowrap;" Text="Đóng" />
                        </td>
                    </tr>
                </table>
                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                </cc:Pager>
                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist01" border="1">
                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                        OnItemCommand="rptList_ItemCommand">
                        <HeaderTemplate>
                            <tr class="row_title">
                                <td align="center" valign="middle">
                                    Loại xe
                                </td>
                                <td align="center" valign="middle" width="10%">
                                    Biển số
                                </td>
                                <td align="center" valign="middle">
                                    Hiệu xe
                                </td>
                                <td align="center" valign="middle">
                                    Chủ sở hữu
                                </td>
                                <td align="center" valign="middle">
                                    Số ĐT
                                </td>
                                <td align="center" valign="middle">
                                    Ngày bắt đầu gửi
                                </td>
                                <td align="center" valign="middle">
                                    Ngày kết thúc gửi
                                </td>
                                <td align="center" valign="middle">
                                    Ghi chú
                                </td>
                                <td align="center" valign="middle">
                                    Cập nhật
                                </td>
                                <td align="center" valign="middle">
                                    Xóa
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="left">
                                    <asp:DropDownList ID="drpPriceName" runat="server" />
                                </td>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtVehicleCode" runat="server" Width="60px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtVehicleName" runat="server" Width="90px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtOwnerName" runat="server" Width="90px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtOwnerPhone" runat="server" Width="80px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtParkingBegin" runat="server" Width="70px" />
                                    <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="txtParkingBegin" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtParkingEnd" runat="server" Width="70px" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                        TargetControlID="txtParkingEnd" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtComment" runat="server" Width="80px" />
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue_short" ID="btnUpdate" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="Update" runat="server" Text="Cập nhật" />
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                        CommandName="Delete" runat="server" Text="Xóa" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="SelectedList">
                                <td align="left">
                                    <asp:DropDownList ID="drpPriceName" runat="server" />
                                </td>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtVehicleCode" runat="server" Width="60px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtVehicleName" runat="server" Width="90px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtOwnerName" runat="server" Width="90px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtOwnerPhone" runat="server" Width="80px" />
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtParkingBegin" runat="server" Width="70px" />
                                    <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="txtParkingBegin" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtParkingEnd" runat="server" Width="70px" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
                                        TargetControlID="txtParkingEnd" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtComment" runat="server" Width="80px" />
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue_short" ID="btnUpdate" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')"
                                        CommandName="Update" runat="server" Text="Cập nhật" />
                                </td>
                                <td align="left">
                                    <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                        CommandName="Delete" runat="server" Text="Xóa" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
                <div>
                    <asp:HiddenField ID="hidId" runat="server" />
                    <asp:HiddenField ID="hidAction" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
