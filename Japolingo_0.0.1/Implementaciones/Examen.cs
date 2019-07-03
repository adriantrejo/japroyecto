using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Japolingo_0._0._1.GUI;

namespace Japolingo_0._0._1.Implementaciones
{
    class Examen
    {
        public List<string> preguntas = new List<string>();
        public List<string> respuestas = new List<string>();
        public List<string> tipo = new List<string>();
        public List<string> leccion = new List<string>();

        public void RellenarListas()
        {
            try
            {
                SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                con.open();
                String[] sqlParams = new string[] { };
                DataTable dt = con.select("Select * from Preguntas", sqlParams);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    preguntas.Add(dt.Rows[i][1].ToString());
                    respuestas.Add(dt.Rows[i][2].ToString());
                    tipo.Add(dt.Rows[i][3].ToString());
                    leccion.Add(1.ToString());
                }
                con.close();
            }
            catch (Exception e)
            {
                MessageBox.Show("El error es" + e.ToString());
            }
        }
        public List<List<string>> Randomize(int n, List<string> listap, List<string> listar)
        {
            try
            {
                List<List<string>> randomList = new List<List<string>>();
                List<string> randompList = new List<string>();
                List<string> randomrList = new List<string>();
                Random r = new Random();
                int randomIndex = 0;
                int i = 0;
                while (i<n)
                {
                    randomIndex = r.Next(0, listap.Count); //Choose a random object in the list
                    randompList.Add(listap[randomIndex]); // añadimos a la lista de preguntas
                    randomrList.Add(listar[randomIndex]); // añadimos a la lista de preguntas
                    listap.RemoveAt(randomIndex); //remove to avoid duplicates
                    listar.RemoveAt(randomIndex); //remove to avoid duplicates
                    i++;
                }
                randomList.Add(randompList);
                randomList.Add(randomrList);
                return randomList; //return the new random list


            }
            catch (Exception e)
            {
                MessageBox.Show("El error es" + e.ToString());
                return new List<List<string>>();
            }
        }
        public List<int> Correctas(List<string> respuestasI, List<string> respuestasC)
        {
            try
            {
                List<int> correctas = new List<int>();
                for (int i = 0; i < respuestasI.Count; i++)
                {
                    if (respuestasI[i] == respuestasC[i])
                    {
                        correctas.Add(i);
                    }
                }
                return correctas;
            }
            catch (Exception e)
            {
                MessageBox.Show("El error es" + e.ToString());
                return new List<int>();
            }
        }
        public void ColorP(TextBox txtb, List<int> correctas, List<string> respuestasC, int i)
        {
            try
            {
                MessageBox.Show("La correcta es " + respuestasC[9 - i]);
                if (correctas.Contains(9 - i))
                {
                    txtb.BackColor = Color.Green;
                }
                else
                {
                    txtb.BackColor = Color.Red;
                    txtb.Text = respuestasC[9 - i];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("La excepción es " + ex);
            }
        }
    }
}
