<%@ Page Language="C#" MasterPageFile="~/MasterPage/PopUp.Master" AutoEventWireup="true"
    CodeBehind="BD_JobTypeEdit.aspx.cs" Inherits="Man.MasterData.JobType.JobTypeEdit"
    Title="Thông Tin Nhóm Công Việc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPopUp" runat="server">
    <asp:UpdatePanel ID="UpdatePopUp" runat="server">
        <ContentTemplate>
            <table class="TbNoHeader" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="TopLeft">
                    </td>
                    <td class="TopHeader">
                    </td>
                    <td class="TopRight">
                    </td>
                </tr>
                <tr>
                    <td class="MiddleLeft">
                    </td>
                    <td >
                        <table class="Tb100">
                            <tr>
                                <td colspan="4">
                                    <asp:Label runat="server" ID="lblHeader" Text="Thông Tin Nhóm Công Việc"></asp:Label>
                                </td>
                            </tr>
                    </td>
                </tr>
                <div>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            ID
                        </td>
                        <td class="input_form">
                            <asp:TextBox ReadOnly="true" ID="txtId" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" valign="top" class="text_label">
                            Nhóm Công Việc<font color="red">※</font>
                        </td>
                        <td class="input_form">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="100" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Ghi Chú
                        </td>
                        <td >
                            <asp:TextBox ID="txtComment" runat="server" MaxLength="200" Rows="10" TextMode="MultiLine"
                                Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Hoạt động
                        </td>
                        <td >
                            <asp:CheckBox ID="chkDelFlag" Enabled="false" Checked="true" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Thông Tin Thêm Mới
                        </td>
                        <td  class="input_form">
                            <asp:Label ID="lblCreated" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text_label">
                            Thông Tin Cập Nhật
                        </td>
                        <td  class="input_form">
                            <asp:Label ID="lblModified" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </div>
                <tr>
                    <td colspan="2">
                        <asp:MultiValidator ID="mvMessage" runat="server" />
                    </td>
                </tr>
                <tr class="text_label">
                    <td align="center" colspan="4">
                        <table border="0" width="100%" class="Noboder" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button CssClass="btn_blue" ID="btnRegister" runat="server" OnClick="btnRegister_Click" Style="white-space: nowrap;"
                                         OnClientClick="javascript:return confirm('Thông tin sẽ được cập nhật?')" />
                                    <asp:Button CssClass="btn_blue" ID="btnCancel" runat="server" OnClientClick="window.close();return false;"
                                        Style="white-space: nowrap;"  />
                                </td>
                            </tr>
                        </table>
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
            <div>
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hidAction" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
