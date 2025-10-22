using Desktop.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using Desktop.Repository;

using static Desktop.Validate;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        UserRepository UR = new UserRepository();
        Validate Validate = new Validate();

        public Registration()
        {
            InitializeComponent();
        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            string email = TBEmail.Text.Trim().ToLower();
            string password = TBPassword.Text.Trim();
            string repeatPassword = TBRepeatPassword.Text.Trim();
            string login = TBUserName.Text.Trim();

           

            if (login.Length < 3)
            {
                MessageBox.Show("Имя пользователя должен состоять минимум из 3 символов", "Ошибка");
                return; 
            }

            if (!Validate.ValidateEmail(email))
            {
                MessageBox.Show("Некорректный email.", "Ошибка");
                return; 
            }

            if (!Validate.ValidatePassword(password))
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов.", "Ошибка");
                return; 
            }

            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка");
                return; 
            }
            try
            {
                var user = UR.UserRegistration(login, password, email);

                Main_empty main_Empty = new Main_empty(user);
                main_Empty.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
        }

        private void BackToLogIn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void TBUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if(TBUserName.Text == "Введите имя пользователя")
            {
                TBUserName.Text = string.Empty;
            }
        }

        private void TBUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBUserName.Text))
            {
                TBUserName.Text = "Введите имя пользователя";
            }
        }

        private void TBEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBEmail.Text == "Введите почту")
            {
                TBEmail.Text = string.Empty;
            }
        }

        private void TBEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBEmail.Text))
            {
                TBEmail.Text = "Введите почту";
            }
        }

        private void TBPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text == "Введите пароль")
            {
                TBPassword.Text = string.Empty;
            }
        }

        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPassword.Text))
            {
                TBPassword.Text = "Введите пароль";
            }
        }

        private void TBRepeatPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBRepeatPassword.Text == "Повторите пароль")
            {
                TBRepeatPassword.Text = string.Empty;
            }
        }

        private void TBRepeatPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBRepeatPassword.Text))
            {
                TBRepeatPassword.Text = "Повторите пароль";
            }
        }
    }
}
