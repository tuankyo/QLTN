<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ImportFinish.aspx.cs" Inherits="Man.MasterImport.ImportFinish" Title="一括登録完了" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    
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
                            <asp:MultiValidator ID = "mvFileGetter" runat="server" />
                            <table class="Tb100">
                                <tr>
                                    <th colspan="2">
                                        <asp:Label runat="server" ID="lblHeader" Text="一括登録完了しました。<br/>楽曲登録管理メニューから詳細情報を編集したら、仮本番DBに同期してください。"></asp:Label>
                                    </th>
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
</asp:Content>
