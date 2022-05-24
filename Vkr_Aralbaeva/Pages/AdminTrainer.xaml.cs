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
using Vkr_Aralbaeva.Admin;
using Vkr_Aralbaeva.Data;


namespace Vkr_Aralbaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminTrainer.xaml
    /// </summary>
    public partial class AdminTrainer : Page
    {
        public List<Data.Worker> list;
        public AdminTrainer()
        {
            InitializeComponent();
            txbAuthUser.Text = authUser.InicialRole;
            LVTrainer.ItemsSource = context.Worker.Where(i => i.IdRole == 3).ToList();
            cmbSort.ItemsSource = new List<string>{
                "По умолчанию",
                "По фамилии",
                "По имени",
            };
            cmbSort.SelectedIndex = 0;
        }

        public void Filter()
        {
            list = context.Worker.Where(i => i.FirstName.Contains(tbFind.Text) ||
             i.LastName.Contains(tbFind.Text) || i.Patronymic.Contains(tbFind.Text)).ToList();
            LVTrainer.ItemsSource = list;
            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    list = list.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    list = list.OrderByDescending(i => i.FirstName).ToList();
                    break;
       
            }
            LVTrainer.ItemsSource = list;
        }

        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Btn_AddCTrainer(object sender, RoutedEventArgs e)
        {
            AddTrainer addTrainer = new AddTrainer();
            addTrainer.ShowDialog();
            Filter();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Worker item = LVTrainer.SelectedItem as Worker;
            AddTrainer addTrainer = new AddTrainer(item);
            addTrainer.ShowDialog();
            Filter();
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            Worker item = LVTrainer.SelectedItem as Worker;
            if (MessageBox.Show("Вы уверены, что хотите удалить тренера из базы?",
                    "Удаление тренера",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                context.Worker.Remove(item);
                context.SaveChanges();
                Filter();
            }
           
        }
    }
}