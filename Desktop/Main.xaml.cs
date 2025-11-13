using Desktop.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window, INotifyPropertyChanged
    {
        private UserModel _currentUser;
        private TaskModel _selectedTask;

        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
                UpdateDetailFields();
            }
        }

        public Main(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            TasksListView.ItemsSource = _currentUser.UTasks;

            // Установите DataContext
            DataContext = this;
        }

        private void TasksListView_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedTask = TasksListView.SelectedItem as TaskModel;
        }

        private void UpdateDetailFields()
        {
            if (SelectedTask != null)
            {
                // Эти поля теперь будут обновляться через привязку данных
                // Уберите прямую установку текста если используете привязку
            }
        }
        public void RefreshTasks()
        {
            TasksListView.ItemsSource = null;
            TasksListView.ItemsSource = _currentUser.UTasks;
        }
       
        private void AddTask(object sender, RoutedEventArgs e)
        {
            AddTaskDialog addTaskDialog = new AddTaskDialog(_currentUser, false); 
            addTaskDialog.Owner = this;
            addTaskDialog.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
