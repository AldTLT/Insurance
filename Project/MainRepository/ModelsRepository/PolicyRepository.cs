﻿using System;
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
    /// <summary>
    /// Класс представляет методы управления PolicyModel.
    /// </summary>
    public class PolicyRepository : IPolicyRepository
    {
        /// <summary>
        /// Контекст подключения к БД.
        /// </summary>
        private readonly DataContext _context;

        public PolicyRepository()
        {
            _context = new DataContext();
        }

        public PolicyRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод возвращает результат добавления нового полиса и привязанного к нему автомобиля в систему.
        /// </summary>
        /// <param name="policy">Insurance.BL.Models.Policy для добавления в систему.</param>
        /// <returns>Номер полиса, если полис успешно добавлен, иначе - null.</returns>
        public string PolicyRegistration(Policy policy)
        {
            //Получение клиента по e-mail.
            var client = _context.Client.FirstOrDefault(c => c.EMail.Equals(policy.UsersEmail));
            var carNumber = policy.Car.CarNumber;
            var policyNumber = string.Empty;

            //Если пользователь с таким e-mail не зарегистрирован, вернуть false.
            if (client == null)
            {
                return null;
            }

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
                return null;
            }

            try
            {
                policyNumber = _context.Policy
                    .Where(c => c.Car.CarNumber.Equals(carNumber))
                    .Select(p => p.PolicyID)
                    .FirstOrDefault()
                    .ToString();
            }
            catch
            {
                return null;
            }

            return policyNumber;
        }

        /// <summary>
        /// Метод возвращает список всех Insurance.BL.Models.Policy по email.
        /// </summary>
        /// <param name="email">Email по которому осуществляется поиск.</param>
        /// <returns>List<Policy> соответствующих email.</returns>
        public ICollection<Policy> GetPolicys(string email)
        {
            List<PolicyModel> policyModelList;

            try
            {
                policyModelList = _context.Policy
                    .Where(p => p.Client.EMail.Equals(email))
                    .Select(p => p)
                    .ToList();
            }
            catch
            {
                return null;
            }

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
        /// Метод возвращает экземпляр Insurance.BL.Models.Policy по номеру автомобиля.
        /// </summary>
        /// <param name="carNumber">Номер автомобиля, по которому производится поиск полиса.</param>
        /// <returns>Insurance.BL.Models.Policy, если номер существует в базе данных, иначе - null.</returns>
        public Policy GetPolicy(string carNumber)
        {
            PolicyModel policyModel;

            try
            {
                policyModel = _context.Policy.FirstOrDefault(p => p.Car.CarNumber.Equals(carNumber));
            }
            catch
            {
                return null;
            }

            var policy = PolicyModelToPolicy(policyModel);

            return policy;
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Policy с данными полученными из PolicyModel.
        /// </summary>
        /// <param name="policyModel">PolicyModel по которому берутся данные.</param>
        /// <returns>Insurance.BL.Models.Policy с данными из PolicyModel.</returns>
        public Policy PolicyModelToPolicy(PolicyModel policyModel)
        {
            if (policyModel == null)
            {
                return null;
            }

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

            var clientEmail = 
                policyModel.Client != null ? 
                    policyModel.Client.EMail : policyModel.ClientEmail != null ? 
                        policyModel.ClientEmail : null;

            var policy = new Policy
                (
                policyModel.policyCost, 
                clientEmail, 
                policyModel.PolicyDate, 
                car,
                ratio
                );

            policy.PolicyId = policyModel.PolicyID;

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
            {
                return null;
            }

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
                policyCost = policy.Cost,
                Client = null,
                ClientEmail = policy.UsersEmail,
                PolicyDate = policy.PolicyDate,
                Car = carModel,
                Ratio = ratioModel
            };

            if (carModel != null)
            {
                carModel.Policy = policyModel;
            }

            if (ratioModel != null)
            {
                ratioModel.Policy = policyModel;
            }

            return policyModel;
        }
    }
}
