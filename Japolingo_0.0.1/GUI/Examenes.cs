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
        List<string> respuestasI = new List<string>();
        List<string> respuestasC = new List<string>();

        public Examenes()
        {
            InitializeComponent();
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.BackColor = Color.Transparent;
            }
            this.CenterToScreen(); //Inicializamos y lo centramos a pantalla

            Examen exam = new Examen(); //Creamos nuevo objeto de la clase examen
            exam.RellenarListas(); //Ejecutamos el constructor

            List<string> preguntas = exam.preguntas;  //Asociamos las preguntas y respuestas correspondientes totales
            List<string> respuestas = exam.respuestas;
            List<List<string>> dupla = new List<List<string>>(); //Creamos una lista de listas
            dupla = exam.Randomize(10, preguntas,respuestas); //Ahora aleatorizamos las preguntas
            preguntas = dupla[0]; //Asignamos las preguntas y respuestas correspondientes
            respuestas = dupla[1];
            respuestasC = respuestas; //Asignamos la variable local a una del formulario

            //Rellenamos los labels de el formulario
            int i = 0;
            var validItems = this.Controls.OfType<Label>().Where(j => !j.Text.Contains("Pregunta"));
            foreach (var lbl in validItems)
            {
                lbl.Text = preguntas[9-i];
                i++;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Examen exam = new Examen();
            string[] resp = { textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text };
            respuestasI.AddRange(resp);
            List<int> correctas = exam.Correctas(respuestasI, respuestasC);
            int score = correctas.Count;
            MessageBox.Show("Tu puntuación del examen es de "+score+"\nA continuación te muestro las respuestas incorrectas y su respuesta");
            //Vemos si está contenido en la lista de correctas entonces pintamos el textbox de verde
            int i = 0;
            foreach (TextBox txtb in this.Controls.OfType<TextBox>())
            {
                exam.ColorP(txtb, correctas, respuestasC,i);
                i++;
            }
        }
    }
}
