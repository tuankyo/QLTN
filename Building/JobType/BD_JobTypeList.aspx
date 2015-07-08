<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="BD_JobTypeList.aspx.cs" Inherits="Man.MasterData.JobType.JobTypeList"
    Title="Danh Sách Nhóm Công Việc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upJobType" runat="server">
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
                    <td >
                        <cc:Pager ID="pager" CssClass="pager"  runat="server" OnPageIndexChanged="pager_PageIndexChanged">
                        </cc:Pager>
                        <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1" style="border-collapse: collapse">
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                OnItemCommand="rptList_ItemCommand">
                                <HeaderTemplate>
                                    <tr class="row_title">
                                        <td align="center" valign="middle">
                                            ID
                                        </td>
                                        <td align="center" valign="middle">
                                            Nhóm công việc
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
                    <td >
                        <table class="Tb100" border="1" bordercolor="#c0c0c0" algin="right">
                            <tr>
                                <td class="input_form">
                                    <asp:Button CssClass="btn_blue" ID="Button2" runat="server" Text="Thêm Mới" OnClick="btnAdd_Click"  />
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
