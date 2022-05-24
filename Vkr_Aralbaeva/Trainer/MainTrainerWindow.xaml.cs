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

namespace Vkr_Aralbaeva.Trainer
{
    /// <summary>
    /// Логика взаимодействия для MainTrainerWindow.xaml
    /// </summary>
    public partial class MainTrainerWindow : Window
    {
        public MainTrainerWindow()
        {
            InitializeComponent();
            frame = frmMain;
            frmMain.Navigate(new MainPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new TrainerShedule());
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
