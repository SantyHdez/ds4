<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductoForm.aspx.cs" Inherits="Laboratorio20_3.ProductoForm" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Formulario de Producto</title>
</head>
<body>
<form id="form1" runat="server">
    <div style="width:700px;margin:auto;padding:20px;border:1px solid #ccc;border-radius:10px;">

        <h2>Formulario de Producto</h2>

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

        <br /><br />

        <table style="width:100%;">

            <tr>
                <td style="width:120px;">ID:</td>
                <td>
                    <asp:TextBox ID="txtId" runat="server" ReadOnly="true" Width="100px" />
                </td>
            </tr>

            <tr>
                <td>Nombre:</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="350px" />
                </td>
            </tr>

            <tr>
                <td>Precio:</td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server" Width="100px" />
                </td>
            </tr>

            <tr>
                <td>Stock:</td>
                <td>
                    <asp:TextBox ID="txtStock" runat="server" Width="100px" />
                </td>
            </tr>

        </table>

        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

    </div>
</form>
    <p>
        &nbsp;</p>
</body>
</html>
