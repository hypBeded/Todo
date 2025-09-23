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

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            string email = TBEmail.Text;
            string password = TBPassword.Text;
            Validate validate = new Validate();
            string errorMessages = "";

            if (!validate.ValidatePassword(password))
            {
                errorMessages += "Пароль должен содержать не менее 6 символов. ";
            }

            if (!validate.ValidateEmail(email))
            {
                errorMessages += "Не существует такой почты. ";
            }
            
            
           /* if (!string.IsNullOrEmpty(errorMessages))
            {
                MessageBox.Show(errorMessages);
            }
            else
            {
                Main_empty Main_empty = new Main_empty();
                Main_empty.Show();
                this.Close();

            } */
            
            Main_empty main_empty = new Main_empty();
           main_empty.Show();
           this.Close(); 
        }

        private void Registation(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
