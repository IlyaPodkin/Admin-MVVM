using Admin_MVVM.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Admin_MVVM.ViewModel
{
    public class RegistrationVM : ViewModelBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RepeatedPassword { get; set; }

        private RelayCommand? _addNewUser;

        //Добавление пользователя и проверки на ввод
        public RelayCommand AddNewUser
        {
            get
            {
                return _addNewUser ?? new RelayCommand(obj =>
                {

                    if (Name != null && Email != null && Password != null && RepeatedPassword != null)
                    {
                        if (!Email.Contains("@") || !Email.Contains(".") || Password.Length < 7 || Name == "")
                        {
                            MessageBox.Show("Некорретные данные, проверьте заполенные поля");
                        }
                        else
                        {
                            if (Password == RepeatedPassword)
                            {
                                string result = "";
                                result = DataUser.CreateUser(Name, Email, Password);
                            }
                            else
                            {
                                MessageBox.Show("Введенные пароли не совпадают");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля");
                    }
                });
            }
        }
    }
}
