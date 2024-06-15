using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Admin_MVVM.Model.Data
{
    class ApplicationContext : DbContext
    {
        //Добавление данных в таблицу Users
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext() 
        {
            // если БД нет, то этот метод создаст её
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Строка подключения БД
            optionsBuilder.UseSqlite("Data Source=Admin.db");
        }

    }
}
