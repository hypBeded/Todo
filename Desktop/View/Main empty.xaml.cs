using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для Main_empty.xaml
    /// </summary>
    public partial class Main_empty : Page
    {
        private UserModel _currentUser;
        public Main_empty(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            NickName.Content = user.Login;

        }

        private void ClickImage(object sender, MouseButtonEventArgs e)
        {
            if (popup.IsOpen) { popup.IsOpen = false; }
            else { popup.IsOpen = true; }
        }
        private void ChangeProfileImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddTaskDialog addTaskDialog = new AddTaskDialog(_currentUser, true);
            //addTaskDialog.Owner = this;  // Устанавливаем владельца диалога
            //addTaskDialog.ShowDialog();
        }


    }
}

