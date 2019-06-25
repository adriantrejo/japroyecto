using System;
using System.Collections.Generic;
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
                    this.preguntas.Add(dt.Rows[i][1].ToString());
                    this.respuestas.Add(dt.Rows[i][2].ToString());
                    this.tipo.Add(dt.Rows[i][3].ToString());
                    this.leccion.Add(1.ToString());
                }
                con.close();
            }
            catch (Exception e)
            {
                MessageBox.Show("El error es" + e.ToString());
            }
        }
        public List<string> Randomize(int n, List<string> lista)
        {
            try
            {
                List<string> randomList = new List<string>();
                Random r = new Random();
                int randomIndex = 0;
                int i = 0;
                while (i<n)
                {
                    randomIndex = r.Next(0, lista.Count); //Choose a random object in the list
                    randomList.Add(lista[randomIndex]); //add it to the new, random list
                    lista.RemoveAt(randomIndex); //remove to avoid duplicates
                    i++;
                }

                return randomList; //return the new random list


            }
            catch (Exception e)
            {
                MessageBox.Show("El error es" + e.ToString());
                return new List<string>();
            }
        }
    }
}
