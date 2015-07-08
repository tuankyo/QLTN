<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="OtherFeeImport.aspx.cs" Inherits="Man.MasterImport.OtherFeeImport"
    Title="" %>

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
                                <asp:Label runat="server" ID="lblHeader" Text="Nhập phí khác theo tháng"></asp:Label>
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
                                <td class="Title">
                                    Tháng/Năm
                                </td>
                                <td colspan="7">
                                    <asp:DropDownList ID="drpMonth" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="drpYear" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="Title">File CSV Header<font color="red">※</font></td>
                                <td><font color="red">NAMTHANG,MACC,MACH,TENLOAI,SOLUONG,DONGIA,GHICHU</font></td>
                            </tr>
                            <tr>
                                <td class="Title">Giải thích</td>
                                <td><font color="red">NAMTHANG</font>:Năm Tháng (yyyyMM), <font color="red">MACC</font>:Mã Chung Cư, <font color="red">MACH</font>:Mã Căn Hộ, <font color="red">TENLOAI</font>:Tên Loại Phí Khác,<font color="red">SOLUONG</font>:Số Lượng, <font color="red">DONGIA</font>:Đơn Giá, <font color="red">GHICHU</font>:Ghi Chú</td>
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
