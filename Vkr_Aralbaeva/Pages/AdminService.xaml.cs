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

namespace Vkr_Aralbaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminService.xaml
    /// </summary>
    public partial class AdminService : Page
    {
        public List<Data.Service> list;
        public AdminService()
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

     

        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void LVService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Data.Service)LVService.SelectedItem;
            if (item != null)
            {
                tbName.Text = item.NameService;
                tbDes.Text = item.MinDescription;
                tbCost.Text = item.Cost.ToString();
            }
            LVService.ItemsSource = context.Service.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (Data.Service)LVService.SelectedItem;
                if (item != null)
                {
                    item.MinDescription = tbDes.Text;
                    item.Cost = Convert.ToInt32(tbCost.Text);
                    item.NameService = tbName.Text;
                    MessageBox.Show("Услуга успешно изменена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    context.Service.Add(new Data.Service
                    {
                        MinDescription = tbDes.Text,
                        Cost = Convert.ToInt32(tbCost.Text),
                        NameService = tbName.Text
                    });
                    MessageBox.Show("Новая услуга успешно создана", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                context.SaveChanges();
                LVService.ItemsSource = context.Service.ToList();
            }
            catch
            {
                MessageBox.Show("Проверьте наличие данных в полях и их корректность", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            var item = button.DataContext as Data.Service;
            var itemb = context.Service.Where(i => i.IdService == item.IdService).First();
            var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                context.Service.Remove(itemb);
                MessageBox.Show("Услуга удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            context.SaveChanges();
            Filter();
        }

        private void LVTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.Tag item = LVTag.SelectedItem as Data.Tag;
            LVService.ItemsSource = context.Service.ToList().Where(i => i.Tag.Contains(item));
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

