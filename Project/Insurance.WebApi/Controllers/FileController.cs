using Insurance.WCF;
using NLog;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;
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

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        FileController()
        {
            _fileService = new FileService();
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Запрос сохранение полиса.
        /// </summary>
        /// <param name="model">Модель данных для генерации и сохранения полиса.</param>
        /// <returns></returns>
        [Authorize]
        [Route("saveFile")]
        [HttpPost]
        public IHttpActionResult SaveFile(PdfRequestDataModel model)
        {
            
            //Логгирование: запрос сохранение полиса.
            _logger.Trace($"Запрос сохранение полиса.");

            var carNumber = model.carNumber;
            var email = model.email;

            var fileByteArray = _fileService.GetPdfFile(carNumber, email);

            if (fileByteArray == null || fileByteArray.Length == 0)
            {
                //Логгирование: ошибка получения файла.
                _logger.Error($"Ошибка, не удалось получить pdf файл.");

                return NotFound();
            }
                                 
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(fileByteArray)
            };

            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            ResponseMessageResult responseMessageResult = ResponseMessage(httpResponseMessage);

            //Логгирование: файл pdf сохранен.
            _logger.Trace($"Файл pdf сохранен.");

            return responseMessageResult;
        }
    }
}
