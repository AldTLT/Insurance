using Insurance.BL.Models;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы отправки почтового сообщения.
    /// </summary>
    public class EmailSender
    {
        /// <summary>
        /// Smtp сервер отправки почтового сообщения.
        /// </summary>
        private readonly string smtp = "smtp.mail.ru";

        /// <summary>
        /// Почтовый адрес отправителя.
        /// </summary>
        private readonly string from = "insuranceproduct@mail.ru";

        /// <summary>
        /// Пароль почтового ящика отправителя.
        /// </summary>
        private readonly string password = "Insurance123";

        /// <summary>
        /// Метод отправляет сообщение с вложением на почту.
        /// </summary>
        /// <param name="user">Пользователь с данными для отправки.</param>
        /// <param name="policy">Полис с данными для отправки.</param>
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
        /// Метод отправляет почтовое сообщение.
        /// </summary>
        /// <param name="user">Пользователь с данными для отправки.</param>
        /// <param name="policy">Полис с данными для отправки.</param>
        /// <param name="attachment">Вложение к сообщению.</param>
        private void Send(User user, Policy policy, Attachment attachment)
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient(smtp);

            mail.From = new MailAddress(from);
            mail.To.Add(user.EMail);
            mail.Subject = "Полис КАСКО";
            mail.Body = 
                "Благодарим вас за выбор нашей компании." +
                "\nПожалуйста распечатайте данный полис и обратитесь в наш офис что бы оплатить его.";

            mail.Attachments.Add(attachment);

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential(from, password);
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}
