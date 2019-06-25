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
    public partial class Examenes : Form
    {
        public Examenes()
        {
            InitializeComponent();
            this.CenterToScreen();
            Examen exam = new Examen();
            exam.RellenarListas();
            List<string> preguntas = exam.preguntas;
            preguntas = exam.Randomize(10, preguntas);
            label11.Text = preguntas[0];
            label12.Text = preguntas[1];
            label13.Text = preguntas[2];
            label14.Text = preguntas[3];
            label15.Text = preguntas[4];
            label16.Text = preguntas[5];
            label17.Text = preguntas[6];
            label18.Text = preguntas[7];
            label19.Text = preguntas[8];
            label20.Text = preguntas[9];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
    }
}
