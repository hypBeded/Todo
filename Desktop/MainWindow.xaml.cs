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
            UR.UserRegistration("HypBed", "YmarCham07", "uymaevymat@gmail.com");
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            string email = TBEmail.Text;
            string password = TBPassword.Text;

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

            else
                {
                    try
                    {
                        var user = UR.UserAuthenticate(email, password);
                        Main_empty main_Empty = new Main_empty(user.Login);
                        main_Empty.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                        return;
                    }
                }
        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        
    }
}
