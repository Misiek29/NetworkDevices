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
        NetworkDeviesEntities db;
        public MainWindow()
        {
            InitializeComponent();
            
        }

       
        private void btnAddMain_Click(object sender, RoutedEventArgs e)
        {
            ADD win = new ADD();
            win.Show();
        }

        private void btnMore_Click(object sender, RoutedEventArgs e)
        {
            Info win = new Info();
            win.Show();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void dgDevicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new NetworkDeviesEntities();
            dgDevicesList.ItemsSource = db.Devices.ToList();
        }

        private void cbSearchCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
