using System;
using System.Windows;
using System.Windows.Controls;
using Entities;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window
    {
        private UserModel _currentUser;
        private TaskRepository TR = new TaskRepository();
        private bool _isNewMainWindow = false;

        public AddTaskDialog(UserModel user, bool isNewMainWindow = false)
        {
            InitializeComponent();
            _currentUser = user;
            _isNewMainWindow = isNewMainWindow;
        }
        string category;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name;
            if (string.IsNullOrEmpty(Name.Text))
            {
                return;
            }
            else
            {
                name = Name.Text;
            }

            if (category == null)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }

            string description = Description.Text;
            DateTime date = DTP.SelectedDate ?? DateTime.Now;
            DateTime time = DateTime.Now;
            bool status = false;

            if (TR.NewTask(_currentUser, name, category, description, time, date, status))
            {
                MessageBox.Show("Задача успешно создана!");

                if (_isNewMainWindow)
                {
                    
                    Main main = new Main(_currentUser);
                    main.Show();
                    this.Owner?.Close(); 
                }
                else
                {
                    if (this.Owner is Main mainWindow)
                    {
                        mainWindow.TasksListView.ItemsSource = null;
                        mainWindow.TasksListView.ItemsSource = _currentUser.UTasks;
                    }
                }

                this.Close();
            }
        }


       
        private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Category.SelectedItem is ComboBoxItem selectedItem)
            {
                category = selectedItem.Tag.ToString();
            }
        }
    }
}
