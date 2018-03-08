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

namespace wpfNetworkDevices.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy More.xaml
    /// </summary>
    public partial class Info : Window
    {
        Model1 modelCodeFirst = new Model1();
        public int ItemInfoID;


        public Info(int Iteminfo)
        {
            ItemInfoID = Iteminfo;
            InitializeComponent();
            Load();

        }

        public void Load()
        {
            var ItemInfo = modelCodeFirst.Devices.Where(m => m.id == ItemInfoID).Single();
            var ItemInfoConfig = modelCodeFirst.Configs.Where(j => j.id_device == ItemInfoID).ToList().Last();
            txtName.Text = ItemInfo.name;
            txtCategory.Text = ItemInfo.category;
            txtIP.Text = ItemInfoConfig.ip;
            txtMask.Text = ItemInfoConfig.mask;
            txtGate.Text = ItemInfoConfig.Gateway;
            txtDNS.Text = ItemInfoConfig.DNS;

            dgInfo.ItemsSource = modelCodeFirst.Configs.Where(j => j.id_device == ItemInfoID && j.ip != "none").ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
