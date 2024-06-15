using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Admin_MVVM.Model.Data
{
    public static class DataUser
    {
        //Вывод всех пользователей
        public static List<User> GetAllUsers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }

        }
        //Добавление пользователя
        public static string CreateUser(string name, string email, string password)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверка на наличие такого же пользователя
                bool IsCheckExist = db.Users.Any(u => u.Name == name && u.Email == email && u.Password == password);
                if (!IsCheckExist)
                {
                    Guid id = Guid.NewGuid();
                    User user = new User(id, name, email, password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    result = "Добавлено";
                    MessageBox.Show("Пользователь: " + name + ", зарегистрирован");
                }
                else
                {
                    MessageBox.Show("Пользователь: " + name + ", уже зарегистрирован. Введите другие учетные данные.");
                }

                return result;
            }
        }
        //Удаление пользователя 
        public static string DeleteUser(User user)
        {
            string result = "Такого пользователя не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
                result = "Учетная запись удалена";

            }
            return result;
        }
    }
}
