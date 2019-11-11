using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Insurance.WCF
{
    [ServiceContract]
    public interface IMailService
    {
        /// <summary>
        /// Метод отправляет сообщение с вложением полиса в формате pdf на почту.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля.</param>
        /// <param name="email">E-mail пользователя.</param>
        [OperationContract]
        void SendPdf(string carNumber, string email);
    }
}
