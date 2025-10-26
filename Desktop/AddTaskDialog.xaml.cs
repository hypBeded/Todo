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
using Entities;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window
    {
        private UserModel _currentUser;
        TaskRepository TR = new TaskRepository();
        

        public AddTaskDialog(UserModel user)
        {
            InitializeComponent();  
            _currentUser = user;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string category = Category.Text;
            string description = Description.Text;
            DateTime date = DTP.SelectedDate ?? DateTime.Now;
            DateTime time = DateTime.Now;
            bool status = false;


            if (TR.NewTask(_currentUser,name, category, description, time, date, status))
            {


                MessageBox.Show("Задача успешно создана!");
                
                Main main = new Main(_currentUser);
                main.Show();
                this.Owner?.Close(); // Main_empty
                this.Close();
                
            }

    }
    }
}
