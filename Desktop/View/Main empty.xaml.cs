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
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.NavigationFrame.Navigate(new LogIn());
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new NavigationWindow
            {
                Title = "Добавить задачу",
                Content = new AddTaskDialog(_currentUser, true),
                Width = 420,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                ShowsNavigationUI = false // Скрываем навигационную панель
            };

            dialogWindow.Owner = Application.Current.MainWindow;
            var result = dialogWindow.ShowDialog();

            if (result == true) // Если диалог закрыт с успешным результатом
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.NavigationFrame.Navigate(new Main(_currentUser));
                }
            }


        }


    }
}

