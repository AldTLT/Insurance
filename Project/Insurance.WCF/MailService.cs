using Insurance.BL;
using Insurance.BL.Intefaces;
using MainRepository;
using MainRepository.ModelsRepository;

namespace Insurance.WCF
{
    /// <summary>
    /// Класс представляет сервис отправки сообщения на почту.
    /// </summary>
    public class MailService : IMailService
    {
        private readonly DataContext _context = new DataContext();
        private readonly IPolicyRepository _policyRepository;
        private readonly IRatioRepository _ratioRepository;
        private readonly ICarRepository _carRepository;
        private readonly IAuthRepository _authRepository;

        public MailService()
        {
            _policyRepository = new PolicyRepository(_context);
            _ratioRepository = new RatioRepository(_context);
            _carRepository = new CarRepository(_context);
            _authRepository = new AuthRepository(_context);

            //_policyRepository = new StubPolicyRepository();
            //_authRepository = new StubAuthRepository();
            //_ratioRepository = new StubRatioRepository();
            //_carRepository = new StubCarRepository();
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
