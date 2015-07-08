<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CcContact.aspx.cs" Inherits="Man.Mail.CcContact"
    Title="Mail Nội Bộ" Theme="" StylesheetTheme="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact</title>

    <script language="”javascript”" type="”text/javascript”">

    function SetValueInParent()
    {
        window.opener.document.form1.mytxt.value = document.getElementById('txtToCC').value;
        window.close();
        return false;
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
    <table>
        <tr>
            <td width="10%">
                Contact
            </td>
            <td>
                <asp:TextBox ID="txtContact" runat="server" Width="60%"></asp:TextBox>

            
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtContact"
                    CompletionInterval="1000" CompletionSetCount="20" UseContextKey="true" MinimumPrefixLength="1"
                    ServiceMethod="getAutoList" DelimiterCharacters="; ," ServicePath="~/AutoCompleteExtender.asmx"
                    EnableCaching="true" FirstRowSelected="true">
                </cc1:AutoCompleteExtender>
                
                <asp:Button ID="btnSubmit" runat="server" Text="Lưu" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBoxList ID="chkContactList" runat="server">
                </asp:CheckBoxList>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Chọn" OnClick="btnSelect_Click" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hidType" runat="server" />
    <asp:HiddenField ID="hidUserName" runat="server" />
    </form>
</body>
</html>
