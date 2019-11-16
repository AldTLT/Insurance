using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebApi.Models
{
    // Модели, используемые в качестве параметров действий контроллеров.
    
    /// <summary>
    /// Модель данных для запроса сохранения полиса.
    /// </summary>
    public class PdfRequestDataModel
    {
        [Required]
        [Display(Name = "Номер автомобиля")]
        public string carNumber { get; set; }

        [Required]
        [Display(Name = "e-mail")]
        public string email { get; set; }
    }

    /// <summary>
    /// Класс представляет модель данных для смены пароля.
    /// </summary>
    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение нового пароля")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// Класс представляет модель данных для регистрации нового пользователя.
    /// </summary>
    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Полное имя")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Год рождения")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата выдачи водительских прав")]
        public DateTime DriverLicenseDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Класс представляет свойства для регистрации нового полиса.
    /// </summary>
    public class PolicyRegistrationBindingModel
    {
        [Required]
        [Display(Name = "Номер гос. регистрации автомобиля")]
        public string CarNumber { get; set; }

        [Required]
        [Display(Name = "Модель автомобиля")]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Год выпуска автомобиля")]
        public int ManufacturedYear { get; set; }

        [Required]
        [Display(Name = "Мощность двигателя автомобиля в лошадиных силах")]
        public int EnginePower { get; set; }

        [Required]
        [Display(Name = "Стоимость автомобиля")]
        public int CarCost { get; set; }
    }
}
