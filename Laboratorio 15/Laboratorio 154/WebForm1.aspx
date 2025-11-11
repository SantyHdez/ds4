<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio_154.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl1" Text="Introduce 2 numeros" runat="server"></asp:Label>
             <br />
            <asp:textBox ID="txt1" runat="server" OnTextChanged="txt1_TextChanged"></asp:textBox>
            <asp:Button ID="Button1" runat="server" Text="Sumar" Width="101px" OnClick="Sumar_click"/>
        </div>
    </form>
</body>
</html>
