using Admin_MVVM.Model.Data;
using Admin_MVVM.View;
using Admin_MVVM.ViewModel.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace Admin_MVVM.ViewModel
{
    public class AuthorizationVM : ViewModelBase
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        private RelayCommand? _getToTheHomeWindow;
        private RelayCommand? _getToTheRegistration;
        private RelayCommand? _getToTheUsersWindow;

        //Команда открытия окна главной страницы
        public RelayCommand GetToTheHomeWindow
        {
            get
            {
                return _getToTheHomeWindow ??= new RelayCommand(obj =>
                {

                    if (obj is Window window)
                    {
                        ResetBlockControls(window);

                        if (IsValidInput(window))
                        {
                            MessageBox.Show("Вход в учетную запись выполнен!");
                            OpenHomeWindow();
                            window.Close();
                        }
                        else
                        {
                            MessageBox.Show("Введены некорректные данные");
                        }
                    }
                }
                );
            }
        }

        //Команда открытия окна списка пользователей
        public RelayCommand GetToTheUsersWindow
        {
            get
            {
                return _getToTheUsersWindow ??= new RelayCommand(obj =>
                {
                    if (obj is Window window)
                    {
                        OpenShowUsers();
                        window.Close();
                    }
                }
                );
            }
        }

        //Команда открытия окна Регистрации
        public RelayCommand GetToTheRegistration
        {
            get
            {
                return _getToTheRegistration ??= new RelayCommand(obj =>
                {
                    if (obj is Window window)
                    {
                        OpenRegistration();
                        window.Close();
                    }
                }
                );
            }
        }

        //проверка валидности заполняемых полей и хэширование пароля
        private bool IsValidInput(Window window)
        {
            bool isValid = true;
            using (ApplicationContext db = new ApplicationContext())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
                
                if (existingUser != null)
                {
                    if (existingUser.Email != Email)
                    {
                        SetBlockControlColor(window, "InputEmail", Brushes.DarkRed);
                        isValid = false;
                    }
                    if (existingUser.Password != Password)
                    {
                        SetBlockControlColor(window, "InputPassword", Brushes.DarkRed);
                        isValid = false;
                    }
                }
                else
                {
                    SetBlockControlColor(window, "InputPassword", Brushes.DarkRed);
                    SetBlockControlColor(window, "InputEmail", Brushes.DarkRed);
                    isValid = false;
                }
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

        //Методы открытия окон
        private void OpenHomeWindow()
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
        }
        private void OpenRegistration()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }
        private void OpenShowUsers()
        {
            ShowUsers showUsers = new ShowUsers();
            showUsers.Show();
        }
        //Методы по Хэшированию пароля
        #region
        #endregion
    }
}
