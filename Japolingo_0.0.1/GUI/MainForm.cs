using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Japolingo_0._0._1.Implementaciones;

namespace Japolingo_0._0._1.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Lecciones().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string usuario = Launcher.Userdata.Nombreusuario;
            Nivel lvl = new Nivel();
            lvl.NivelSelect(usuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Examenes().Show();
        }
    }
}
