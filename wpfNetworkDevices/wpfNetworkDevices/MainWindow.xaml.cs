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
            Config win = new Config();
            win.Show();
        }
    }
}
