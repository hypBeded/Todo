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

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        public class Validate
        {
            private readonly string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            public bool ValidateEmail(string email)
            {
                if (string.IsNullOrEmpty(email))
                    return false;

                return Regex.IsMatch(email, emailPattern);
            }
            public bool ValidatePassword(string Password)
            {
                return !string.IsNullOrWhiteSpace(Password) && Password.Length >= 6;
            }
            public bool ValidateUserName(string userName)
            {
                return !string.IsNullOrWhiteSpace(userName) && userName.Length >= 3;
            }
        }
        // Нажатие кнопки регистрации и назад
        private void Registation(object sender, RoutedEventArgs e)
        {
            string email = TBEmail.Text;
            string password = TBPassword.Text;
            string repeatPassword = TBRepeatPassword.Text;
            string userName = TBUserName.Text;

            Validate validate = new Validate();
            string errorMessages = "";

            if (password != repeatPassword)
            {
                errorMessages += "Неправильно повторенный пароль. ";
            }
                if (!validate.ValidatePassword(password))
                {
                    errorMessages += "Пароль должен содержать не менее 6 символов. ";
                }

                if (!validate.ValidateEmail(email))
                {
                    errorMessages += "Не существует такой почты. ";
                }

                if (!validate.ValidateUserName(userName))
                {
                    errorMessages += "Имя должно содержать не менее 3 символов. ";
                }

            if (!string.IsNullOrEmpty(errorMessages))
            {
                MessageBox.Show(errorMessages); 
            }
            else
            {
                Main_empty Main_empty = new Main_empty();
                Main_empty.Show();
                this.Close();
            }
        }
        private void BackToLogIn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
