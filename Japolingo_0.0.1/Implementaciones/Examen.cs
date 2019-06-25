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
                    this.preguntas.Add(dt.Rows[i][0].ToString());
                    this.respuestas.Add(dt.Rows[i][1].ToString());
                    this.tipo.Add(dt.Rows[i][2].ToString());
                    this.leccion.Add(1.ToString());
                }
                con.close();
            }
            catch (Exception e)
            {
                MessageBox.Show("El error es" + e.ToString());
            }
        }
        public void Rellenar()
        {
            string labelB = "label";
            int numberLabel = 11;
            for (int i = 0; i < preguntas.Count; i++)
            {
                string conLabel = labelB + numberLabel.ToString();
                conLabel.Text = preguntas[i];
                numberLabel += 1;
            }
        }
    }
}
