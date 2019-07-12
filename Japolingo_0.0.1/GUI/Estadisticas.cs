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

            stats.GetStatistics(type, score, "1", "8");

            chart1.Series["Semana actual"].Points.AddXY(type[0], score[0]);
            chart1.Series["Semana actual"].Points.AddXY(type[1], score[1]);
            chart1.Series["Semana actual"].Points.AddXY(type[2], score[2]);

            List<string> typePastWeek = new List<string>();
            List<double> scorePastWeek = new List<double>();

            stats.GetStatistics(typePastWeek, scorePastWeek, "-6", "1");

            chart1.Series["Semana pasada"].Points.AddXY(typePastWeek[0], scorePastWeek[0]);
            chart1.Series["Semana pasada"].Points.AddXY(typePastWeek[1], scorePastWeek[1]);
            chart1.Series["Semana pasada"].Points.AddXY(typePastWeek[2], scorePastWeek[2]);
        }
    }
}
