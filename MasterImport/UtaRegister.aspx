<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="UtaRegister.aspx.cs" Inherits="Man.MasterImport.UtaRegister" Title="WID付音源ファイルから[うたテーブル]一括生成" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="updFunc" runat="server">
        <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="TbNoHeader">
                    <tr>
                    <td class="TopLeft">
                        </td>
                        <td class="TopHeader">
                        </td>
                        <td class="TopRight">
                        </td>
                     </tr>
                     <tr>
                        <td class="MiddleLeft"></td>
                         <td class ="MiddleCenter">
                            <asp:MultiValidator ID = "mvFileGetter" runat="server" />
                            <table class="Tb100">
                                <tr>
                                    <th colspan="2">
                                        <asp:Label runat="server" ID="lblHeader" Text="WID付音源ファイルから[うたテーブル]一括生成"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td class="Title" >タイプ<font color="red">※</font></td>
                                    <td>
                                        <asp:DropDownList ID="drpType" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Title">着うたのインプットフォルダ<font color="red">※</font></td>
                                    <td>
                                        <asp:TextBox ID="txtPath" runat="server" Width="300px"></asp:TextBox>
                                        <asp:Button ID="btnSavePath" runat="server" OnClick="btnSavePath_Click" Text="保存" Width="80px" /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Title" >音源タイプ<font color="red">※</font></td>
                                    <td>
                                        <asp:DropDownList ID="drpOngen" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title"></td>
                                    <td align=left>
                                        <table border="0" width="100%" class="Noboder" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnFileGet" runat="server" onclick="btnFileGet_Click" Text="作成開始" 
                                                        Width="80px" />
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
            </div>     
            <div>
                <asp:HiddenField ID = "AutoId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
