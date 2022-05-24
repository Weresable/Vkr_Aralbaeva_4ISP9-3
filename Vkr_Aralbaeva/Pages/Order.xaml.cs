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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public List<Data.Order> list;
        public Order()
        {
            InitializeComponent();
            txbAuthUser.Text = authUser.InicialRole;
            LVOrder.ItemsSource = context.Order.ToList();
            LVTag.ItemsSource = context.Tag.ToList();
            cmbSort.ItemsSource = new List<string>{
                "По умолчанию",
                "Наименование услуги (от А до Я)",
                "Наименование услуги (от Я до А)",
                "Дата оказания услуги (по возрастанию)",
                "Дата оказания услуги (по убыванию)",
            };
            cmbSort.SelectedIndex = 0;
        }

        public void Filter()
        {
            list = context.Order.Where(i => i.Service.NameService.Contains(tbFind.Text) || i.Customer.FirstName.Contains(tbFind.Text) ||
             i.Customer.LastName.Contains(tbFind.Text) || i.Customer.Patronymic.Contains(tbFind.Text)).ToList();
            LVOrder.ItemsSource = list;
            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    list = list.OrderBy(i => i.Service.NameService).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.Service.NameService).ToList();
                    break;
                case 3:
                    list = list.OrderBy(i => i.DateOfService).ToList();
                    break;
                case 4:
                    list = list.OrderByDescending(i => i.DateOfService).ToList();
                    break;
            }
            LVOrder.ItemsSource = list;
        }


        private void LVOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Data.Order)LVOrder.SelectedItem;
            tbxInfo1.Visibility = Visibility.Collapsed;
            tbxInfo2.Visibility = Visibility.Collapsed;
            orderInfo.Visibility = Visibility.Visible;
            ServiceName.Text = item.Service.NameService;
            CustomerFullName.Text = item.Customer.FullName;
            CustomerPhone.Text = item.Customer.Phone;
            CustomerEmail.Text = item.Customer.Email;
            DateOrder.Text = item.DateOfOrder.ToString();
            DateService.Text = item.DateOfService.ToString();
            WorkerFullName.Text = item.Worker.FullName;
            WorkerEmail.Text = item.Worker.Email;
            WorkerPhone.Text = item.Worker.Phone;
            ServiceDescription.Text = item.Service.MinDescription;
        }
        private void LVTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.Tag item = LVTag.SelectedItem as Data.Tag;
            LVOrder.ItemsSource = context.Order.ToList().Where(i => i.Service.Tag.Contains(item));
        }
    }
}
