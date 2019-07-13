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
    public partial class ExamenesK : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        public ExamenesK()
        {
            InitializeComponent();
            this.CenterToScreen();
            g = panel1.CreateGraphics();
            panel1.BackColor = Color.White;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 2);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.Color = Color.Black;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = true;
            x = -1;
            y = -1;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x!=-1 && y!=-1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }
    }
}
