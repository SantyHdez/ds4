<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio_153.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSaludo" Text="Introduzca un Texto" runat="server"> </asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txtCampo" runat="server"></asp:TextBox>
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
