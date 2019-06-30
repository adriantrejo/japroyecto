using System;
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
        }
        public static class Cadena
        {
            public static string CadenaC = @"Server = tcp:japolingo.database.windows.net,1433;Initial Catalog = Japolingo; Persist Security Info=False;User ID = Adriantrejo; Password=EE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
        }
    }
}
