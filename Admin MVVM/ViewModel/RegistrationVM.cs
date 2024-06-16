using Admin_MVVM.Model.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Admin_MVVM.ViewModel
{
    public class RegistrationVM : ViewModelBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RepeatedPassword { get; set; }

        private RelayCommand? _addNewUser;

        //Команда для добавления пользователя
        public RelayCommand AddNewUser
        {
            get
            {
                return _addNewUser ??= new RelayCommand(obj =>
                {
                    Window? window = obj as Window;
                    ResetBlockControls(window);

                    if (IsValidInput(window))
                    {
                        if (Password == RepeatedPassword)
                        {
                            string result = DataUser.CreateUser(Name, Email, Password);
                            MessageBox.Show(result);
                        }
                        else
                        {
                            SetBlockControlColor(window, "InputPassword", Brushes.DarkRed);
                            SetBlockControlColor(window, "InputRepeatedPassword", Brushes.DarkRed);
                            MessageBox.Show("Введенные пароли не совпадают");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некорректные данные, проверьте заполненные поля");
                    }
                });
            }
        }

        //проверка валидности заполняемых полей 
        private bool IsValidInput(Window window)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(Name))
            {
                SetBlockControlColor(window, "InputName", Brushes.DarkRed);
                isValid = false;
            }

            if (string.IsNullOrEmpty(Email) || !Email.Contains("@") || !Email.Contains("."))
            {
                SetBlockControlColor(window, "InputEmail", Brushes.DarkRed);
                isValid = false;
            }

            if (string.IsNullOrEmpty(Password) || Password.Length < 7)
            {
                SetBlockControlColor(window, "InputPassword", Brushes.DarkRed);
                isValid = false;
            }

            if (string.IsNullOrEmpty(RepeatedPassword) || Password != RepeatedPassword || RepeatedPassword.Length < 7)
            {
                SetBlockControlColor(window, "InputRepeatedPassword", Brushes.DarkRed);
                isValid = false;
            }

            return isValid;
        }

        // Сброс цвета полей 
        private void ResetBlockControls(Window window)
        {
            SetBlockControlColor(window, "InputEmail", Brushes.Transparent);
            SetBlockControlColor(window, "InputName", Brushes.Transparent);
            SetBlockControlColor(window, "InputPassword", Brushes.Transparent);
            SetBlockControlColor(window, "InputRepeatedPassword", Brushes.Transparent);
        }

        // Установка определенного цвета для указанного поля
        private void SetBlockControlColor(Window window, string blockName, Brush color)
        {
            Control? block = window.FindName(blockName) as Control;
            if (block != null)
            {
                block.BorderBrush = color;
            }
        }
    }
}
