using Desktop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        UserRepository UR = new UserRepository();
        Validate validate = new Validate();

        public LogIn()
        {
            InitializeComponent();
            UR.UserRegistration("HypBed", "123456", "uym@gmail.com");
        }

        private void Login(object sender, RoutedEventArgs e)
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

                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.NavigationFrame.Navigate(new Main_empty(user));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigationFrame.Navigate(new Registration());
            }
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
            if (string.IsNullOrEmpty(TBEmail.Text))
            {
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

