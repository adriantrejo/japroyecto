using Japolingo_0._0._1.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Japolingo_0._0._1.GUI
{
    public partial class Kanji : Form
    {
        
        int x = -1;
        int y = -1;
        bool moving = false;
        int idKanji = 1;

        Graphics g;
        Pen pen;
        Bitmap surface;
        Graphics graph;

        public Kanji()
        {
            InitializeComponent();
            this.CenterToScreen();

            panel1.BackColor = Color.White;
            
            pen = new Pen(Color.Black, 3);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.Color = Color.Black;
            surface = new Bitmap(panel1.Width, panel1.Height);
            
            graph = Graphics.FromImage(surface);
            panel1.BackgroundImage = surface;
            panel1.BackgroundImageLayout = ImageLayout.None;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
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
            if (moving && x != -1 && y != -1)
            {
                graph.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                panel1.Invalidate();
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bitmap = surface;
            Implementaciones.Kanji kan = new Implementaciones.Kanji();
            int[,] hashMatrix = kan.HashMap(bitmap);
            //kan.SaveMatrix(kan.Traspose(hashMatrix));
            
            int[,] MatrixSaved = kan.GetMatrix(Launcher.Directory.Path + "\\src\\Kanjis\\"+idKanji+".txt");
            float diference = kan.Distance(kan.Traspose(hashMatrix), MatrixSaved);
            MessageBox.Show("El acierto en el kanji es de un " + (1-diference)*100 + " %");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Kanjis_Click(object sender, EventArgs e)
        {
            ValorK.Text = Kanjis.Text;
            Implementaciones.Kanji ka = new Implementaciones.Kanji();
            List<string> lectures = ka.returnlecture(Kanjis.Text);
            ValorO.Text = lectures[0];
            ValorKu.Text = lectures[1];
            idKanji = int.Parse(lectures[2]);

        }
    }
}
