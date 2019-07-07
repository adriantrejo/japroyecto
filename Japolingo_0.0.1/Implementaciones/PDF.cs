using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Japolingo_0._0._1.GUI;

namespace Japolingo_0._0._1.Implementaciones
{
    class PDF
    {
        public string abrir(string lecc)
        {
            try
            {
                return Launcher.Directory.Path + "\\src\\PDF\\" + lecc + ".pdf";
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return "";
            }
        }
    }
}
