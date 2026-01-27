using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page, INotifyPropertyChanged
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
            }
        }

        public Main(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            NickName.Content = user.Login;
            TasksListView.ItemsSource = _currentUser.UTasks;
            DataContext = this;
        }

        private void TasksListView_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedTask = TasksListView.SelectedItem as TaskModel;
        }

        private void AddTask(object sender, RoutedEventArgs e)
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
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            var homeTasks = _currentUser.UTasks.Where(t => t.Category == "Home").ToList();
            TasksListView.ItemsSource = homeTasks;
        }
        private void WorkClick(object sender, RoutedEventArgs e)
        {
            var workTasks = _currentUser.UTasks.Where(t => t.Category == "Work").ToList();
            TasksListView.ItemsSource = workTasks;
        }
        private void StudyClick(object sender, RoutedEventArgs e)
        {
            var StudyTasks = _currentUser.UTasks.Where(t => t.Category == "Study").ToList();
            TasksListView.ItemsSource = StudyTasks;
        }
        private void OtdixClick(object sender, RoutedEventArgs e)
        {
            var OtdixTasks = _currentUser.UTasks.Where(t => t.Category == "Leisure").ToList();
            TasksListView.ItemsSource = OtdixTasks;
        }
        private void TaskList(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var TaskList = _currentUser.UTasks.Where(t => t.Status == false).ToList();
            TasksListView.ItemsSource = TaskList;
        }
        private void EndedTasks(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var EndedTasks = _currentUser.UTasks.Where(t => t.Status == true).ToList();
            TasksListView.ItemsSource = EndedTasks;
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            _currentUser.UTasks.Remove(SelectedTask);
            RefreshTasks();
        }
        private void Compleated_Click(object sender, RoutedEventArgs e)
        {
            SelectedTask.Status = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshTasks()
        {
            TasksListView.ItemsSource = null;
            TasksListView.ItemsSource = _currentUser.UTasks;
        }
    }
}

