using Insurance.BL.Models;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Метод отправляет сообщение на почту.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="policy"></param>
        public void SendMail(User user, Policy policy)
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("smtp.mail.ru");

            var fileName = GeneratePdfPolicy(user, policy);

            mail.From = new MailAddress("vr0rtex@mail.ru");
            mail.To.Add(user.EMail);
            mail.Subject = "Полис КАСКО";
            mail.Body = 
                "Благодарим вас за выбор нашей компании." +
                "\nПожалуйста распечатайте данный полис и обратитесь в наш офис что бы оплатить его.";

            var attachment = new Attachment(fileName); // файл (путь)
            mail.Attachments.Add(attachment);

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("vr0rtex@mail.ru", "H3y1d3r3a7lisk");
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }

        private string GeneratePdfPolicy(User user, Policy policy)
        {
            var generator = new PdfGenerator();
            var fileName = generator.GeneratePolicy(user, policy);

            return fileName;
        }
    }
}
