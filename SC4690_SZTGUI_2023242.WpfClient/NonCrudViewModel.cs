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

        private readonly RestService Rest;


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
            if(!IsInDesignMode)
            {
                Rest = new RestService("http://localhost:25418/", "devicestat");


                ShowLaptopCount = new RelayCommand(async () =>
                {
                    GetLaptopCount();
                });
            }
            
        }

        public void ShowMessageBox(string message, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox.Show(message, caption, button, icon);
        }
        private async void GetLaptopCount()
        {
            try
            {
                int laptopcount = await Rest.GetSingleAsync<int>("/api/devicestat/laptopcount");
                ShowMessageBox($"The count of the persons: {laptopcount}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (ArgumentException ex)
            {

            }
        }

    }
}
