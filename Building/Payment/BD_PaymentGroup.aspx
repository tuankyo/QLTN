<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_PaymentGroup.aspx.cs" Inherits="Man.Building.Payment.BD_PaymentGroup"
    Title="Danh mục Thu/Chi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Payment" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Danh mục các loại Thu/Chi" runat="server"></asp:Label>
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
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td colspan="3">
                                            <div class="title_form">
                                                <asp:Label runat="server" ID="lblHeader" Text="Danh Mục Thu/Chi"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">
                                            Danh mục Thu/Chi
                                            <asp:TextBox ID="txtPaymentType" runat="server" Width="30%"></asp:TextBox>
                                            <asp:Button CssClass="btn_blue" ID="Button5" runat="server" Text="Thêm mới" OnClick="btnAddPaymentType_Click"
                                                OnClientClick="javascript:return confirm('Nhóm sẽ được thêm mới?')" />
                                            <asp:Button CssClass="btn_blue" ID="Button6" runat="server" Text="Cập nhật cho"
                                                OnClick="btnUpdatePaymentType_Click" OnClientClick="javascript:return confirm('Nội dung Nhóm sẽ cập nhật cho Nhóm đang chọn?')" />
                                            <asp:DropDownList ID="drpPaymentType" runat="server" Width="30%"/>
                                            <asp:Button CssClass="btn_blue_short" ID="Button7" runat="server" Text="Xóa" OnClick="btnDeletePaymentType_Click"
                                                OnClientClick="javascript:return confirm('Thông tin Nhóm đang chọn sẽ được xóa?')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <div class="title_form">
                                                <asp:Label runat="server" ID="Label2" Text="Phân nhóm Thu/Chi"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">
                                            Nhóm Thu/Chi
                                            <asp:TextBox ID="txtPaymentGroup" runat="server" Width="30%"></asp:TextBox>
                                            <asp:Button CssClass="btn_blue" ID="Button2" runat="server" Text="Thêm mới" OnClick="btnAddGroup_Click"
                                                OnClientClick="javascript:return confirm('Nhóm sẽ được thêm mới?')" />
                                            <asp:Button CssClass="btn_blue" ID="Button4" runat="server" Text="Cập nhật cho"
                                                OnClick="btnUpdateGroup_Click" OnClientClick="javascript:return confirm('Nội dung Nhóm sẽ cập nhật cho Nhóm đang chọn?')" />
                                            <asp:DropDownList ID="drpPaymentGroup" runat="server" Width="30%" AutoPostBack="true"
                                                OnSelectedIndexChanged="btnGroupChange_Click" />
                                            <asp:Button CssClass="btn_blue_short" ID="Button3" runat="server" Text="Xóa" OnClick="btnDeleteGroup_Click"
                                                OnClientClick="javascript:return confirm('Thông tin Nhóm đang chọn sẽ được xóa?')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" width="40%">
                                            Danh sách chưa phân nhóm<br />
                                            <asp:ListBox ID="lstPayment" Width="100%" runat="server" Rows="50" Height="300px"
                                                SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                        <td align="center" width="20%">
                                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text=">" OnClick="btnSetGroup_Click" />
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <asp:Button CssClass="btn_blue" ID="btnAdd" runat="server" Text="<" OnClick="btnRemoveGroup_Click" />
                                        </td>
                                        <td align="left" width="40%">
                                            Danh sách đã phân nhóm<br />
                                            <asp:ListBox ID="lstAddedPayment" Width="100%" runat="server" Rows="50" Height="300px"
                                                SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="hidPaymentType" runat="server" />
                            </div>
                            <!-- end List views form-->
                        </div>
                        <!-- end mid content main -->
                        <!-- bottom content main -->
                        <div class="bgbottom_main">
                        </div>
                        <!-- end bottom content main -->
                    </div>
                    <!-- end box content main -->
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
