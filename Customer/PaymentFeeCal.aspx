<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="PaymentFeeCal.aspx.cs" Inherits="Man.Customer.PaymentFeeCal" Title="Thực hiện quyết sổ tháng" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upRentContract" runat="server">
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
                                        <asp:Label ID="Label3" Text="Thực hiện quyết sổ tháng" runat="server"></asp:Label>
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
                                <div class="title_form">
                                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Khách Hàng"></asp:Label>
                                </div>
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td class="text_label">
                                            Hóa đơn tháng/năm
                                        </td>
                                        <td class="input_form" colspan="3">
                                            <asp:DropDownList ID="drpMonth" runat="server">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="drpYear" runat="server">
                                            </asp:DropDownList>
                                            <asp:Button ID="Button6" runat="server" CssClass="btn_blue" Text="Quyết sổ" OnClick="btnSave_Click" />
                                        </td>
                                    </tr>
                            </div>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
