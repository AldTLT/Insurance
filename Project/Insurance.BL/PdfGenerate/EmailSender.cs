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
    public class EmailSender
    {
        public void SendMail(string email)
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("smtp.mail.ru");

            var fileName = GeneratePdfPolicy(email);

            mail.From = new MailAddress("vr0rtex@mail.ru");
            mail.To.Add(email);
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

        private string GeneratePdfPolicy(string email)
        {
            //var generator = new PdfGenerator();
            //var policyManager
            //var policy = PolicyManager

            //var fileName = generator.GeneratePolicy();

            //return fileName;
            return null;
        }
    }
}
