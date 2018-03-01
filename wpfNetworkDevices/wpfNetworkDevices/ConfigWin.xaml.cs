﻿using System;
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

namespace wpfNetworkDevices.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Config.xaml
    /// </summary>
    public partial class ConfigWin : Window
    {
        public ConfigWin()
        {
            InitializeComponent();
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
                //tutaj dodawac dalszy kod
            }
            else
                MessageBox.Show("Please insert all data", "Error window", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
