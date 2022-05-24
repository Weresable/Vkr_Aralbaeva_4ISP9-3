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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vkr_Aralbaeva.Manager;
using Vkr_Aralbaeva.Trainer;
using Vkr_Aralbaeva.Admin;
using static Vkr_Aralbaeva.Data.DataHelp;

namespace Vkr_Aralbaeva
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Auth(object sender, RoutedEventArgs e)
        {
            authUser = context.Worker.Where(i => i.Email == tbEmail.Text).FirstOrDefault();
            if (authUser != null)
            {
                if (tbEmail.Text == authUser.Email && pbPassword.Password == authUser.Password && authUser.IdRole == 1)
                {
                    MainManagerWindow mainManagerWindow = new MainManagerWindow();
                    mainManagerWindow.ShowDialog();
                    this.Close();
                }
                else if (tbEmail.Text == authUser.Email && pbPassword.Password == authUser.Password && authUser.IdRole == 2)
                {
                    MainAdminWindow mainAdminWindow = new MainAdminWindow();
                    mainAdminWindow.ShowDialog();
                    this.Close();
                }
                else if(tbEmail.Text == authUser.Email && pbPassword.Password == authUser.Password && authUser.IdRole == 3)
                {
                    MainTrainerWindow mainTrainerWindow = new MainTrainerWindow();
                    mainTrainerWindow.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неправильный пароль или логин");
            }
        }

        private void Btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
