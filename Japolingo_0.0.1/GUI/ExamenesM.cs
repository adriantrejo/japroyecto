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
    public partial class ExamenesM : Form
    {
        public ExamenesM()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void ExamenesM_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new ExamenesG().Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new ExamenesK().Show();
        }
    }
}
