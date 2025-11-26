<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio20_1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Tabla de Multiplicar</h2>

    <asp:Label ID="Label1" runat="server" Text="Ingrese un número: "></asp:Label>
    <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>

    <br /><br />

    <asp:Button ID="btnGenerar" runat="server" Text="Generar Tabla" OnClick="btnGenerar_Click" />

    <br /><br />

    <asp:Label ID="lblResultado" runat="server"></asp:Label>

</asp:Content>
