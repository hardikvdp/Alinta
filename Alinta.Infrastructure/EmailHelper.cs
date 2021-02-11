using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Alinta.Infrastructure
{
    public static class EmailHelper
    {
        public static void SendEmail(string to, string from, string subject, string body)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("yourgmail@gmail.com", from,
                                                    System.Text.Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("yourgmail@gmail.com", "Password");
            client.Port = 587;  // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
