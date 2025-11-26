using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio20_1
{
    public partial class _Default : Page
    {
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtNumero.Text);
            string tabla = "";

            for(int i = 1; i<=25; i++)
            {
                tabla += $"{n} x {i} = {n * i}<br/>";
            }

            lblResultado.Text = tabla;
        }
    }
}