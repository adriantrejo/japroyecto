using Japolingo_0._0._1.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Japolingo_0._0._1.GUI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Registrar(textBox1.Text,textBox2.Text,textBox4.Text,textBox5.Text,textBox3.Text);
        }
    }
}
