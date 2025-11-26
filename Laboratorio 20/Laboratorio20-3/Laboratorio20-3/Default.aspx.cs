using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Laboratorio20_3
{
    public partial class _Default : Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ProductosConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarProductos();
        }

        private void CargarProductos()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "SELECT ID, NOMBRE, PRECIO, STOCK FROM LAPTOPS";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvProductos.DataSource = dt;
                gvProductos.DataBind();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductoForm.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscarId.Text.Trim(), out int id))
                Response.Redirect("ProductoForm.aspx?id=" + id);
            else
                lblMensaje.Text = "Ingrese un ID válido.";
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvProductos.DataKeys[index].Value);

            if (e.CommandName == "Editar")
                Response.Redirect("ProductoForm.aspx?id=" + id);

            if (e.CommandName == "Eliminar")
            {
                EliminarProducto(id);
                CargarProductos();
            }
        }

        private void EliminarProducto(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM LAPTOPS WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
