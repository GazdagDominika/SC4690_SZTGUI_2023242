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
    class NonCrudViewModel:ObservableRecipient
    {


        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private readonly RestService Rest_owner;
        private readonly RestService Rest_tablet;


        public ICommand ShowLaptopCount { get; set; }

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
                    GetLaptopCount(id);
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

    }
}
