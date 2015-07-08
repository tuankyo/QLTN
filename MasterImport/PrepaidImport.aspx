<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="PrepaidImport.aspx.cs" Inherits="Man.MasterImport.PrepaidImport" Title="" %>

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
                                <td><font color="red">MACC,MACH,TIEN,LOAI,NGAYNHAN,NGUOINHAN,NGUOIGUI,GHICHU,NAMTHANG</font></td>
                            </tr>
                            <tr>
                                <td class="Title">Giải thích</td>
                                <td><font color="red">MACC</font>:Mã Chung Cư, <font color="red">MACH</font>:Mã Căn Hộ, <font color="red">TIEN</font>:Số Tiền, <font color="red">LOAI</font>:Loại trả trước 1:Quản Lý, 2: Giữ Xe, 4: Phí Khác, <font color="red">NGAYNHAN</font>:Ngày Nhận (yyyyMMdd)
                                <br /><font color="red">NGUOIGUI</font>:Người Gửi, <font color="red">GHICHU</font>: Ghi Chú, <font color="red">NAMTHANG</font>:Năm Tháng Trả Trước (yyyyMM;yyyyMM;yyyyMM;yyyyMM;)</td>
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
