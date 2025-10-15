using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            double nota1 = double.Parse(textBox1.Text);
            double nota2 = double.Parse(textBox2.Text);
            double nota3 = double.Parse(textBox3.Text);

            double promedio = (nota1 + nota2 + nota3) / 3;

            textBox4.Text = promedio.ToString("F1");

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
