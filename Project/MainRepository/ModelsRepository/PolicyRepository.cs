using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL;
using Insurance.BL.Models;
using MainRepository.Models;
using MainRepository.ModelsRepository;

namespace MainRepository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly DataContext _context;

        public PolicyRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод возвращает результат добавления нового полиса и привязанного к нему автомобиля в систему.
        /// </summary>
        /// <param name="policy">Insurance.BL.Models.Policy для добавления в систему.</param>
        /// <returns>true, если полис успешно добавлен, иначе - false.</returns>
        public bool PolicyRegistration(Policy policy)
        {
            //Получение клиента по e-mail.
            var client = _context.Client
                .Where(c => c.EMail.Equals(policy.UsersEmail))
                .FirstOrDefault();

            //Если пользователь с таким e-mail не зарегистрирован, вернуть false.
            if (client == null)
                return false;

            //Создание PolicyModel из Policy.
            var policyModel = PolicyToPolicyModel(policy);
            policyModel.Client = client;

            try
            {
                _context.Policy.Add(policyModel);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Метод возвращает список всех Insurance.BL.Models.Policy по email.
        /// </summary>
        /// <param name="email">Email по которому осуществляется поиск.</param>
        /// <returns>List<Policy> соответствующих email.</returns>
        public ICollection<Policy> GetPolicy(string email)
        {
            var policyModelList = _context.Policy
                .Where(p => p.Client.EMail.Equals(email))
                .Select(p => p)
                .ToList();

            var policysList = new List<Policy>();

            foreach (var policyModel in policyModelList)
            {
                var policy = PolicyModelToPolicy(policyModel);

                if (policy == null)
                    continue;

                policysList.Add(policy);
            }

            return policysList;
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Policy с данными полученными из PolicyModel.
        /// </summary>
        /// <param name="policyModel">PolicyModel по которому берутся данные.</param>
        /// <returns>Insurance.BL.Models.Policy с данными из PolicyModel.</returns>
        public Policy PolicyModelToPolicy(PolicyModel policyModel)
        {
            if (policyModel == null)
                return null;
            Car car = null;
            Ratio ratio = null;

            if (policyModel.Car != null)
            {
                var carRepository = new CarRepository(_context);
                car = carRepository.CarModelToCar(policyModel.Car);
            }

            if (policyModel.Ratio != null)
            {
                var ratioRepository = new RatioRepository(_context);
                ratio = ratioRepository.RatioModelToRatio(policyModel.Ratio);
            }

            var clientEmail = policyModel.Client != null ? policyModel.Client.EMail : policyModel.ClientEmail != null ? policyModel.ClientEmail : null;

            var policy = new Policy
                (
                policyModel.Cost, 
                clientEmail, 
                policyModel.PolicyDate, 
                car,
                ratio
                );

            return policy;
        }

        /// <summary>
        /// Метод возвращает PolicyModel с данными полученными из Insurance.BL.Models.Policy.
        /// </summary>
        /// <param name="policy">Insurance.BL.Models.Policy по которому берутся данные.</param>
        /// <returns>PolicyModel с данными из Insurance.BL.Models.Policy. Свойство Client = null.</returns>
        public PolicyModel PolicyToPolicyModel(Policy policy)
        {
            if (policy == null)
                return null;

            CarModel carModel = null;
            RatioModel ratioModel = null;

            if (policy.Car != null)
            {
                var carRepository = new CarRepository(_context);
                carModel = carRepository.CarToCarModel(policy.Car);
            }

            if (policy.Ratio != null)
            {
                var ratioRepository = new RatioRepository(_context);
                ratioModel = ratioRepository.RatioToRatioModel(policy.Ratio);
            }

            var policyModel = new PolicyModel()
            {
                Cost = policy.Cost,
                Client = null,
                ClientEmail = policy.UsersEmail,
                PolicyDate = policy.PolicyDate,
                Car = carModel,
                Ratio = ratioModel
            };

            if (carModel != null)
                carModel.Policy = policyModel;

            if (ratioModel != null)
                ratioModel.Policy = policyModel;

            return policyModel;
        }
    }
}
