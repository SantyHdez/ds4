using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Laboratorio_131
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string connectionString = @"Server=.;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";

            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

            string query = "SELECT ProductName FROM [dbo].[Products]";

            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            listBox1.Items.Clear();

            while (lector.Read())
            {
                listBox1.Items.Add(lector["ProductName"].ToString());
            }

            lector.Close();

            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
