using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.BL;
using Insurance.BL.Models;
using MainRepository.Models;

namespace MainRepository.ModelsRepository
{
    /// <summary>
    /// Класс представляет методы управления RoleModel.
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        /// <summary>
        /// Контекст для подключения к модели EDM.
        /// </summary>
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод возвращает список идентификаторов роли пользователя по e-mail.
        /// </summary>
        /// <param name="email">E-mail для поиска пользователя.</param>
        /// <returns>Список идентификаторов пользователя.</returns>
        public List<string> GetUserRole(string email)
        {
            try
            {
                var roleModel = _context.Client
                    .Where(c => c.EMail.Equals(email))
                    .Select(c => c.Roles)
                    .First();

                return roleModel.Select(r => r.RoleName).ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Метод возвращает результат установки доступа пользователя.
        /// </summary>
        /// <param name="email">E-mail пользователя, роль которого требуется изменить.</param>
        /// <param name="role">Роль пользователя, которую необходимо установить.</param>
        /// <returns>true, если роль успешно установлена, иначе - false.</returns>
        public bool SetUserRole(string email, string role)
        {
            try
            {
                var client = _context.Client.FirstOrDefault(c => c.EMail.Equals(email));
                var roleModel = _context.Role.First(r => r.RoleName.Equals(role));
                client.Roles.Add(roleModel);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Метод возвращает RoleModel с данными полученными из Insurance.BL.Models.Role.
        /// </summary>
        /// <param name="policy">Insurance.BL.Models.Role по которому берутся данные.</param>
        /// <returns>PolicyModel с данными из Insurance.BL.Models.Role.</returns>
        public RoleModel RoleToRoleModel(Role role)
        {
            return new RoleModel() { RoleName = role.RoleName };
        }

        /// <summary>
        /// Метод возвращает Insurance.BL.Models.Role с данными полученными из RoleModel.
        /// </summary>
        /// <param name="policyModel">RoleModel по которому берутся данные.</param>
        /// <returns>Insurance.BL.Models.Role с данными из RoleModel.</returns>
        public Role RoleModelToRole(RoleModel roleModel)
        {
            return new Role ( roleModel.RoleName );
        }

        /// <summary>
        /// Метод возвращает RoleModel по Id.
        /// </summary>
        /// <param name="roleName">Имя роли по которому необходимо найти RoleModel.</param>
        /// <returns>Экземпляр класса RoleModel.</returns>
        public RoleModel GetRoleById(string roleName)
        {
            try
            {
                return _context.Role.Where(r => r.RoleName.Equals(roleName)).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
    }
}
