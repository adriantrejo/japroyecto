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
                DataTable dt = con.select("Select Nivel from Usuarios where username =@1", sqlParams);
                MessageBox.Show("Su nivel de usuario es " + dt.Rows[0][0].ToString());
                con.close();
            }
            catch (Exception e)
            {
                MessageBox.Show("El error es" + e.ToString());
            }
        }
    }
}
