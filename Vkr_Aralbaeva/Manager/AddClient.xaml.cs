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
using static Vkr_Aralbaeva.Data.DataHelp;
using Vkr_Aralbaeva.Data;
using Vkr_Aralbaeva.Manager;

namespace Vkr_Aralbaeva.Manager
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            selectedClient = context.Customer.Add(new Customer
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Patronymic = tbPatr.Text,
                Phone = tbPhone.Text,
                DateOfBirth = Convert.ToDateTime(tbDateBirth.Text),
                Email = tbEmail.Text,

            });
            context.SaveChanges();
            this.Close();
        }
    }
}
