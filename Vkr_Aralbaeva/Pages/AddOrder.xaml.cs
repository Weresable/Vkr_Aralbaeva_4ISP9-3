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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Page
    {
        public AddOrder()
        {
            InitializeComponent();
            txbAuthUser.Text = authUser.InicialRole;
            List<Worker> workers = context.Worker.Where(i=>i.IdRole==3).ToList();
            cmbWorker.ItemsSource = workers;
            cmbWorker.DisplayMemberPath = "FullName";
            cmbWorker.SelectedIndex = 0;
            if (selectedClient != null)
            {
                tbLastName.Text = selectedClient.LastName;
                tbFirstName.Text = selectedClient.FirstName;
                tbPatr.Text = selectedClient.Patronymic;
                tbPhone.Text = selectedClient.Phone;
                tbEmail.Text = selectedClient.Email;
                tbDateBirth.Text = selectedClient.DateOfBirth.ToString("dd.MM.yyyy");

            }
            if (selectedService != null)
            {
                tbNameService.Text = selectedService.NameService;
                tbDesService.Text = selectedService.MinDescription;
                tbCost.Text = selectedService.Cost.ToString();
                tbRubles.Text = "рублей";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Client());

        }

        private void Btn_AddService(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Service());
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Order.Add(new Data.Order
                {
                    IdCustomer = selectedClient.IdCustomer,
                    IdService = selectedService.IdService,
                    DateOfOrder = DateTime.Now,
                    DateOfService = dateOfService.SelectedDate.Value,
                    IdWorker = authUser.IdWorker
                });
                context.SaveChanges();
                selectedClient = null;
                selectedService = null;
                dateOfService.SelectedDate = null;
                tbLastName.Text = "";
                tbFirstName.Text = "";
                tbPatr.Text = "";
                tbPhone.Text = "";
                tbEmail.Text = "";
                tbDateBirth.Text = "";
                dateOfService.SelectedDate = null;
                tbNameService.Text = "Выбранная услуга";
                tbDesService.Text = "Информация о выбранной услуге";
                tbCost.Text = "Цена";
                tbRubles.Text = "";
                dateOfService.SelectedDate = null;
                MessageBox.Show("Новый заказ успешно создан", "Успех", MessageBoxButton.OK);
            }
            catch
            {
                MessageBox.Show("Проверьте наличие данных в полях и их корректность", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
       
    }
}
