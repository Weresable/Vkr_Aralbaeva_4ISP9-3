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
using static Vkr_Aralbaeva.Data.DataHelp;
using Vkr_Aralbaeva.Data;
using Vkr_Aralbaeva.Manager;

namespace Vkr_Aralbaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();
            txbAuthUser.Text = authUser.InicialRole;
            LVClient.ItemsSource = context.Customer.ToList();
        }


        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            LVClient.ItemsSource = context.Customer.Where(i => i.FirstName.Contains(tbFind.Text) ||
            i.LastName.Contains(tbFind.Text) || i.Patronymic.Contains(tbFind.Text) || i.Phone.Contains(tbFind.Text) || i.Email.Contains(tbFind.Text)).ToList();
        }

        private void LVClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Customer)LVClient.SelectedItem;
            if (context.Order.Where(i => i.IdCustomer == item.IdCustomer).Count() > 0)
            {
                tbxInfo1.Visibility = Visibility.Collapsed;
                tbxInfo2.Visibility = Visibility.Collapsed;
                LVOrder.ItemsSource = context.Order.Where(i => i.IdCustomer == item.IdCustomer).ToList();
            }
            else
            {
                tbxInfo1.Text = "Заказы отсутствуют";
                tbxInfo2.Text = "Вы можете оформить заказ на окне оформления заказов";
            }
        }

        private void Btn_AddClient(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.ShowDialog();
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            var item = button.DataContext as Customer;
            var itemb = context.Customer.Where(i => i.IdCustomer == item.IdCustomer).First();

            selectedClient = itemb;

            frame.Navigate(new AddOrder());
        }
    }
}
