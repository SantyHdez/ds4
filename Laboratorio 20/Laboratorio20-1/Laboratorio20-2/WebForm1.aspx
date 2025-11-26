<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio20_2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Matriz N x N</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Matriz con diagonal inversa</h2>

        Ingrese N:
        <asp:TextBox ID="txtN" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" />

        <br /><br />

        <asp:Table ID="tblMatriz" runat="server" Border="1"></asp:Table>

    </form>
</body>
</html>
