<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_RoomList.aspx.cs" Inherits="Man.Building.Room.BD_RoomList" Title="Danh sách Phòng cho thuê" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upBD_Room" runat="server">
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
                                        <asp:Label ID="ltrPage" Text="Thông tin tòa nhà &gt Phòng cho thuê" runat="server"></asp:Label>
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
                                <!--
                            
                                <div class="title_form">
                                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Sử Dụng"></asp:Label>
                                </div>
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td width="25%" valign="top" class="text_label">
                                            Ngày
                                        </td>
                                        <td class="input_form">
                                            <asp:TextBox ID="txtDateFrom" runat="server" MaxLength="100" Width="40%" AutoPostBack="true"
                                                OnTextChanged="InfoChanged_Click"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="cal" runat="server" Enabled="True" TargetControlID="txtDateFrom"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%" valign="top" class="text_label">
                                            Diện tích toàn Tòa Nhà
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblSumArea" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%" valign="top" class="text_label">
                                            Diện tích đã cho thuê
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblUsedArea" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%" valign="top" class="text_label">
                                            Diện tích còn trống
                                        </td>
                                        <td class="input_form">
                                            <asp:Label ID="lblEmptyArea" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                -->
                                <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                </cc:Pager>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txtID" runat="server" Width="95%" />
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtName" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:CheckBox ID="chkMeetingRoom" runat="server" Width="95%" />
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtRegional" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtFloor" runat="server" Width="95%"></asp:TextBox>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtAreaFrom" runat="server" Width="40%"></asp:TextBox>
                                            <asp:TextBox ID="txtAreaTo" runat="server" Width="40%"></asp:TextBox>
                                        </td>
                                        <td align="center" colspan="3">
                                            <asp:RadioButton ID="rdoActive" Checked="true" runat="server" Text="Hoạt Động" GroupName="DelFlag" />
                                            <asp:RadioButton ID="rdoInActive" runat="server" Text="Ngưng Hoạt Động" GroupName="DelFlag" />
                                            <asp:RadioButton ID="rdoAll" runat="server" Text="Tất Cả" GroupName="DelFlag" />
                                            <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                        OnItemCommand="rptList_ItemCommand">
                                        <HeaderTemplate>
                                            <tr class="row_title">
                                                <td align="center" valign="middle">
                                                    ID
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phòng
                                                </td>
                                                <td align="center" valign="middle">
                                                    Phòng họp
                                                </td>
                                                <td align="center" valign="middle">
                                                    Khu Vực
                                                </td>
                                                <td align="center" valign="middle">
                                                    Lầu
                                                </td>
                                                <td align="center" valign="middle">
                                                    Diện tích
                                                </td>
                                                <td align="center" valign="middle">
                                                    Đang thuê(m2)
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
                                            <tr <asp:Literal ID="resultLine" runat="server"/>>
                                                <td align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkMeetingRoom" runat="server" Enabled="false" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRegional" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRentArea" runat="server"></asp:Literal>
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
                                            <tr <asp:Literal ID="resultLine" runat="server"/>>
                                                <td align="center">
                                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" runat="server"></asp:LinkButton>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkMeetingRoom" runat="server" Enabled="false" />
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRegional" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrFloor" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                                                </td>
                                                <td align="left">
                                                    <asp:Literal ID="ltrRentArea" runat="server"></asp:Literal>
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
                                <br />
                                <asp:Button CssClass="btn_blue" ID="btnGetId" runat="server" Text="Cấp Phát ID" OnClick="btnAutoId_Click"
                                    Width="100px" />
                                <asp:TextBox ID="txtAutoId" Enabled="false" runat="server"></asp:TextBox>
                                <asp:Button CssClass="btn_blue" ID="Button2" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click" />
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
