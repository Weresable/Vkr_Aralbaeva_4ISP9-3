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
using static Vkr_Aralbaeva.Data.DataHelp;
using System.Windows.Shapes;

namespace Vkr_Aralbaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для TrainerShedule.xaml
    /// </summary>
    public partial class TrainerShedule : Page
    {
        public List<Data.Order> list;
        public TrainerShedule()
        {
            InitializeComponent();
            txbAuthUser.Text = authUser.InicialRole;
            LVTrainerShedule.ItemsSource = context.Order.Where(i => i.Worker.IdWorker == authUser.IdWorker).ToList();
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
            list = context.Order.Where(i => i.Worker.IdWorker == authUser.IdWorker && (i.Service.NameService.Contains(tbFind.Text) || i.Customer.FirstName.Contains(tbFind.Text) ||
             i.Customer.LastName.Contains(tbFind.Text) || i.Customer.Patronymic.Contains(tbFind.Text))).ToList();
            LVTrainerShedule.ItemsSource = list;
            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    list = list.OrderBy(i => i.DateOfService).ToList();
                    break;
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
            LVTrainerShedule.ItemsSource = list;
        }


        private void LVTrainerShedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = LVTrainerShedule.SelectedItem as Data.Order;
            tbxInfo1.Visibility = Visibility.Collapsed;
            tbxInfo2.Visibility = Visibility.Collapsed;
            orderInfo.Visibility = Visibility.Visible;
            if (item != null)
            {
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
            LVTrainerShedule.ItemsSource = context.Order.Where(i => i.Worker.IdWorker == authUser.IdWorker).ToList();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
        private void LVTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.Tag item = LVTag.SelectedItem as Data.Tag;
            LVTrainerShedule.ItemsSource = context.Order.ToList().Where(i => i.Service.Tag.Contains(item) && i.Worker.IdWorker == authUser.IdWorker); 
        }
    }
}

