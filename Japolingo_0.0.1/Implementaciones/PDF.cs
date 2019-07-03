using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japolingo_0._0._1.GUI;

namespace Japolingo_0._0._1.Implementaciones
{
    class PDF
    {
        public string abrir(string lecc)
            {
                return Launcher.Directory.Path + "\\src\\PDF\\" + lecc + ".pdf";
            }
    }
}
