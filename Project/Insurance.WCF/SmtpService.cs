using Insurance.BL;
using Insurance.BL.Intefaces;
using MainRepository;
using Stub;
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
        private readonly DataContext _context = new DataContext();
        private readonly IPolicyRepository _policyRepository;
        private readonly IRatioRepository _ratioRepository;
        private readonly ICarRepository _carRepository;
        private readonly IAuthRepository _authRepository;

        public SmtpService()
        {
            //_policyRepository = new PolicyRepository(_context);
            //_ratioRepository = new RatioRepository(_context);
            //_carRepository = new CarRepository(_context);
            //_authRepository = new AuthRepository(_context);

            _policyRepository = new StubPolicyRepository();
            _authRepository = new StubAuthRepository();
            _ratioRepository = new StubRatioRepository();
            _carRepository = new StubCarRepository();
        }

        public void SendPdf(string email)
        {
            var sender = new EmailSender();
            var user = _authRepository.GetUser(email);
            var policy = _policyRepository.GetPolicy(email);
            sender.SendMail(user, policy);
        }
    }
}
