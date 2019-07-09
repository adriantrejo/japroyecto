using System;
using System.Configuration;
using System.Windows.Forms;
using Japolingo_0._0._1.GUI;

namespace Japolingo_0._0._1
{

    static class Launcher
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(new LoginForm());
      
    }
        public static class Userdata
        {
            public static string Nombreusuario;
            public static string IdUsuario;
        }
        public static class Cadena
        {
            public static string CadenaC = ConfigurationManager.ConnectionStrings["cadenaC"].ConnectionString;

        }
        public static class Directory
        {
            public static string Path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
        }
    }
}
