using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.BL
{
    /// <summary>
    /// Класс представляет методы управления файлами.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Метод возвращает MemoryStream со сгенерированным pdf файлом полиса.
        /// </summary>
        /// <param name="user">Экземпляр класса User для данных полиса.</param>
        /// <param name="policy">Экземпляр класса Policy для данных полиса.</param>
        /// <returns>Массив байт со сгенерированным pdf файлом полиса.</returns>
        public byte[] GetPdfStream(User user, Policy policy)
        {
            byte[] fileByteArray;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Position = 0;

                var pdfGenerator = new PdfGenerator();
                pdfGenerator.GeneratePolicy(user, policy, ms);

                ms.Position = 0;
                fileByteArray = ms.ToArray();
            }

            return fileByteArray;
        }
    }
}
