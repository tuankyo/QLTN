<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BaoCaoCBTT.aspx.cs" Inherits="Forex_BaoCaoCBTT" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Breadcrumbs" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">

    <script type="text/javascript" src="../Resources/javascript/GridViewEvents.js"></script>
    <script type="text/javascript" src="Resources/javascript/Forex/ui.datepicker.js">
       var re = '^[0-9]{4}(((0[13578]|(10|12))(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)(0[1-9]|[1-2][0-9]|30)))$';
       $(function() {
           debugger
           $("#dtTheNhap").blur(function() {
               if ($("#dtTheNhap")[0].value != "" && !$("#dtTheNhap")[0].value.match(re)) {
                   $("#dtTheNhap").focus();
                   $("#dtTheNhapLABEL")[0].innerText = "Date format is wrong.";
               }
               else
                   $("#dtTheNhapLABEL")[0].innerText = "";
           });

           $('#dtTheNhap').datepick({ dateFormat: 'yyyymmdd',
               onSelect: function(selectedDate) {
                   alert("aaaa");
               }
           });

       }); 
    </script>
    <div class="div_wrap">
        <asp:Panel ID="pnlHeadFlt" runat="server" CssClass="headerReport">
            <div style="padding: 0px; cursor: pointer; vertical-align: middle;">
               <%-- <div style="float: left; margin-left: 5px; padding-top: 2px">
                    <asp:Label ID="Label1" runat="server">Lọc dữ liệu</asp:Label>
                </div>--%>
                 <div style="padding: 0px; cursor: pointer; vertical-align: middle;">
                    <table width="50%" style="vertical-align:middle">
                        <tr>
                            <td style="width:80px"><asp:Label ID="Label2" runat="server" Text="Chi Nhánh:"></asp:Label></td>
                            <td colspan="2"><asp:DropDownList ID="ddlChiNhanh" runat="server" Width="170px" AutoPostBack ="true" OnTextChanged=ddlChiNhanh_TextChanged>
                                <%--<asp:ListItem Value="-1">        ALL     </asp:ListItem>--%> 
                            </asp:DropDownList></td>                            
                        </tr>
                         <tr>
                            <td><asp:Label ID="Label4" runat="server" Text="CBTT:"></asp:Label></td>
                            <td colspan="2"><asp:DropDownList ID="ddlNhanVien" runat="server" AutoPostBack ="true" Width="170px"></asp:DropDownList></td>                            
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label1" runat="server" Text="Loại KPI: "></asp:Label></td>
                            <td colspan="2"><asp:DropDownList ID="ddlKPI" runat="server" Width="170px" AutoPostBack ="true"></asp:DropDownList></td>                            
                        </tr>                        
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Ngày"></asp:Label>                                                       
                            </td>
                            <td>
                                <%--<input type="text" id="dtTheNhap" style ="width:120px;background:#ccbbee; font-size:15px"/><label style ="color :red">*</<label> <label id="dtTheNhapLABEL" style="display:inline;color:Red"></label>
                                <asp:TextBox ID="txtTuNgay" runat="server" Width="100px" AutoPostBack = "true"></asp:TextBox>--%>
                                <dx:ASPxDateEdit ID="dtTuNgay" runat="server" 
                                    ondatechanged="dtTuNgay_DateChanged">
                                </dx:ASPxDateEdit>
                                </td>
                            <td>                                                   
                                <%--<asp:TextBox ID="txtDenNgay" runat="server" Width="100px" AutoPostBack = "true" 
                                    ontextchanged="txtDenNgay_TextChanged"></asp:TextBox>--%>
                                <dx:ASPxDateEdit ID="dtDenNgay" runat="server" 
                                    ondatechanged="dtDenNgay_DateChanged">
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <dx:ASPxButton ID="btnBaoCao" runat="server" Text="Xuất Báo Cáo" 
                                    onclick="btnBaoCao_Click">
                                </dx:ASPxButton>
                            </td>
                            
                        </tr>
                        <%--<tr align="center">
                            <td colspan="2">
                                <asp:Button id="Coppy" Text="Sao Chép KPI tháng trước" runat="server" 
                                    Width="160px" onclick="Coppy_Click"  />
                            </td>
                        </tr>--%>
                    </table>
                    
                     <asp:GridView ID="grdKPICBTT" runat="server">
                     </asp:GridView>
                       
                </div>
                               
            </div>
        </asp:Panel>
        
    </div>
   
                  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="showMsg" Runat="Server">
</asp:Content>

