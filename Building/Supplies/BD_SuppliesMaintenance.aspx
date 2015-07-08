<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_SuppliesMaintenance.aspx.cs" Inherits="Man.Building.Supplies.BD_SuppliesMaintenance"
    Title="Vật Tư-Thiết Bị" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Supplies" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">Đang thực hiện yêu cầu...</font></ProgressTemplate>
            </asp:UpdateProgress>
            <div class="row_midpages">
                <div class="width_midpages">
                    <!-- box content main -->
                    <div class="box_contentmain">
                        <!-- end title content main -->
                        <div class="bgtitle_main">
                            <div class="tabs_menu">
                                <ul>
                                    <li class="current"><a href="">
                                        <asp:Label ID="ltrPage" Text="Quản lý hoạt động &gt Vật tư" runat="server"></asp:Label>
                                    </a></li>
                                </ul>
                            </div>
                        </div>
                        <!-- mid content main -->
                        <div class="bgmid_main">
                            <!-- end content form-->
                            <!-- List views form-->
                            <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                            <div class="content_form">
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td valign="top" class="text_label">
                                            Mã
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtId" Enabled="false" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                                        </td>
                                        <td valign="top" class="text_label">
                                            Tên
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Enabled="false" Width="95%"></asp:TextBox>
                                        </td>
                                        <td valign="top" class="text_label">
                                            Nhà cung cấp
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtProductOf" runat="server" MaxLength="100" Width="95%" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td valign="top" class="text_label">
                                            Nhãn hiệu
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtLabel" runat="server" MaxLength="100" Enabled="false" Width="95%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="text_label">
                                            <asp:Label ID="lblModel" runat="server" Text="Model"></asp:Label>
                                            
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtModel" runat="server" MaxLength="100" Enabled="false" Width="95%"></asp:TextBox>
                                        </td>
                                        <td valign="top" class="text_label">
                                            <asp:Label ID="lblDescription" runat="server" Text="Thông số kỹ thuật"></asp:Label>
                                            
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtDescription" runat="server" MaxLength="100" Enabled="false"
                                                Width="95%"></asp:TextBox>
                                        </td>
                                        <td valign="top" class="text_label">
                                            <asp:Label ID="lblRegional" runat="server" Text="Khu vực"></asp:Label>
                                            
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtRegional" runat="server" MaxLength="100" Enabled="false" Width="95%"></asp:TextBox>
                                        </td>
                                        <td class="text_label">
                                            Ghi Chú
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Enabled="false"
                                                Width="95%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="content_form">
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtMaintenanceItem" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtScheduleDate" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtDescriptionSearch" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center" colspan="4">
                                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
                                            <asp:Button CssClass="btn_blue" ID="Button2" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    Bảo trì hạng mục
                                                </td>
                                                <td align="center" valign="middle">
                                                    Ngày kế hoạch
                                                </td>
                                                <td align="center" valign="middle">
                                                    Mô tả
                                                </td>
                                                <td align="center" valign="middle">
                                                    Thực hiện
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
                                                <td align="center">
                                                    <asp:Literal ID="ltrMaintenanceItem" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrScheduleDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnScheduleExec" Text="Bảo trì" runat="server" />
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
                                                    <asp:Literal ID="ltrMaintenanceItem" runat="server" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrScheduleDate" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                                </td>
                                                <td align="center">
                                                    <asp:Button CssClass="btn_blue" ID="btnScheduleExec" Text="Bảo trì" runat="server" />
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
                                <asp:HiddenField ID="hidId" runat="server" />
                                <asp:HiddenField ID="hidSuppliesType" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
