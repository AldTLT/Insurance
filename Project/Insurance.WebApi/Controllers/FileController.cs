using Insurance.WCF;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace Insurance.WebApi.Controllers
{
    /// <summary>
    /// Контроллер управления файлами.
    /// </summary>
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        /// <summary>
        /// Сервис управления аккаунтом.
        /// </summary>
        private readonly IFileService _fileService;

        /// <summary>
        /// Экземпляр логгера.
        /// </summary>
        private Logger _logger;

        FileController()
        {
            _fileService = new FileService();
            _logger = LogManager.GetCurrentClassLogger();
        }

        [Authorize]
        [Route("saveFile")]
        [HttpPost]
        public IHttpActionResult SaveFile(PdfRequestDataModel model)
        {
            
            //Логгирование: запрос сохранение полиса.
            _logger.Trace($"Запрос сохранение полиса.");

            //Получение email из headers запроса.
            //            var email = string.Empty;
            //Получение номера автомобиля из headers запроса.
            //           var carNumber = string.Empty;

            var carNumber = model.carNumber;
            var email = model.email;

            //try
            //{
            //    email = Request
            //        .Headers
            //        .FirstOrDefault(c => c.Key.Equals("email"))
            //        .Value
            //        .FirstOrDefault();
            //}
            //catch
            //{
            //    //Логгирование: ошибка получения email.
            //    _logger.Error($"Ошибка, заголовок не содержит email.");

            //    return NotFound();
            //}

            //try
            //{
            //    carNumber = Request
            //        .Headers
            //        .FirstOrDefault(n => n.Key.Equals("carNumber"))
            //        .Value
            //        .FirstOrDefault();
            //}
            //catch
            //{
            //    //Логгирование: ошибка получения номера автомобиля.
            //    _logger.Error($"Ошибка, заголовок не содержит carNumber.");

            //    return NotFound();
            //}

            var fileByteArray = _fileService.GetPdfFile(carNumber, email);

            if (fileByteArray == null || fileByteArray.Length == 0)
            {
                //Логгирование: ошибка получения файла.
                _logger.Error($"Ошибка, не удалось получить pdf файл.");

                return NotFound();
            }

            //Логгирование: ошибка получения файла.
            _logger.Trace($"Файл pdf получен.");

            return Ok(fileByteArray);
        }
    }
}
