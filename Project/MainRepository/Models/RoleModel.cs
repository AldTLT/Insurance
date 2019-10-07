using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainRepository.Models
{
    public class RoleModel
    {
        /// <summary>
        /// Уникальный идентификатор роли.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Наименование роли.
        /// </summary>
        public string RoleName { get; set; }

        public class RoleConfiguration : EntityTypeConfiguration<RoleModel>
        {
            public RoleConfiguration()
            {
                this.ToTable("Role")
                    .HasKey(r => r.RoleId);
                this.Property(r => r.RoleId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                this.Property(r => r.RoleName)
                    .HasMaxLength(30);                
            }
        }
    }
}
