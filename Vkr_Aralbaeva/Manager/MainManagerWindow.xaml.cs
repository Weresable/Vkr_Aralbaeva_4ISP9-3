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
using Vkr_Aralbaeva.Pages;
using static Vkr_Aralbaeva.Data.DataHelp;

namespace Vkr_Aralbaeva.Manager
{
    /// <summary>
    /// Логика взаимодействия для MainManagerWindow.xaml
    /// </summary>
    public partial class MainManagerWindow : Window
    {
        public MainManagerWindow()
        {
            InitializeComponent();
            frame = frmMain;
            frmMain.Navigate(new MainPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new MainPage());
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }

        private void Button_Click_Client(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new Client());
        }

        private void Button_Click_Service(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new Service());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new Order());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new AddOrder());
            
        }
    }
}
