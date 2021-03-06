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

namespace Vkr_Aralbaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для Service.xaml
    /// </summary>
    public partial class Service : Page
    {
        public List<Data.Service> list;
        public Service()
        {
            InitializeComponent();
            LVService.ItemsSource = context.Service.ToList();
            LVTag.ItemsSource = context.Tag.ToList();
            txbAuthUser.Text = authUser.InicialRole;
            cmbSort.ItemsSource = new List<string>{
                "По умолчанию",
                "Наименование (от А до Я)",
                "Наименование (от Я до А)",
                "Цена (по возрастанию)",
                "Цена (по убыванию)"
            };
            cmbSort.SelectedIndex = 0;
        }

        public void Filter()
        {
            list = context.Service.Where(i => i.NameService.Contains(tbFind.Text)).ToList();
            LVService.ItemsSource = list;
            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    list = list.OrderBy(i => i.NameService).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.NameService).ToList();
                    break;
                case 3:
                    list = list.OrderBy(i => i.Cost).ToList();
                    break;
                case 4:
                    list = list.OrderByDescending(i => i.Cost).ToList();
                    break;
            }
            LVService.ItemsSource = list;
        }

        private void LVService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Data.Service)LVService.SelectedItem;
            tbxNameService.Text = item.NameService;
            tbxDescription.Text = item.Description;
            btnOrder.Visibility = Visibility;
        }

        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        
        private void LVTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.Tag item = LVTag.SelectedItem as Data.Tag;
            LVService.ItemsSource = context.Service.ToList().Where(i => i.Tag.Contains(item));
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            var item = LVService.SelectedItem as Data.Service;
            

            selectedService = item;

            frame.Navigate(new AddOrder());
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {

            LVService.ItemsSource = context.Service.ToList();
            tbFind.Text = "";
            cmbSort.SelectedIndex = 0;
            context.SaveChanges();
            Filter();
        }
    }
}
