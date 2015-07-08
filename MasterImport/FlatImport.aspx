<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="FlatImport.aspx.cs" Inherits="Man.MasterImport.FlatImport" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <contenttemplate>
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
                                <asp:Label runat="server" ID="lblHeader" Text="Nhập chỉ số sử dụng nước theo tháng"></asp:Label>
                                </td>                            
                            </tr>
                            <tr>
                                <td class="Title">
                                    Chưng Cư
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpTenement" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>            
                            <tr>
                                <td class="Title">File CSV Header<font color="red">※</font></td>
                                <td><font color="red">MACC, MACH, TENCH, CANHO, DIENTHOAI, DIENTICH, SONGUOI, GHICHU, DINHMUCNUOC, NGAYNHAN</font></td>
                            </tr>
                            <tr>
                                <td class="Title">Giải thích</td>
                                <td><font color="red">MACC</font>: Mã Chung Cư, <font color="red">MACH</font>: Mã Căn Hộ, <font color="red">TENCH</font>: Tên Chủ Hộ, 
                                <font color="red">CANHO</font>: Số Căn Hộ, <font color="red">DIENTHOAI</font>: Điện Thoại 
                                <br /> <font color="red">DIENTICH</font>: Diện Tích, <font color="red">SONGUOI</font>: Số Người, <font color="red">GHICHU</font>: Ghi Chú, <font color="red">DINHMUCNUOC</font>: Định Mức Nước, 
                                <br /> <font color="red">NGAYNHAN</font>: Ngày Bàn Giao Nhà (yyyyMMdd)</td>
                            </tr>
                            <tr>
                                <td class="Title">File CSV<font color="red">※</font></td>
                                <td><asp:FileUpload ID="fileUpload" runat="server" Width="300px"/></td>
                            </tr>
                            
                            <tr>
                                <td class="Title"></td>
                                <td>
                                    <asp:Button ID="btnUpload" runat="server" 
                                        onclick="btnUpload_Click" Width="80px" Text="Thực hiện" />
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
        </contenttemplate>
</asp:Content>
