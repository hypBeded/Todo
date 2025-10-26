using Desktop.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        
     
        UserModel _currentUser;
        public Main(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            TasksListView.ItemsSource = _currentUser.UTasks;

            
        }
       
    }
}
