using System.Security.Cryptography;
using System.Text;

namespace Insurance.WebApi
{
    /// <summary>
    /// Класс представляет методы хэширования пароля.
    /// </summary>
    public static class HashPassword
    {
        /// <summary>
        /// Метод возвращает хэш пароля.
        /// </summary>
        /// <param name="password">Пароль.</param>
        /// <returns>Хэш пароля.</returns>
        public static string GetHash(this string password)
        {
            var algoritm = HashAlgorithm.Create();
            var byteArray = Encoding.Unicode.GetBytes(password);
            var hashByteArray = algoritm.ComputeHash(byteArray);
            var passwordHash = Encoding.Unicode.GetString(hashByteArray);

            return passwordHash;
        }
    }
}