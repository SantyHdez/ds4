using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio_154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int temp = 0;
        int resultado;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Sumar_click(object sender, EventArgs e)
        {
            if (ViewState["temp"] != null)
                temp = (int)ViewState["temp"];

            if (temp == 0)
            {
                temp = Convert.ToInt32(txt1.Text);
                txt1.Text = "";
                ViewState["temp"] = temp;
            }
            else
            {
                resultado = Convert.ToInt32(txt1.Text) + temp;
                txt1.Text = resultado.ToString();
                ViewState["temp"] = 0;
            }
        }
    
    }
}