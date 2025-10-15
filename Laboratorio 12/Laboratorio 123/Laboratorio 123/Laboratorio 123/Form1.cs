using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSemiperimetro_Click(object sender, EventArgs e)
        {
            double ladoA = double.Parse(textBox1.Text);
            double ladoB = double.Parse(textBox2.Text);
            double ladoC = double.Parse(textBox3.Text);

            double perimetro = ladoA + ladoB + ladoC;
            double semiperimetro = perimetro / 2;
            
            textBox4.Text = semiperimetro.ToString("F1");
        }

        private void btnArea_Click(object sender, EventArgs e)
        {

            double ladoA = double.Parse(textBox1.Text);
            double ladoB = double.Parse(textBox2.Text);
            double area = (ladoA * ladoB) / 2;

            textBox5.Text = area.ToString("F1");

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
