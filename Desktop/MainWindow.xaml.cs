using System;
using System.Windows;
using System.Windows.Controls;
using Desktop.Repository;
using Desktop.View;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LogIn());
        }
        public Frame NavigationFrame => MainFrame;
    }
}
