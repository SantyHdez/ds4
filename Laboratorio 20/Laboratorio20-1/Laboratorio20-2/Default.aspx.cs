using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio20_2
{
    public partial class WebForm1 : Page
    {
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtN.Text);
            tblMatriz.Rows.Clear();

            for (int i = 0; i < N; i++)
            {
                TableRow fila = new TableRow();

                for (int j = 0; j < N; j++)
                {
                    TableCell celda = new TableCell();
                    celda.Text = (j == (N - 1 - i)) ? "1" : "0";
                    fila.Cells.Add(celda);
                }
                tblMatriz.Rows.Add(fila);
            }
        }
    }
}
