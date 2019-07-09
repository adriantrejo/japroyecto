using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Web.Security;
using System.Data;

namespace Japolingo_0._0._1.Implementaciones
{
    class Register
    {

        public void Registrar(string completeusername, string username, string email,string age,string email2)
        {
            try
            {
                SQLConexion con = new SQLConexion(Launcher.Cadena.CadenaC);
                con.open();
                String[] sqlParams1 = new string[] { username, email };
                DataTable dt = con.select("SELECT * from Usuarios WHERE [Nombre Usuario] =@1 or email=@2", sqlParams1);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Usuario y/o email dado de alta");
                    con.close();
                }
                else if(email!= email2)
                {
                    MessageBox.Show("El campo Correo y Repetir Correo deben ser iguales");
                }
                else
                {
                    String[] sqlParams2 = new String[] { };
                    DataTable dt2 = con.select("SELECT TOP 1 ID_USUARIO FROM Usuarios ORDER BY ID_USUARIO desc ", sqlParams2);
                    string nextId = dt2.Rows[0][0].ToString();
                    nextId = (System.Convert.ToInt32(nextId) + 1).ToString();
                    string password = generatePassword();
                    string level = "0";
                    String[] sqlParams3 = new string[] { nextId, completeusername, username, age, password, email, level};
                    int numberOfRows = con.insert("INSERT INTO Usuarios (Id_usuario, Nombre, [Nombre Usuario],Edad,Password,Email,Nivel) VALUES (@1,@2,@3,@4,@5,@6,@7)", sqlParams3);
                    SendEmail(password, email);
                    MessageBox.Show("Registro Correcto");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
            }
        }
        public string generatePassword()
        {
            try
            {
                return Membership.GeneratePassword(12, 4); ;
            }
            catch(Exception e)
            {
                MessageBox.Show("Ha sucedido un error, por favor contacte con soporte");
                Log olog = new Log(Launcher.Directory.Path + "\\Logs");
                olog.Add(e.ToString());
                return "";
            }
        }
        public void SendEmail(string password, string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("japolingo@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Test Mail";
                mail.Body = "Your security password is " + password;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("japolingo@gmail.com", "testjapolingo");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mensaje Enviado");
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
