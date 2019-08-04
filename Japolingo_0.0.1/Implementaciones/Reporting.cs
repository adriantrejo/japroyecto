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
    class Reporting
    {
        public void SendLog(string path)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("japolingo@gmail.com");
                mail.To.Add("japolingo@gmail.com");
                mail.Subject = "Reporte incidencia ";
                mail.Body = "Reporte enviado por el usuario " + Launcher.Userdata.Nombreusuario;

                Attachment attachment;
                attachment = new System.Net.Mail.Attachment(path);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("japolingo@gmail.com", "testjapolingo");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Reporte enviado");
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
