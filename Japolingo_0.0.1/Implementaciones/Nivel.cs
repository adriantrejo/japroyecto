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
    class Nivel
    {
        public void NivelSelect(string usuario)
        {
            try
            {
                SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                con.open();
                String[] sqlParams = new string[] { usuario };
                DataTable dt = con.select("Select Nivel from Usuarios where [Nombre Usuario] =@1", sqlParams);
                MessageBox.Show("La lección en la que estás actualmente es la Lección " + dt.Rows[0][0].ToString());
                con.close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                if (MessageBox.Show("¿Quieres enviar un reporte de la incidencia?", "Reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                    Reporting report = new Reporting();
                    report.SendLog(Launcher.Directory.Path + "\\Logs\\" + olog.GetNameFile());
                }
                Application.Exit();

            }
        }
    }
}
