using Microsoft.Toolkit.Mvvm.Input;
using SC4690_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace SC4690_SZTGUI_2023242.WpfClient
{
    class NonCrudViewModel : ObservableRecipient
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private readonly RestService Rest_owner;
        private readonly RestService Rest_tablet;


        public ICommand ShowLaptopCount { get; set; }
        public ICommand ShowPhoneSumPrice { get; set; }
        public ICommand ShowHugePhone { get; set; }
        public ICommand ShowAppleUser { get; set; }
        public ICommand ShowAllDevicePrice { get; set; }
        public ICommand ShowRoseGoldTablet { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public NonCrudViewModel()
        {
            if (!IsInDesignMode)
            {
                ;
                Rest_owner = new RestService("http://localhost:25418/", "owner");
                Rest_tablet = new RestService("http://localhost:25418/", "tablet");
                ;

                ShowLaptopCount = new RelayCommand(() =>
                {
                    GetLaptopCount(Id);
                });
                ShowPhoneSumPrice = new RelayCommand(() =>
                {
                    GetPhoneSumPrice(Id);
                });

                ShowHugePhone = new RelayCommand(() =>
                {
                    GetHugePhone(Id);
                });

                ShowAppleUser = new RelayCommand(() =>
                {
                    GetAppleUser(Id);
                });

                ShowAllDevicePrice = new RelayCommand(() =>
                {
                    GetAllDevicePrice(Id);
                });

                ShowRoseGoldTablet = new RelayCommand(() =>
                {
                    GetRoseGoldTablet(Id);
                });
            }

        }

        public void ShowMessageBox(string message, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox.Show(message, caption, button, icon);
        }
        private void GetLaptopCount(int id)
        {
            try
            {
                int laptopcount = Rest_owner.Get<int>(id, "DeviceStat/LaptopCount");
                ShowMessageBox($"The count of the persons: {laptopcount}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (ArgumentException ex)
            {

            }
        }
        private void GetPhoneSumPrice(int id)
        {
            try
            {
                int phoneSumPrice = Rest_owner.Get<int>(id, "DeviceStat/PhoneSumPrice");
                ShowMessageBox($"The sum price of the phones: {phoneSumPrice}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                // Handle exception
            }
        }

        private void GetHugePhone(int id)
        {
            try
            {
                bool hasHugePhone = Rest_owner.Get<bool>(id, "DeviceStat/HugePhone");
                ShowMessageBox($"Has huge phone: {hasHugePhone}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                // Handle exception
            }
        }

        private void GetAppleUser(int id)
        {
            try
            {
                bool isAppleUser = Rest_owner.Get<bool>(id, "DeviceStat/AppleUser");
                ShowMessageBox($"Apple user: {isAppleUser}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                // Handle exception
            }
        }

        private void GetAllDevicePrice(int id)
        {
            try
            {
                double allDevicePrice = Rest_owner.Get<double>(id, "DeviceStat/AllDevicePrice");
                ShowMessageBox($"All devices price: {allDevicePrice}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                // Handle exception
            }
        }

        private void GetRoseGoldTablet(int id)
        {
            try
            {
                bool hasRoseGoldTablet = Rest_owner.Get<bool>(id, "DeviceStat/RosegoldTablet");
                ShowMessageBox($"Has rosegold tablet: {hasRoseGoldTablet}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                // Handle exception
            }
        }
    }
}