<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio20_3._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Productos</title>
</head>
<body>
<form id="form1" runat="server">
    <div style="width:900px;margin:auto;padding:20px;border:1px solid #ddd;border-radius:10px;">

        <h2>Listado de Productos</h2>

        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

        <br /><br />

        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Producto" OnClick="btnNuevo_Click" />

        &nbsp;&nbsp; Buscar por ID:
        <asp:TextBox ID="txtBuscarId" runat="server" Width="80" />
        <asp:Button ID="btnBuscar" runat="server" Text="🔍" OnClick="btnBuscar_Click" />

        <br /><br />

        <asp:GridView ID="gvProductos" runat="server"
                      AutoGenerateColumns="false"
                      DataKeyNames="ID"
                      OnRowCommand="gvProductos_RowCommand"
                      Width="100%" GridLines="None">

            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                <asp:BoundField DataField="PRECIO" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="STOCK" HeaderText="Stock" />

                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server"
                                    Text="Editar"
                                    CommandName="Editar"
                                    CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server"
                                    Text="Eliminar"
                                    CommandName="Eliminar"
                                    CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>
</form>
</body>
</html>
