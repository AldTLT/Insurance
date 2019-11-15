using System.ServiceModel;

namespace Insurance.WCF
{
    /// <summary>
    /// Интерфейс представляет методы управления почтовыми сообщениями.
    /// </summary>
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
