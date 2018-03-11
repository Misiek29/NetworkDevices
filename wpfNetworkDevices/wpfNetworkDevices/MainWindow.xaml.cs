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
using wpfNetworkDevices.Windows;

namespace wpfNetworkDevices
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // NetworkDeviesEntities db = new NetworkDeviesEntities();
        Model1 modelCodeFirst = new Model1();
       

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList();
        }

        private void btnAddMain_Click(object sender, RoutedEventArgs e)
        {
            ADD addWindow = new ADD();
            addWindow.ShowDialog();
            Load();
        }

        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            int Id = (dgDevicesList.SelectedItem as Device).id;
            var ItemInfo = modelCodeFirst.Devices.Where(m => m.id == Id).Single();
            Info winInfo = new Info(ItemInfo.id);
            winInfo.Show();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            
            int Id = (dgDevicesList.SelectedItem as Device).id;
            var ConfigItem = modelCodeFirst.Devices.Where(m => m.id == Id).Single();
            ConfigWin newConfig = new ConfigWin(ConfigItem.id);
            newConfig.ShowDialog();
            Load();
        }

        private void dgDevicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void cbSearchCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int Id = (dgDevicesList.SelectedItem as Device).id;
            int id_devices = Id;
            var deleteDevice = modelCodeFirst.Devices.Where(m => m.id == Id).Single();

            var DeleteDiveConfig =
              from odq in modelCodeFirst.Configs
              where odq.id_device == id_devices
              select odq;
            foreach (var selectedConfig in  DeleteDiveConfig)
            {
                modelCodeFirst.Configs.RemoveRange(DeleteDiveConfig);
            }
            modelCodeFirst.Devices.Remove(deleteDevice);
            
            modelCodeFirst.SaveChanges();
            Load();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
                string name = txtDeviceName.Text;
                string manufacturer = txtManufacturer.Text;
                string category = cbSearchCategory.Text;


            var query = modelCodeFirst.Devices.AsQueryable();
            if (! string.IsNullOrEmpty(name))
            {
                query = query.Where(r => r.name == name);

            }
            if (!string.IsNullOrEmpty(manufacturer))
            {
                query = query.Where(r => r.manufacturer == manufacturer);
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(r => r.category == category);
            }
            dgDevicesList.ItemsSource = query.ToList();


            //if (string.IsNullOrEmpty(name)) // jeżeli pierwszy pusty
            //    {
            //        dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList().Where(x => x.manufacturer == manufacturer && x.category==category);
            //    }
            //    if (string.IsNullOrEmpty(manufacturer)) //jeżeli drugi pusty
            //    {
            //    dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList().Where(x => x.name == name && x.category == category);
            //    }
            //    if (string.IsNullOrEmpty(category)) // jeżeli trzeci pusty
            //    {
            //    dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList().Where(x => x.name == name && x.manufacturer == manufacturer);
            //    }
            //    if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(manufacturer))//pierwszy i drugi pusty
            //    {
            //    dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList().Where(x => x.category == category);
            //    }
            //    if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(category))//pierwszy i trzeci
            //    {
            //    dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList().Where(x => x.manufacturer == manufacturer);
            //    }
            //    if (string.IsNullOrEmpty(manufacturer) && string.IsNullOrEmpty(category))
            //    {
            //    dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList().Where(x => x.name == name);
            //    }
            //    if (!(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(manufacturer) && string.IsNullOrEmpty(category)))
            //{
            //    dgDevicesList.ItemsSource = modelCodeFirst.Devices.ToList().Where(x => x.name == name && x.manufacturer == manufacturer && x.category == category);
            //}

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(manufacturer) && string.IsNullOrEmpty(category))
                {
                MessageBox.Show("Please insert all data", "Error window", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            txtDeviceName.Text = null;
            txtManufacturer.Text = null;
            cbSearchCategory.SelectedValue = null;
                

            InitializeComponent();

        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
