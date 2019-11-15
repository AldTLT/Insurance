using System.IO;
using System.ServiceModel;

namespace Insurance.WCF
{
    /// <summary>
    /// Интерфейс представляет методы управления файлами.
    /// </summary>
    [ServiceContract]
    public interface IFileService
    {
        /// <summary>
        /// Метод возвращает файл в виде потока.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля.</param>
        /// <param name="email">E-mail пользователя.</param>
        /// <returns>Сгенерированный файл pdf в виде массива байт.</returns>
        [OperationContract]
        byte[]  GetPdfFile(string carNumber, string email);
    }
}
