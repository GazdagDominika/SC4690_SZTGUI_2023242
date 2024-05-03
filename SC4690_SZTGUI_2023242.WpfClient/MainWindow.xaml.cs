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

namespace SC4690_SZTGUI_2023242.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OwnerButton_Click(object sender, RoutedEventArgs e)
        {
            // Megnyitjuk az OwnerWindow-t
            OwnerWindow ownerWindow = new OwnerWindow();
            ownerWindow.ShowDialog();
        }

        private void LaptopButton_Click(object sender, RoutedEventArgs e)
        {
            LaptopWindow laptopWindow = new LaptopWindow();
            laptopWindow.ShowDialog();
        }

        private void TabletButton_Click(object sender, RoutedEventArgs e)
        {
            TabletWindow tabletWindow = new TabletWindow();
            tabletWindow.ShowDialog();
        }

        private void SmartPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            SmartPhoneWindow smartPhoneWindow = new SmartPhoneWindow();
            smartPhoneWindow.ShowDialog();
        }
    }
}
