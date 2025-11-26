using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Laboratorio20_3
{
    public partial class ProductoForm : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ProductosConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    CargarProducto(id);
                }
            }
        }

        private void CargarProducto(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM LAPTOPS WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtId.Text = dr["ID"].ToString();
                    txtNombre.Text = dr["NOMBRE"].ToString();
                    txtPrecio.Text = dr["PRECIO"].ToString();
                    txtStock.Text = dr["STOCK"].ToString();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql;

                if (txtId.Text == "")
                {
                    // INSERTAR
                    sql = "INSERT INTO LAPTOPS (NOMBRE, PRECIO, STOCK) VALUES (@N, @P, @S)";
                }
                else
                {
                    // ACTUALIZAR
                    sql = "UPDATE LAPTOPS SET NOMBRE=@N, PRECIO=@P, STOCK=@S WHERE ID=@ID";
                }

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@N", txtNombre.Text);
                cmd.Parameters.AddWithValue("@P", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@S", int.Parse(txtStock.Text));

                if (txtId.Text != "")
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));

                con.Open();
                cmd.ExecuteNonQuery();

                lblMensaje.Text = "Producto guardado correctamente.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "") return;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM LAPTOPS WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));

                con.Open();
                cmd.ExecuteNonQuery();

                lblMensaje.Text = "Producto eliminado.";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
