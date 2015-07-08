<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="ListWaterIndexImport.aspx.cs" Inherits="Man.MasterImport.ListWaterIndexImport" Title="Cập Nhật Chỉ Số Nước Sinh Hoạt" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="SystemFramework" namespace="Gnt.Web.UI.WebControls" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upListSong" runat="server">
        <ContentTemplate>
            <asp:MultiValidator ID="mvldMessage" runat="server" Align="Center"/>
            <div id="importDiv" runat="server" visible=true>
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
                    <td class="MiddleCenter">
                    
                        <cc:Pager ID="pager" runat="server" onpageindexchanged="pager_PageIndexChanged">
                        </cc:Pager>
                        <table class="GridDefault">
                             <asp:Repeater id="rptList" runat="server"
                                   onitemdatabound="rptList_ItemDataBound">
                                   <HeaderTemplate>
                                        <tr class="GridHeader" id="line" runat="server">
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortFlatId" id="lnkSongId" runat="server" Text="Căn Hộ" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortOldIndex" id="lnkArtistId" runat="server" Text="Chỉ Số Cũ" /></th>
                                            <th class="GridHeader"><asp:LinkButton CommandName="SortNewIndex" id="lnkGenreId" runat="server" Text="Chỉ Số Mới" /></th>
	        		                    </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                           <tr <asp:Literal ID="ltrBg" runat="server"></asp:Literal>>
                                                <td align="left"><asp:Literal ID="ltrFlatId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrOldIndex" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrNewIndex" runat="server" ></asp:Literal></td>
	        		                       </tr>
                                  </ItemTemplate>
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
            <div id="divUpdate" runat="server">
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
                   <td class="MiddleLeft"></td>
                   <td class="MiddleCenter">
                       <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnRegister" runat="server" Text="Lưu Dữ Liệu" OnClick="btnRegister_Click"
                                        Width="180px" />
                                </td>
                            </tr>
                       </table>
                   </td>
                   <td class="MiddleRight"></td>
                </tr>
                 <tr>
                       <td class="BottomLeft">
                       </td>
                       <td class="BottomCenter">
                       </td>
                       <td class="BottomRight">
                       </td>
                       <asp:HiddenField id="hidTenementID" runat="server" />
                       <asp:HiddenField id="hidYearmonth" runat="server" />
                 </tr>
            </table> 
            </div>
            </div>
            <asp:HiddenField ID="hidImportType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


