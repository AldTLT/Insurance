﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Insurance.BL.Models;

namespace Insurance.WCF
{
    [ServiceContract]
    public interface IPolicyService
    {
        /// <summary>
        /// Метод возвращает итоговую стоимость полиса, рассчитанную исходя из входных данных.
        /// </summary>
        /// <param name="carCost">Стоимость автомобиля.</param>
        /// <param name="manufacturedYear">Год выпуска автомобиля.</param>
        /// <param name="driverLicenseDate">Дата выдачи прав вождения.</param>
        /// <param name="birthDate">Дата рождения водителя.</param>
        /// <param name="enginePower">Мощность двигателя автомобиля.</param>
        /// <returns>Итоговая стоимость полиса.</returns>
        [OperationContract]
        int PolicyCalculate(int carCost, int manufacturedYear, DateTime driverLicenseDate, DateTime birthDate, int enginePower);

        /// <summary>
        /// Метод возвращает результат регистрации полиса в системе.
        /// </summary>
        /// <param name="carCost">Стоимость автомобиля.</param>
        /// <param name="carNumber">Номер автомобиля.</param>
        /// <param name="carModel">Модель автомобиля.</param>
        /// <param name="manufacturedYear">Год выпуска автомобиля.</param>
        /// <param name="cost">Стоимость автомобиля.</param>
        /// <param name="enginePower">Мощность двигателя автомобиля.</param>
        /// <returns>true, если полис успешно зарегистрирован, иначе - false.</returns>
        [OperationContract]
        bool PolicyRegistration(int carCost, string carNumber, string carModel, int manufacturedYear, int cost, int enginePower);
    }
}
