using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainRepository.Models;

namespace MainRepository
{
    public class DataContext : DbContext
    {
        public DataContext() : base(nameOrConnectionString: "InsuranceDbConnection")
        {
            
        }

        public DbSet<ClientModel> Client { get; set; }
        public DbSet<PolicyModel> Policy { get; set; }

        /// <summary>
        /// Перегрузка метода создания модели.
        /// </summary>
        /// <param name="modelBuilder">Модель для конфигурирования.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Добавление конфигурации в модель.
            modelBuilder.Configurations.Add(new ClientModel.ClientConfiguration());
            modelBuilder.Configurations.Add(new PolicyModel.PolicyConfiguration());

            //Создание модели.
            base.OnModelCreating(modelBuilder);
        }
    }
}
