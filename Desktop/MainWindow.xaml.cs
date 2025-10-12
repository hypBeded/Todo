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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Desktop.Repository;

using static Desktop.Validate;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserRepository UR = new UserRepository();
        Validate validate = new Validate();

        public MainWindow()
        {
            InitializeComponent();
            UR.UserRegistration("HypBed", "123456", "uym@gmail.com");
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            string email = TBEmail.Text.Trim().ToLower();
            string password = TBPassword.Text.Trim();

            //Проверка полей на правильность с последующий входом

            if (!validate.ValidateEmail(email))
            {
                MessageBox.Show("Некорректный email.", "Ошибка");
                return;
            }

            if (!validate.ValidatePassword(password))
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов.", "Ошибка");
                return;
            }
                    try
                    {
                        var user = UR.UserAuthenticate(email, password);
                        Main_empty main_Empty = new Main_empty();
                        main_Empty.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                        return;
                    }
        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void TBEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBEmail.Text == "Почта")
            {
                TBEmail.Text = string.Empty;
            }
        }

        private void TBEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBEmail.Text)) {
                TBEmail.Text = "Почта";
            }
        }

        private void TBPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Text == "Пароль")
            {
                TBPassword.Text = string.Empty;
            }
        }

        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPassword.Text))
            {
                TBPassword.Text = "Пароль";
            }
        }
    }
}
