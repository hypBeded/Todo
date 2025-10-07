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
            string email = TBEmail.Text;
            string password = TBPassword.Text;
            string repeatPassword = TBRepeatPassword.Text;
            string login = TBUserName.Text;

            string Error = " ";

            if (login.Length < 3)
            {
                Error += "Имя пользователя должно состоять минимум из 3 символов. ";
            }

            if (!Validate.ValidateEmail(email))
            {
                Error += "Неккоретная почта. ";

            }

            if (!Validate.ValidatePassword(password))
            {
                Error += "Пароль должен состоять как минимум из 6 символов. ";

            }

            if (password != repeatPassword)
            {
                Error += "Пароли не совпадают. ";

            }
            if (!string.IsNullOrEmpty(Error))
            {
                MessageBox.Show(Error, "Ошибка");
                return;
            }
            else
            {
                try
                {
                    UR.UserRegistration(login, password, email);
                    Main_empty main_Empty = new Main_empty(login);
                    main_Empty.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
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
