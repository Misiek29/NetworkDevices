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

        private void Load()
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
            Info win = new Info();
            win.Show();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWin newConfig = new ConfigWin();
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
            var deleteDevice = modelCodeFirst.Devices.Where(m => m.id == Id).Single();
            modelCodeFirst.Devices.Remove(deleteDevice);
            modelCodeFirst.SaveChanges();
            Load();
        }
    }
}
