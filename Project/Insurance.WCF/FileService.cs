using Insurance.BL;
using MainRepository;
using Stub;
using System.IO;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервис управления файлами.
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Экземпляр репозитория управления аккаунтом.
        /// </summary>
        private readonly IAuthRepository _authRepository;

        /// <summary>
        /// Экземпляр репозитория управления полисом.
        /// </summary>
        private readonly IPolicyRepository _policyRepository;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public FileService()
        {
            _authRepository = new AuthRepository();
            _policyRepository = new PolicyRepository();
        }

        /// <summary>
        /// Метод возвращает файл в виде потока.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля.</param>
        /// <param name="email">E-mail пользователя.</param>
        /// <returns>Сгенерированный файл pdf в виде массива байт.</returns>
        public byte[] GetPdfFile(string carNumber, string email)
        {
            var user = _authRepository.GetUser(email);
            var policy = _policyRepository.GetPolicy(carNumber);

            var fileManager = new FileManager();
            return fileManager.GetPdfByByteArray(user, policy);
        }
    }
}
