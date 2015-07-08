﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_Document.aspx.cs" Inherits="Man.Building.Document.BD_Document"
    Title="Danh sách Hồ sơ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdateProgress ID="upList" runat="server">
        <ProgressTemplate>
            <font color="Red">Đang thực hiện yêu cầu...</font>
        </ProgressTemplate>
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
                                <asp:Label ID="ltrPage" runat="server"></asp:Label>
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
                        <table width="100%" cellspacing="0" cellpadding="0" border="1" style="border-collapse: collapse">
                            <tr>
                                <td valign="top" class="text_label">
                                    Nhóm hồ sơ (cấp 1)<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:DropDownList ID="drpParentId" runat="server" Width="85%" AutoPostBack="true"
                                        OnSelectedIndexChanged="drpParentIdSelectedIndexChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Số hồ sơ<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:DropDownList ID="drpDocSubject" runat="server" Width="85%" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Nhóm hồ sơ<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="90%" />(250 ký tự)
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Tên/Nội dung
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtAppeal" runat="server" MaxLength="250" TextMode="MultiLine" Rows="3"
                                        Width="90%" />
                                    (250 ký tự)
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Ngày hồ sơ
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtDocDate" runat="server" Width="30%" />
                                    <ajaxToolkit:CalendarExtender ID="txtContractStartDate_CalendarExtender" runat="server"
                                        Enabled="True" TargetControlID="txtDocDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    &nbsp; Đến ngày(dùng cho tìm kiếm)
                                    <asp:TextBox ID="txtToDocDate" runat="server" Width="30%" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
                                        TargetControlID="txtToDocDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="text_label">
                                    Chọn File<font color="red">※</font>
                                </td>
                                <td class="input_form">
                                    <input type="file" id="File1" name="File1" runat="server" />(tên file không có dấu
                                    Tiếng Việt, khoảng cách)
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" valign="top" class="text_label">
                                    Ghi chú
                                </td>
                                <td class="input_form">
                                    <asp:TextBox ID="txtComment" runat="server" MaxLength="250" TextMode="MultiLine"
                                        Rows="3" Width="95%" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button CssClass="btn_blue" ID="btnRegister" Text="Thêm Mới" runat="server" OnClick="btnRegister_Click"
                                        Style="white-space: nowrap;" OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                                    <asp:Button CssClass="btn_blue" ID="Button1" Text="Tìm" runat="server" OnClick="btnSearch_Click"
                                        Style="white-space: nowrap;" /><font color="red">Tìm theo Tên Hồ Sơ và Nhóm Hồ Sơ</font>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td colspan="2">
                                    <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                                    </cc:Pager>
                                    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
                                        style="border-collapse: collapse">
                                        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                            OnItemCommand="rptList_ItemCommand">
                                            <HeaderTemplate>
                                                <tr class="row_title">
                                                    <td align="center" valign="middle">
                                                        Số hồ sơ
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Ngày hồ sơ
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Nhóm
                                                    </td>
                                                    <td align="center" valign="middle">
                                                        Tên/Nội dung
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
                                                        <asp:LinkButton CommandName="View" ID="btnView" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocSubject" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrAppeal" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnEdit" CommandName="Update" runat="server"
                                                            Text="Cập nhật" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                                            CommandName="Delete" runat="server" Text="Xóa" />
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
                                                        <asp:LinkButton CommandName="View" ID="btnView" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrDocSubject" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrAppeal" runat="server" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal ID="ltrComment" runat="server" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnEdit" CommandName="Update" runat="server"
                                                            Text="Cập nhật" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="btn_blue_short" ID="btnDelete" OnClientClick="javascript:return confirm('Thông tin sẽ được xóa?')"
                                                            CommandName="Delete" runat="server" Text="Xóa" />
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
                                    
                                    <cc:Pager ID="pager1" CssClass="pager" runat="server" OnPageIndexChanged="pager1_PageIndexChanged">
                                    </cc:Pager>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:HiddenField ID="hidId" runat="server" />
                            <asp:HiddenField ID="hidAction" runat="server" />
                            <asp:HiddenField ID="hidDocType" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
