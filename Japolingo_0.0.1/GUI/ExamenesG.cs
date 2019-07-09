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
    public partial class ExamenesG : Form
    {
        List<string> respuestasI = new List<string>();
        List<string> respuestasC = new List<string>();
        List<string> listaIds_Contestados = new List<string>();
        TextBox[] myTextBoxes = new TextBox[] { };
        GroupBox[] myGroupBoxes = new GroupBox[] { };
        RadioButton[] myRadioButtons = new RadioButton[] { };
        string usrlvl;
        public ExamenesG()
        {
            InitializeComponent();
            this.CenterToScreen();

            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(657, h);

            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.BackColor = Color.Transparent;
            }
            this.CenterToScreen(); //Inicializamos y lo centramos a pantalla

            Examen exam = new Examen(); //Creamos nuevo objeto de la clase examen
            exam.RellenarListas(); //Ejecutamos el constructor
            usrlvl = exam.usrlvl;
            List<string> preguntas = exam.preguntas;  //Asociamos las preguntas, respuestas e ids correspondientes totales
            List<string> respuestas = exam.respuestas;
            List<string> Ides = exam.Id_preguntas;
            List<List<string>> dupla = new List<List<string>>(); //Creamos una lista de listas

            dupla = exam.Randomize(10, preguntas,respuestas,Ides); //Ahora aleatorizamos las preguntas
            preguntas = dupla[0]; //Asignamos las preguntas y respuestas correspondientes
            respuestas = dupla[1];
            Ides = dupla[2];
            listaIds_Contestados = Ides;
            respuestasC = respuestas; //Asignamos la variable local a una del formulario

            //Asignamos textBox

            myTextBoxes = new TextBox[] { textBox12, textBox11, textBox10, textBox9, textBox8, textBox7, textBox6, textBox5, textBox4, textBox3 };

            //Ocultamos los textbox en caso de que la pregunta sea SI/NO
            int k = 0;
            foreach (TextBox txtb in myTextBoxes)
            {
                if (respuestasC[9-k].Equals("Si") || (respuestasC[9-k].Equals("No")))
                {
                    txtb.Hide();
                }
                k++;
            }
            //Asignamos groupBox
            myGroupBoxes = new GroupBox[] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox9, groupBox10};
            int l = 0;      
            foreach (GroupBox grp in myGroupBoxes)
            {
                if (!respuestasC[l].Equals("Si") && (!respuestasC[l].Equals("No")))
                {
                    grp.Hide();
                }
                l++;
            }


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



            // Asignamos los radiobutton correctos
            myRadioButtons = new RadioButton[] { radioButton1, radioButton2, radioButton4, radioButton3, radioButton6, radioButton5, radioButton8, radioButton7, radioButton10, radioButton9, radioButton12, radioButton11, radioButton14, radioButton13, radioButton16, radioButton15, radioButton18, radioButton17, radioButton20, radioButton19 };
            List<bool> Booleans = exam.GenerateArray(respuestasC);
            int j = 0;
            foreach (RadioButton rb in myRadioButtons)
            {
                exam.CheckBox(rb, Booleans, j);
                j++;
            }
            //Coloreamos los RadioButton
            List<bool> Booleans2 = exam.GenerateArrayColor(respuestasI, respuestasC);
            int k = 0;
            foreach (RadioButton rb in myRadioButtons)
            {
                exam.ColorR(rb, Booleans2, k);
                k++;
            }

            

            //Vemos si está contenido en la lista de correctas entonces pintamos el textbox de verde

            int i = 0;
            foreach (TextBox txtb in myTextBoxes)
            {
                exam.ColorP(txtb, correctas, respuestasC, i);
                i++;
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //Insertamos datos del examen en la BBDD
            exam.InsertarPreguntas(correctas, listaIds_Contestados);
            //Actualizamos nivel en el caso correcto

            
            // the code that you want to measure comes here
            
            exam.ActNivel(score, usrlvl);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            MessageBox.Show("Elapsed is " + elapsedMs);
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Asignación de los textBox de los RadioButton

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = radioButton1.Text.ToString();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = radioButton2.Text.ToString();
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = radioButton4.Text.ToString();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = radioButton3.Text.ToString();
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = radioButton6.Text.ToString();
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = radioButton5.Text.ToString();
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = radioButton8.Text.ToString();
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Text = radioButton7.Text.ToString();
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Text = radioButton10.Text.ToString();
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Text = radioButton9.Text.ToString();
        }
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Text = radioButton12.Text.ToString();
        }
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Text = radioButton11.Text.ToString();
        }
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Text = radioButton14.Text.ToString();
        }
        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Text = radioButton13.Text.ToString();
        }
        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Text = radioButton16.Text.ToString();
        }
        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Text = radioButton15.Text.ToString();
        }
        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            textBox11.Text = radioButton18.Text.ToString();
        }
        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            textBox11.Text = radioButton17.Text.ToString();
        }
        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            textBox12.Text = radioButton20.Text.ToString();
        }
        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            textBox12.Text = radioButton19.Text.ToString();
        }
    }
}
