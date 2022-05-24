using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vkr_Aralbaeva.Data
{
    class DataHelp
    {
        public static EntitiesDB context = new EntitiesDB();
        public static Worker authUser;
        public static Customer selectedClient = null;
        public static Worker selectedWorker = null;
        public static Service selectedService = null;
        public static Frame frame;
    }
}
