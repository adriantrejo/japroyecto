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
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
            this.CenterToScreen();
            Estadistica stats = new Estadistica();
            List<string> type = new List<string> ();
            List<double> score = new List<double>();
            stats.GetStatistics(type, score);
            chart1.Series["Puntuación"].Points.AddXY(type[0], score[0]);
            chart1.Series["Puntuación"].Points.AddXY(type[1], score[1]);
            chart1.Series["Puntuación"].Points.AddXY(type[2], score[2]);
        }
    }
}
