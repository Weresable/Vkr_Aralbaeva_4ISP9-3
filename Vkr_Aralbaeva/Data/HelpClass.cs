using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Vkr_Aralbaeva.Data
{
    
    public partial class Worker
    {
        public string FullName { get => $"{LastName + " " + FirstName + " " + Patronymic}"; }
        public string InicialRole 
        {
            get { 
                if(Patronymic != null)
                {
                    return $"{Role.NameRole + ": " + LastName + " " + FirstName.ToCharArray().GetValue(0) + ". " + Patronymic.ToCharArray().GetValue(0) + "."}";
                }
                else
                {
                    return $"{Role.NameRole + ": " + LastName + " " + FirstName.ToCharArray().GetValue(0) + ". "}";
                }
            }
               
        }

    }

    public partial class Service
    {
        public ImageSource ImgSourse
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Photo))
                    return null;

                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Resources/" + Photo.Trim();

                return new BitmapImage(new Uri(projectDirectory));
            }
        }
        public List<Tag> GetTag
        {
            get
            {
                return Tag.ToList(); ;
            }
        }
    }

    public partial class Customer
    {
        public string FullName { get => $"{LastName + " " + FirstName + " " + Patronymic}"; }
    }

    public partial class Order
    {
        public string Status
        {
            get
            {
                if (DateOfService <= DateTime.Now)
                    return "Заказ будет выполнен " + DateOfService;
                else
                    return "Услуга оказана";
            }
        }
        public string Color
        {
            get
            {
                if (DateOfService <= DateTime.Now)
                    return "#848C9B";
                else
                    return "#091A36";
            }
        }
        public string Color2
        {
            get
            {
                if (DateOfService <= DateTime.Now)
                    return "#848C9B";
                else
                    return "#04306C";
            }
        }
        public ImageSource ImgSourse
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Service.Photo))
                    return null;

                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Resources/" + Service.Photo.Trim();

                return new BitmapImage(new Uri(projectDirectory));
            }
        }
        public List<Tag> GetTag
        {
            get
            {
                return Service.Tag.ToList(); ;
            }
        }

    }

    public partial class Worker{
        public string Age { get => $"{(DateTime.Now-DateOfBirth).Days/365}"; }

        public ImageSource ImgSourse
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Photo))
                    return null;

                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "/Resources/" + Photo.Trim();

                return new BitmapImage(new Uri(projectDirectory));
            }
        }
    }
}
