using Insurance.BL;
using Insurance.BL.Intefaces;
using MainRepository;
using MainRepository.ModelsRepository;
using Stub;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервис отправки сообщения на почту.
    /// </summary>
    public class MailService : IMailService
    {
        /// <summary>
        /// Контекст соединения БД.
        /// </summary>
        private readonly DataContext _context = new DataContext();

        /// <summary>
        /// Экземпляр репозитория управления полисом.
        /// </summary>
        private readonly IPolicyRepository _policyRepository;

        /// <summary>
        /// Экземпляр репозитория управления аккаунтом.
        /// </summary>
        private readonly IAuthRepository _authRepository;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public MailService()
        {
            _policyRepository = new PolicyRepository(_context);
            _authRepository = new AuthRepository(_context);

            //_policyRepository = new StubPolicyRepository();
            //_authRepository = new StubAuthRepository();
        }

        /// <summary>
        /// Метод отправляет сообщение с вложением полиса в формате pdf на почту.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля.</param>
        /// <param name="email">E-mail пользователя.</param>
        public void SendPdf(string carNumber, string email)
        {
            var sender = new EmailSender();
            var user = _authRepository.GetUser(email);
            var policy = _policyRepository.GetPolicy(carNumber);
            sender.SendMail(user, policy);
        }
    }
}
