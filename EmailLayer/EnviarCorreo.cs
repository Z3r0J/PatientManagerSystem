using System;
using System.Net;
using System.Net.Mail;

namespace EmailLayer
{
    public class EnviarCorreo
    {

        public void Enviando(string to,string subject,string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("SpGestorPaciente@gmail.com");
                mail.To.Add(to);

                mail.Subject = subject;
                mail.Body = body;

                mail.Priority = MailPriority.Normal;
                mail.IsBodyHtml = true;

                SmtpClient Servidor = new SmtpClient("smtp.gmail.com");

                Servidor.Port = 587;
                Servidor.Credentials = new NetworkCredential("SpGestorPaciente@gmail.com", "Itla123A");
                Servidor.EnableSsl = true;

                Servidor.Send(mail);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
