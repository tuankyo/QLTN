﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="RbtImport.aspx.cs" Inherits="Man.MasterImport.RbtImport" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
        <ContentTemplate>
            <div>
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
                            <asp:MultiValidator ID = "mvImportMaster" runat="server" />
                            <table class="Tb100">
                            <tr>
                            <th colspan="4">
                            <asp:Label runat="server" ID="lblHeader" Text="マスタ情報一括登録"></asp:Label>
                            </td>
                            </tr>             
                                <tr>
                                    <td class="Title">CSVファイル<font color="red">※</font></td>
                                    <td><asp:FileUpload ID="fileUpload" runat="server" Width="300px"/></td>
                                </tr>                                
                                <tr>
                                    <td class="Title"></td>
                                    <td>
                                        <asp:Button ID="btnUpload" runat="server" 
                                            onclick="btnUpload_Click" Width="80px" Text="取込" />
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
        </ContentTemplate>
</asp:Content>