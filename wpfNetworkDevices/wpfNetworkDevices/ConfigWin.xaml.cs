using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpfNetworkDevices.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Config.xaml
    /// </summary>
    public partial class ConfigWin : Window
    {
        public int IDToConfig;
        Model1 dbCodeFirst = new Model1();
        public ConfigWin(int idConfig)
        {
            InitializeComponent();
            IDToConfig = idConfig;
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(!(string.IsNullOrEmpty(txtIP.Text)|| string.IsNullOrEmpty(txtDNS1.Text)
                || string.IsNullOrEmpty(txtGateway.Text)||string.IsNullOrEmpty(txtMask.Text)))
            {
                string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

                if ((Regex.IsMatch(txtIP.Text, pattern)) & (Regex.IsMatch(txtMask.Text, pattern)) & (Regex.IsMatch(txtDNS1.Text, pattern)) & (Regex.IsMatch(txtGateway.Text, pattern)))
                    {// returns true
                    Config newConfig = new Config()
                    {
                        id_device = IDToConfig,
                        ip = txtIP.Text,
                        mask = txtMask.Text,
                        Gateway = txtGateway.Text,
                        DNS = txtDNS1.Text
                        
                    };
                    dbCodeFirst.Configs.Add(newConfig);
                    dbCodeFirst.SaveChanges();
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect date, please insert in format ###.###.###.###", "Error window", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
                MessageBox.Show("Please insert all data", "Error window", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
