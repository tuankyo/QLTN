<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailComment.aspx.cs" Inherits="Man.Mail.MailComment"
    Title="Mail Nội Bộ" Theme="" StylesheetTheme="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Richtextbox Sample</title>
    <style>
        #center
        {
            width: 100%;
        }
        #left
        {
            width: 200px; /* LC width */
            right: 200px; /* LC width */
            margin-left: -100%;
        }
        #right
        {
            width: 150px; /* RC width */
            margin-right: -150px; /* RC width */
        }
        #footer
        {
            clear: both;
        }
        /*** IE6 Fix ***/* html #left
        {
            left: 150px; /* RC width */
        }
    </style>

    <script language="javascript" type="text/javascript" src="/js/common.js"></script>

    <script language="javascript" type="text/javascript" src="/js/tooltip.js"></script>

    <script type="text/javascript">


        // Get a PageRequestManager reference.
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        // Hook the _initializeRequest event and add our own handler.
        prm.add_pageLoading(CreateIFrame);
        function CreateIFrame(sender, args) {
            // Check to be sure this async postback is actually 
            //   requesting the file download.
            if (sender._postBackSettings.sourceElement.id.indexOf("btnDownloadCsv") != -1 ||
                sender._postBackSettings.sourceElement.id.indexOf("btnGetTempOpenDB") != -1) {
                // Create an IFRAME.
                var iframe = document.createElement("iframe");
                iframe.src = "../CSV/DownloadCsv.aspx";
                // This makes the IFRAME invisible to the user.
                iframe.style.display = "none";
                // Add the IFRAME to the page.  This will trigger
                //   a request to GenerateFile now.
                document.body.appendChild(iframe);
            }
        }

        function validate() {
            var doc = document.getElementById('txtContent');
            if (doc.value.length == 0) {
                alert('Hãy nhập Nội dung mail cần gửi');
                return false;
            }
        }

        function GetValueFromChild(myVal) {
            document.getElementById('txtToCC').value = myVal;
        }
    </script>

    <script type="text/javascript" language="javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $('#drpFlag option').each(function() {
                $(this).html("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + $(this).text());
            });
        });
    </script>

</head>
<body bgcolor="#5fc7fe">
    <form id="form1" runat="server">
    <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
    <div id="divReadMail" visible="true" runat="server">
        <table width="100%" cellspacing="0" cellpadding="0" border="1" style="border-collapse: collapse">
            <tr>
                <td width="10%">
                    Người gửi:
                </td>
                <td>
                    <asp:Label ID="lblSender" runat="server" Width="98%" />
                </td>
            </tr>
            <tr>
                <td width="10%">
                    Người nhận:
                </td>
                <td>
                    <asp:Label ID="lblCC" runat="server" Width="98%" />
                </td>
            </tr>
            <tr>
                <td>
                    Tiêu đề
                </td>
                <td>
                    <asp:Label ID="lblSubject" runat="server" />
                </td>
            </tr>
            <tr style="background-color: white;">
                <td colspan="2">
                    <asp:Literal ID="ltrBody" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    File đính kèm
                </td>
                <td>
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse">
                        <asp:Repeater ID="rptAttach" runat="server" OnItemDataBound="rptAttach_ItemDataBound"
                            OnItemCommand="rptAttach_ItemCommand">
                            <ItemTemplate>
                                <asp:ImageButton CommandName="GetFile" ID="btnFile" runat="server" Height="20" ImageUrl="~/App_Themes/Default/images/Attach.png" />
                                <asp:LinkButton CommandName="GetFile" ID="lnkFile" OnCommand="btnFile_Click" runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Gửi file
                </td>
                <td>
                    <input type="file" id="File" name="File" runat="server" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Gửi"
                        OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divMail" visible="true" runat="server">
        <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
        </cc:Pager>
        <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
            style="border-collapse: collapse">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                OnItemCommand="rptList_ItemCommand">
                <ItemTemplate>
                    <tr style="background-color: #bfd4ff">
                        <td align="left">
                            <asp:Literal ID="ltrSender" runat="server"></asp:Literal>
                            (<asp:Literal ID="ltrSentDate" runat="server"></asp:Literal>)
                            <br />
                            <asp:Literal ID="ltrBody" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color: #6dc066">
                        <td align="left">
                            <asp:Literal ID="ltrSender" runat="server"></asp:Literal>
                            (<asp:Literal ID="ltrSentDate" runat="server"></asp:Literal>)
                            <br />
                            <asp:Literal ID="ltrBody" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="divComment" runat="server">
        <table width="100%" cellspacing="0" cellpadding="0" border="1" style="border-collapse: collapse">
            <tr>
                <td align="center">
                    <asp:TextBox TextMode="MultiLine" ID="txtBody" runat="server" Rows="4" Width="98%"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Trả Lời" OnClick="btnComment_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hidMessageId" runat="server" />
    </form>
</body>
</html>
