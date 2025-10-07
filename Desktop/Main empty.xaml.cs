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
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Main_empty.xaml
    /// </summary>
    public partial class Main_empty : Window
    {
        public Main_empty(string login)
        {
            InitializeComponent();
            string Login = login;
        }
        
        private void ClickImage(object sender, MouseButtonEventArgs e)
        {
            if (popup.IsOpen) {  popup.IsOpen = false; }
            else { popup.IsOpen = true; }
        }
        private void ChangeProfileImage_Click(object sender, RoutedEventArgs e)
        { 
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
     }
}

