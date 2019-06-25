using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Japolingo_0._0._1.Implementaciones;

namespace Japolingo_0._0._1.GUI
{
    public partial class Lecciones : Form
    {
        public Lecciones()
        {
            InitializeComponent();
            this.CenterToScreen();
            
        }
        private void click(object sender, EventArgs e)
        {
            PDF pd = new PDF();
            var button = (Button)sender;
            string name = pd.abrir(button.Text);
            AcroPDF.src = name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            click(sender, e);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
