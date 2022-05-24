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
using static Vkr_Aralbaeva.Data.DataHelp;
using Vkr_Aralbaeva.Data;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vkr_Aralbaeva.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddTrainer.xaml
    /// </summary>
    public partial class AddTrainer : Window
    {
        public Worker item =null;
        public AddTrainer(Worker item=null)
        {
            InitializeComponent();
            if(item != null)
            {
                tbxTitle.Text="Изменить тренера";
                btnAddTrainer.Content = "Сохранить изменения";
                tbLastName.Text = item.LastName.ToString();
                tbFirstName.Text = item.FirstName.ToString();
                if(item.Patronymic != null)
                {
                    tbPatr.Text = item.Patronymic.ToString();
                }
                tbPhone.Text = item.Phone.ToString();
                tbEmail.Text = item.Email.ToString();
                tbDateBirth.Text = item.DateOfBirth.ToString();
                this.item = item;
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAddTrainer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (item != null)
                {
                    item.FirstName = tbFirstName.Text;
                    item.LastName = tbLastName.Text;
                    item.Patronymic = tbPatr.Text;
                    item.Phone = tbPhone.Text;
                    item.DateOfBirth = Convert.ToDateTime(tbDateBirth.Text);
                    item.Email = tbEmail.Text;
                    MessageBox.Show("Тренер успешно изменён", "Успех", MessageBoxButton.OK);
                }
                else
                {
                    selectedWorker = context.Worker.Add(new Worker
                    {
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        Patronymic = tbPatr.Text,
                        IdRole = 3,
                        Password = "trainer",
                        Phone = tbPhone.Text,
                        DateOfBirth = Convert.ToDateTime(tbDateBirth.Text),
                        Email = tbEmail.Text,

                    });
                    MessageBox.Show("Новый тренер успешно создан", "Успех", MessageBoxButton.OK);
                }
                context.SaveChanges();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Проверьте наличие данных в полях и их корректность", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
    }
}
