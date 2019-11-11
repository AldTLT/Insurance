using Insurance.BL.Models;
using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы отправки сообщения на почту.
    /// </summary>
    public class EmailSender
    {
        public void SendMail(User user, Policy policy)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var pdfGenerator = new PdfGenerator();
                pdfGenerator.GeneratePolicy(user, policy, ms);
                var fileName = policy.PolicyId.ToString() + ".pdf";
                var attachment = new Attachment(ms, fileName);

                Send(user, policy, attachment);
            }
        }

        /// <summary>
        /// Метод отправляет сообщение на почту.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="policy"></param>
        private void Send(User user, Policy policy, Attachment attachment)
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("smtp.mail.ru");

            mail.From = new MailAddress("insuranceproduct@mail.ru");
            mail.To.Add(user.EMail);
            mail.Subject = "Полис КАСКО";
            mail.Body = 
                "Благодарим вас за выбор нашей компании." +
                "\nПожалуйста распечатайте данный полис и обратитесь в наш офис что бы оплатить его.";
            //var fileName = policy.PolicyId.ToString() + ".pdf";

            //var attachment = new Attachment(stream, fileName); // файл (путь)
            mail.Attachments.Add(attachment);

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("insuranceproduct@mail.ru", "Insurance123");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}
