using System;
using System.Data;
using System.Windows.Forms;
using Japolingo_0._0._1.GUI;

namespace Japolingo_0._0._1.Implementaciones
{
    class Login
    {
        
        public void Logear(string usuario, string password)
        {
            try
            {
                Launcher.Userdata.Nombreusuario = usuario;
                SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                con.open();
                String[] sqlParams = new string[] {usuario, password};
                DataTable dt = con.select("Select Id_Usuario from Usuarios where [Nombre Usuario] =@1 and Password=@2", sqlParams);

                if (dt.Rows.Count > 0)
                {
                    Launcher.Userdata.IdUsuario = dt.Rows[0][0].ToString();
                    con.close();
                    new MainForm().Show();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Usuario y/o contraseña incorrectos");
                    con.close(); 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }
    }
}
