<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListMail.aspx.cs" Inherits="Man.Mail.ListMail"
    Title="Mail Nội Bộ" Theme="" StylesheetTheme="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="0"
        style="border-collapse: collapse">
        <tr>
            <td>
                <asp:ImageButton OnClick="btnInbox_Click" ID="ImageButton4" runat="server" Height="20"
                    Width="20" ImageUrl="~/App_Themes/Default/images/Home.png" PostBackUrl="~/default.aspx" />
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Trang Chủ" PostBackUrl="~/default.aspx" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton OnClick="btnInbox_Click" ID="btnInbox" runat="server" Height="15"
                    Width="20" ImageUrl="~/App_Themes/Default/images/MailBox.png" />
                <asp:LinkButton OnClick="btnInbox_Click" ID="lnkInbox" runat="server" Text="Hộp Tin" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton OnClick="btnSent_Click" ID="btnSent" runat="server" Height="15"
                    Width="20" ImageUrl="~/App_Themes/Default/images/Sent.png" />
                <asp:LinkButton OnClick="btnSent_Click" ID="lnkSent" runat="server" Text="Tin Đã Gửi" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton OnClick="btnDraf_Click" ID="btnDraft" runat="server" Height="15"
                    Width="20" ImageUrl="~/App_Themes/Default/images/Draft.png" Visible="false" />
                <asp:LinkButton OnClick="btnDraf_Click" ID="lnkDraft" runat="server" Text="Tin Đang Soạn"
                    Visible="false" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton OnClick="btnTrash_Click" ID="btnTrash" runat="server" Height="15"
                    Width="20" ImageUrl="~/App_Themes/Default/images/Trash.png" Visible="true" />
                <asp:LinkButton OnClick="btnTrash_Click" ID="lnkTrash" runat="server" Text="Thùng Rác"
                    Visible="true" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton OnClick="btnCompose_Click" ID="btnCompose" runat="server" Height="15"
                    Width="20" ImageUrl="~/App_Themes/Default/images/edit48.png" />
                <asp:LinkButton ID="lnkCompose" runat="server" Text="Gửi Tin Mới" OnClick="btnCompose_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Chào:
                <asp:Literal ID="ltrFullName" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Truy Cập" LogoutText="Thoát Khỏi Hệ Thống"
                    LogoutPageUrl="/Default.aspx" LogoutAction="Redirect" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <div id="divCompose" visible="true" runat="server">
        <table>
            <tr>
                <td colspan="2">
                    Soạn mail
                </td>
            </tr>
            <tr>
                <td width="10%">
                    Người nhận:
                    <asp:ImageButton OnClick="btnOpenContactCc_Click" ID="btnOpenContact" runat="server"
                        Height="20" Width="20" ImageUrl="~/App_Themes/Default/images/Contact.png" Visible="true" />
                </td>
                <td>
                    <asp:TextBox TextMode="MultiLine" Rows="1" ID="txtToCC" runat="server" Width="98%"></asp:TextBox>
                    <br />
                    Phân cách nhiều người bằng dấu chấm phẩy ';'.
                </td>
            </tr>
            <tr>
                <td width="10%">
                    Người nhận BCC:
                    <asp:ImageButton OnClick="btnOpenContactBcc_Click" ID="ImageButton1" runat="server"
                        Height="20" Width="20" ImageUrl="~/App_Themes/Default/images/Contact.png" Visible="true" />
                </td>
                <td>
                    <asp:TextBox TextMode="MultiLine" Rows="1" ID="txtToBCC" runat="server" Width="98%"></asp:TextBox>
                    <br />
                    Phân cách nhiều người bằng dấu chấm phẩy ';'. Sử dụng chứ năng này nếu bạn muốn
                    người nhận không biết tin nhắn này được gửi cho ai.
                </td>
            </tr>
            <tr>
                <td>
                    Tiêu đề
                </td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" Width="98%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Độ ưu tiên
                </td>
                <td>
                    <asp:DropDownList ID="drpFlag" runat="server" Height="30px" AutoPostBack="True" OnSelectedIndexChanged="Color_Selection_Change">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <FTB:FreeTextBox ID="txtContent" runat="server" Width="98%" Height="200px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" class="text_label" colspan="2">
                    Đính kèm File(tên file không có dấu Tiếng Việt, khoảng cách)<br />
                    <input type="file" id="File1" name="File1" runat="server" /><br />
                    <input type="file" id="File2" name="File2" runat="server" /><br />
                    <input type="file" id="File3" name="File3" runat="server" /><br />
                    <input type="file" id="File4" name="File4" runat="server" /><br />
                    <input type="file" id="File5" name="File5" runat="server" /><br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" OnClientClick="return validate()" Text="Gửi"
                        OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
        <%--        <asp:Label ID="lbltxt" runat="server" /><br />
        <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="RichtextBoxData">
                    <ItemTemplate>
                        <asp:Literal ID="ltrtxt" runat="server" Text='<%#Bind("RichtextData") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
    </div>
    <div id="divMail" visible="true" runat="server">
        Tin nhắn của tôi
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:ImageButton OnClick="btnSearch_Click" ID="ImageButton3" runat="server" Height="20"
            Width="20" ImageUrl="~/App_Themes/Default/images/Search.png" BorderWidth="0" />
        <cc:Pager ID="pager" CssClass="pager" runat="server" OnPageIndexChanged="pager_PageIndexChanged">
        </cc:Pager>
        <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1"
            style="background-color: white; border-collapse: collapse">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                OnItemCommand="rptList_ItemCommand">
                <HeaderTemplate>
                    <tr class="row_title">
                        <td align="center">
                            <asp:LinkButton CommandName="SortFlag" ID="lnkFlag" runat="server" Text="Độ ưu tiên" />
                        </td>
                        <td align="center">
                            <asp:LinkButton CommandName="SortRead" ID="lnkRead" runat="server" Text="Tình trạng" />
                        </td>
                        <td align="left">
                            <asp:ImageButton OnClick="btnDelete_Click" ID="ImageButton2" runat="server" Height="15"
                                Width="20" ImageUrl="~/App_Themes/Default/images/Trash.png" Visible="true" OnClientClick="javascript:return confirm('Tin nhắn sẽ được xóa?')" />
                            <asp:LinkButton CommandName="SortSubject" ID="lnkSubject" runat="server" Text="Tiêu đề" />
                            /
                            <asp:LinkButton CommandName="SortUserName" ID="lnkUserName" runat="server" Text="Người gửi" />
                        </td>
                        <td align="center">
                            Tin nhắn
                        </td>
                        <td align="center">
                            <asp:LinkButton CommandName="SortCreated" ID="lnkCreated" runat="server" Text="Ngày" />
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: #bfd4ff;">
                        <td align="center" width="10%">
                            <asp:ImageButton ID="btnFlag" runat="server" Height="30" />
                        </td>
                        <td align="center" width="10%">
                            <asp:ImageButton ID="btnStatus" CommandName="ReadMail" runat="server" Height="30"
                                ImageUrl="~/App_Themes/Default/images/budget48.png" />
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="chkDelete" runat="server" />
                            <asp:LinkButton ID="ltrSubject" CommandName="ReadMail" runat="server"></asp:LinkButton><br />
                            <asp:Literal ID="ltrSender" runat="server"></asp:Literal>
                            <asp:HiddenField ID="hidId" runat="server" />
                        </td>
                        <td align="center" width="10%">
                            <asp:ImageButton ID="btnComment" runat="server" Height="30" Width="30" ImageUrl="~/App_Themes/Default/images/Comment.png" />
                        </td>
                        <td align="center" width="15%">
                            <asp:Literal ID="ltrSentDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="SelectedList">
                        <td align="center" width="5%">
                            <asp:ImageButton ID="btnFlag" runat="server" Height="30" />
                        </td>
                        <td align="center">
                            <asp:ImageButton ID="btnStatus" CommandName="ReadMail" runat="server" Height="30"
                                ImageUrl="~/App_Themes/Default/images/budget48.png" />
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="chkDelete" runat="server" />
                            <asp:LinkButton ID="ltrSubject" CommandName="ReadMail" runat="server"></asp:LinkButton><br />
                            <asp:Literal ID="ltrSender" runat="server"></asp:Literal>
                            <asp:HiddenField ID="hidId" runat="server" />
                        </td>
                        <td align="center" width="10%">
                            <asp:ImageButton ID="btnComment" runat="server" Height="30" Width="30" ImageUrl="~/App_Themes/Default/images/Comment.png" />
                        </td>
                        <td align="center" width="15%">
                            <asp:Literal ID="ltrSentDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="header">
    </div>
    <div id="container">
        <div id="center" class="column">
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
                        <td align="center" colspan="2">
                            <asp:Button ID="Button1" runat="server" Text="Trả Lời" OnClick="btnReply_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="left" class="column">
        </div>
        <div id="right" class="column">
        </div>
    </div>
    <div id="footer">
    </div>
    <asp:HiddenField ID="hidReply" runat="server" />
    <asp:HiddenField ID="hidMessageId" runat="server" />
    <asp:HiddenField ID="hidPlaceHolder" runat="server" />
    </form>
</body>
</html>
