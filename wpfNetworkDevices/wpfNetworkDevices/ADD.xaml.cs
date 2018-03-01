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
using System.Windows.Shapes;

namespace wpfNetworkDevices
{
    /// <summary>
    /// Logika interakcji dla klasy ADD.xaml
    /// </summary>
    public partial class ADD : Window
    {
        Model1 dbCodeFirst = new Model1();


        public ADD()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Device newDevice = new Device()
            {
                name = txtDeviceName.Text,
                manufacturer = txtManufacturer.Text,
                category = cbCategory.Text

            };

            dbCodeFirst.Devices.Add(newDevice);
            dbCodeFirst.SaveChanges();
            Close();
        }
    }
}
