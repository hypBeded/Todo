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
        public Main_empty()
        {
            InitializeComponent();
        }
             private void Avatar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                // Открыть плашку при нажатии на аватарку
                popup.IsOpen = true;
            }

            private void ChangeProfileImage_Click(object sender, RoutedEventArgs e)
            {
                // Логика смены изображения профиля
                MessageBox.Show("Смена изображения профиля");
            }

            private void Logout_Click(object sender, RoutedEventArgs e)
            {
                // Логика выхода
                MessageBox.Show("Выход из системы");
            }
     }
}

