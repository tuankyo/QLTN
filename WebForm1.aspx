<%@ Page Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Man.WebForm1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:TextBox runat="server">
    </asp:TextBox>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPhd" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button CssClass="btn_blue" ID="Button1" runat="server" Text="Button" 
    onclick="Button1_Click"  />
    
</asp:Content>
