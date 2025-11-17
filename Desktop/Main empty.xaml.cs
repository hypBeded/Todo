using Entities;
using System.Windows;
using System.Windows.Input;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Main_empty.xaml
    /// </summary>
    public partial class Main_empty : Window
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTaskDialog addTaskDialog = new AddTaskDialog(_currentUser, true);
            addTaskDialog.Owner = this;  // Устанавливаем владельца диалога
            addTaskDialog.ShowDialog();
        }

       
    }
}

