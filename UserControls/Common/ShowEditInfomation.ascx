<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowEditInfomation.ascx.cs" Inherits="Man.UserControls.Common.ShowEditInfomation" %>
<div style="width:350px">
<table class="NoBorderTable" >
    <tr>
        <td class="text_label">Ngày Đăng Ký</td>
        <td>
                <asp:Label runat="server" Text="" ID="lblRegisterDate" Width="160px"></asp:Label>        
        </td>
        <td class="text_label">Người Đăng Ký</td>
        <td>
                <asp:Label runat="server" Text="" ID="lblRegister" Width="100px"></asp:Label>        
        </td>    
    </tr>

    <tr>
        <td class="text_label">Ngày Thay Đổi</td>
        <td>
                <asp:Label runat="server" Text="" ID="lblEditDate" Width="160px"></asp:Label>        
        </td>
        <td class="text_label">Người Thay Đổi</td>
        <td>
                <asp:Label runat="server" Text="" ID="lblEditer" Width="100px"></asp:Label>        
        </td>
    </tr>
</table>
</div>