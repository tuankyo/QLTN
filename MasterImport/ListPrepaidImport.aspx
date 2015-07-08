<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="ListPrepaidImport.aspx.cs" Inherits="Man.MasterImport.ListPrepaidImport" Title="Cập Nhật Chỉ Số Nước Sinh Hoạt" %>
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
                                            <th class="GridHeader"><asp:LinkButton Text="Căn Hộ" id="lnkSongId" runat="server"/></th>
                                            <th class="GridHeader"><asp:LinkButton Text="Số Tiền" id="lnkArtistId" runat="server" /></th>
                                            <th class="GridHeader"><asp:LinkButton Text="Loại" id="lnkGenreId" runat="server"/></th>
                                            
                                            <th class="GridHeader"><asp:LinkButton Text="Ngày Nhận" id="LinkButton1" runat="server" /></th>
                                            <th class="GridHeader"><asp:LinkButton Text="Người Nhận" id="LinkButton2" runat="server"/></th>
                                            <th class="GridHeader"><asp:LinkButton Text="Người Gửi" id="LinkButton3" runat="server" /></th>
                                            <th class="GridHeader"><asp:LinkButton Text="Ghi Chú" id="LinkButton4" runat="server"/></th>
                                            
                                            <th class="GridHeader"><asp:LinkButton Text="Năm Tháng" id="LinkButton5" runat="server"/></th>
	        		                    </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                           <tr <asp:Literal ID="ltrBg" runat="server"></asp:Literal>>
                                                <td align="left"><asp:Literal ID="ltrFlatId" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrMoney" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrType" runat="server" ></asp:Literal></td>
                                                
                                                <td align="left"><asp:Literal ID="ltrReceiveDate" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrForm" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrReceiver" runat="server" ></asp:Literal></td>
                                                <td align="left"><asp:Literal ID="ltrComment" runat="server" ></asp:Literal></td>
                                                
                                                <td align="left"><asp:Literal ID="ltrYearMonth" runat="server" ></asp:Literal></td>
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
                 </tr>
            </table> 
            </div>
            </div>
            <asp:HiddenField ID="hidImportType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


