using Insurance.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервис отправки сообщения на почту.
    /// </summary>
    public class SmtpService : ISmtpService
    {
        public void SendPdf(string email)
        {
            var sender = new EmailSender();
            sender.SendMail("vr0rtex@mail.ru");
        }
    }
}
