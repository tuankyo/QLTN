<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true"
    CodeBehind="ListDownload.aspx.cs" Inherits="Man.Download.ListDownload" Title="ダウンロード合計一覧" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="SystemFramework" Namespace="Gnt.Web.UI.WebControls" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:UpdatePanel ID="upListDownload" runat="server">
        <ContentTemplate>
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
                    <td >
                        <table class="Tb100">
                            <tr>
                                <td class="text_label">
                                    月
                                </td>
                                <td style="white-space: nowrap">
                                    <asp:DropDownList ID="drpMonth" runat="server" Width="90px">
                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                
                                <td class="text_label">
                                    タイプ
                                </td>
                                <td style="white-space: nowrap">
                                    <asp:DropDownList ID="drpSiteType" runat="server" Width="120px" AutoPostBack="true"
                                        OnSelectedIndexChanged="drpSiteTypeChanged">
                                        <asp:ListItem Text="全て" Value=""></asp:ListItem>
                                        <asp:ListItem Text="フル" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="うた" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="ビデオ" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="text_label">
                                    サイト名
                                </td>
                                <td style="white-space: nowrap">
                                    <asp:DropDownList ID="drpSite" runat="server" Width="220px">
                                    </asp:DropDownList>
                                </td>
                                <td class="text_label">
                                    課金フラグ
                                </td>
                                <td style="white-space: nowrap">
                                    <asp:DropDownList ID="drpChargeFlag" runat="server" Width="120px">
                                        <asp:ListItem Text="全て" Value=""></asp:ListItem>
                                        <asp:ListItem Text="非課金" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="課金" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="退会削除" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="プレゼント" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="クーポン" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" style="white-space: nowrap;" align="center">
                                    <asp:Button CssClass="btn_blue" ID="btnDisplay" runat="server" Text="表示" OnClick="btnDisplay_Click"  />
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
            <br />
            <asp:MultiValidator ID="mvMessage" runat="server" Align="Center" />
                        <asp:UpdateProgress ID="upList" runat="server">
                <ProgressTemplate>
                    <font color="Red">実行中...</font></ProgressTemplate>
            </asp:UpdateProgress>
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
                    <td >
                        <table width="100%" cellspacing="0" cellpadding="0" class="tablelist" border="1" style="border-collapse: collapse">
                            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound"
                                OnItemCommand="rptList_ItemCommand">
                                <HeaderTemplate>
                                    <tr class="row_title">
                                        <td align="center" valign="middle">
                                            サイト名
                                        </td>
                                        <td class="GridHeader" id="header1" runat="server">
                                            <asp:LinkButton ID="lnkMonth1" runat="server">01</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header2" runat="server">
                                            <asp:LinkButton ID="lnkMonth2" runat="server">02</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header3" runat="server">
                                            <asp:LinkButton ID="lnkMonth3" runat="server">03</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header4" runat="server">
                                            <asp:LinkButton ID="lnkMonth4" runat="server">04</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header5" runat="server">
                                            <asp:LinkButton ID="lnkMonth5" runat="server">05</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header6" runat="server">
                                            <asp:LinkButton ID="lnkMonth6" runat="server">06</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header7" runat="server">
                                            <asp:LinkButton ID="lnkMonth7" runat="server">07</asp:LinkButton>
                                        </td>
                                        <td cliass="GridHeader" id="header8" runat="server">
                                            <asp:LinkButton ID="lnkMonth8" runat="server">08</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header9" runat="server">
                                            <asp:LinkButton ID="lnkMonth9" runat="server">09</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header10" runat="server">
                                            <asp:LinkButton ID="lnkMonth10" runat="server">10</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header11" runat="server">
                                            <asp:LinkButton ID="lnkMonth11" runat="server">11</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header12" runat="server">
                                            <asp:LinkButton ID="lnkMonth12" runat="server">12</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header13" runat="server">
                                            <asp:LinkButton ID="lnkMonth13" runat="server">13</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header14" runat="server">
                                            <asp:LinkButton ID="lnkMonth14" runat="server">14</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header15" runat="server">
                                            <asp:LinkButton ID="lnkMonth15" runat="server">15</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header16" runat="server">
                                            <asp:LinkButton ID="lnkMonth16" runat="server">16</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header17" runat="server">
                                            <asp:LinkButton ID="lnkMonth17" runat="server">17</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header18" runat="server">
                                            <asp:LinkButton ID="lnkMonth18" runat="server">18</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header19" runat="server">
                                            <asp:LinkButton ID="lnkMonth19" runat="server">19</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header20" runat="server">
                                            <asp:LinkButton ID="lnkMonth20" runat="server">20</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header21" runat="server">
                                            <asp:LinkButton ID="lnkMonth21" runat="server">21</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header22" runat="server">
                                            <asp:LinkButton ID="lnkMonth22" runat="server">22</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header23" runat="server">
                                            <asp:LinkButton ID="lnkMonth23" runat="server">23</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header24" runat="server">
                                            <asp:LinkButton ID="lnkMonth24" runat="server">24</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header25" runat="server">
                                            <asp:LinkButton ID="lnkMonth25" runat="server">25</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header26" runat="server">
                                            <asp:LinkButton ID="lnkMonth26" runat="server">26</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header27" runat="server">
                                            <asp:LinkButton ID="lnkMonth27" runat="server">27</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header28" runat="server">
                                            <asp:LinkButton ID="lnkMonth28" runat="server">28</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header29" runat="server">
                                            <asp:LinkButton ID="lnkMonth29" runat="server">29</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header30" runat="server">
                                            <asp:LinkButton ID="lnkMonth30" runat="server">30</asp:LinkButton>
                                        </td>
                                        <td class="GridHeader" id="header31" runat="server">
                                            <asp:LinkButton ID="lnkMonth31" runat="server">31</asp:LinkButton>
                                        </td>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="left">
                                            <asp:Literal ID="ltrSiteId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header1" runat="server">
                                            <asp:Literal ID="ltr1" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header2" runat="server">
                                            <asp:Literal ID="ltr2" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header3" runat="server">
                                            <asp:Literal ID="ltr3" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header4" runat="server">
                                            <asp:Literal ID="ltr4" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header5" runat="server">
                                            <asp:Literal ID="ltr5" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header6" runat="server">
                                            <asp:Literal ID="ltr6" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header7" runat="server">
                                            <asp:Literal ID="ltr7" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header8" runat="server">
                                            <asp:Literal ID="ltr8" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header9" runat="server">
                                            <asp:Literal ID="ltr9" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header10" runat="server">
                                            <asp:Literal ID="ltr10" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header11" runat="server">
                                            <asp:Literal ID="ltr11" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header12" runat="server">
                                            <asp:Literal ID="ltr12" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header13" runat="server">
                                            <asp:Literal ID="ltr13" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header14" runat="server">
                                            <asp:Literal ID="ltr14" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header15" runat="server">
                                            <asp:Literal ID="ltr15" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header16" runat="server">
                                            <asp:Literal ID="ltr16" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header17" runat="server">
                                            <asp:Literal ID="ltr17" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header18" runat="server">
                                            <asp:Literal ID="ltr18" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header19" runat="server">
                                            <asp:Literal ID="ltr19" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header20" runat="server">
                                            <asp:Literal ID="ltr20" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header21" runat="server">
                                            <asp:Literal ID="ltr21" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header22" runat="server">
                                            <asp:Literal ID="ltr22" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header23" runat="server">
                                            <asp:Literal ID="ltr23" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header24" runat="server">
                                            <asp:Literal ID="ltr24" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header25" runat="server">
                                            <asp:Literal ID="ltr25" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header26" runat="server">
                                            <asp:Literal ID="ltr26" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header27" runat="server">
                                            <asp:Literal ID="ltr27" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header28" runat="server">
                                            <asp:Literal ID="ltr28" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header29" runat="server">
                                            <asp:Literal ID="ltr29" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header30" runat="server">
                                            <asp:Literal ID="ltr30" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header31" runat="server">
                                            <asp:Literal ID="ltr31" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <tr>
                                        <td align="left">
                                            <asp:Literal ID="ltrSiteId" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header1" runat="server">
                                            <asp:Literal ID="ltr1" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header2" runat="server">
                                            <asp:Literal ID="ltr2" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header3" runat="server">
                                            <asp:Literal ID="ltr3" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header4" runat="server">
                                            <asp:Literal ID="ltr4" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header5" runat="server">
                                            <asp:Literal ID="ltr5" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header6" runat="server">
                                            <asp:Literal ID="ltr6" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header7" runat="server">
                                            <asp:Literal ID="ltr7" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header8" runat="server">
                                            <asp:Literal ID="ltr8" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header9" runat="server">
                                            <asp:Literal ID="ltr9" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header10" runat="server">
                                            <asp:Literal ID="ltr10" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header11" runat="server">
                                            <asp:Literal ID="ltr11" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header12" runat="server">
                                            <asp:Literal ID="ltr12" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header13" runat="server">
                                            <asp:Literal ID="ltr13" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header14" runat="server">
                                            <asp:Literal ID="ltr14" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header15" runat="server">
                                            <asp:Literal ID="ltr15" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header16" runat="server">
                                            <asp:Literal ID="ltr16" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header17" runat="server">
                                            <asp:Literal ID="ltr17" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header18" runat="server">
                                            <asp:Literal ID="ltr18" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header19" runat="server">
                                            <asp:Literal ID="ltr19" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header20" runat="server">
                                            <asp:Literal ID="ltr20" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header21" runat="server">
                                            <asp:Literal ID="ltr21" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header22" runat="server">
                                            <asp:Literal ID="ltr22" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header23" runat="server">
                                            <asp:Literal ID="ltr23" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header24" runat="server">
                                            <asp:Literal ID="ltr24" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header25" runat="server">
                                            <asp:Literal ID="ltr25" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header26" runat="server">
                                            <asp:Literal ID="ltr26" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header27" runat="server">
                                            <asp:Literal ID="ltr27" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header28" runat="server">
                                            <asp:Literal ID="ltr28" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header29" runat="server">
                                            <asp:Literal ID="ltr29" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header30" runat="server">
                                            <asp:Literal ID="ltr30" runat="server"></asp:Literal>
                                        </td>
                                        <td align="right" id="header31" runat="server">
                                            <asp:Literal ID="ltr31" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </AlternatingItemTemplate>
                                <FooterTemplate>
                                    <tr class="GridFooter">
                                        <td class="GridFooter">
                                            合計
                                        </td>
                                        <td class="GridFooter" id="header1" align="right" runat="server">
                                            <asp:Literal ID="ltrsum1" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header2" align="right" runat="server">
                                            <asp:Literal ID="ltrsum2" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header3" align="right" runat="server">
                                            <asp:Literal ID="ltrsum3" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header4" align="right" runat="server">
                                            <asp:Literal ID="ltrsum4" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header5" align="right" runat="server">
                                            <asp:Literal ID="ltrsum5" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header6" align="right" runat="server">
                                             <asp:Literal ID="ltrsum6" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header7" align="right" runat="server">
                                            <asp:Literal ID="ltrsum7" runat="server"></asp:Literal>
                                        </td>
                                        <td cliass="GridFooter" id="header8" align="right" runat="server">
                                            <asp:Literal ID="ltrsum8" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header9" align="right" runat="server">
                                            <asp:Literal ID="ltrsum9" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header10" align="right" runat="server">
                                            <asp:Literal ID="ltrsum10" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header11" align="right" runat="server">
                                            <asp:Literal ID="ltrsum11" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header12" align="right" runat="server">
                                           <asp:Literal ID="ltrsum12" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header13" align="right" runat="server">
                                            <asp:Literal ID="ltrsum13" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header14" align="right" runat="server">
                                            <asp:Literal ID="ltrsum14" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header15" align="right" runat="server">
                                            <asp:Literal ID="ltrsum15" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header16" align="right" runat="server">
                                            <asp:Literal ID="ltrsum16" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header17" align="right" runat="server">
                                            <asp:Literal ID="ltrsum17" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header18" align="right" runat="server">
                                            <asp:Literal ID="ltrsum18" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header19" align="right" runat="server">
                                           <asp:Literal ID="ltrsum19" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header20" align="right" runat="server">
                                            <asp:Literal ID="ltrsum20" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header21" align="right" runat="server">
                                            <asp:Literal ID="ltrsum21" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header22" align="right" runat="server">
                                            <asp:Literal ID="ltrsum22" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header23" align="right" runat="server">
                                           <asp:Literal ID="ltrsum23" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header24" align="right" runat="server">
                                           <asp:Literal ID="ltrsum24" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header25" align="right" runat="server">
                                           <asp:Literal ID="ltrsum25" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header26" align="right" runat="server">
                                            <asp:Literal ID="ltrsum26" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header27" align="right" runat="server">
                                            <asp:Literal ID="ltrsum27" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header28" align="right" runat="server">
                                            <asp:Literal ID="ltrsum28" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header29" align="right" runat="server">
                                            <asp:Literal ID="ltrsum29" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header30" align="right" runat="server">
                                            <asp:Literal ID="ltrsum30" runat="server"></asp:Literal>
                                        </td>
                                        <td class="GridFooter" id="header31" align="right" runat="server">
                                            <asp:Literal ID="ltrsum31" runat="server" ></asp:Literal>
                                        </td>
                                    </tr>
                                </FooterTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
