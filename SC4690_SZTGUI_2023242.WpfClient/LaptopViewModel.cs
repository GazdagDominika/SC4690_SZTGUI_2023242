using Microsoft.Toolkit.Mvvm.ComponentModel;
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

namespace SC4690_SZTGUI_2023242.WpfClient
{
    public class LaptopViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Laptop> Laptops { get; set; }

        private Laptop selectedLaptop;

        public Laptop SelectedLaptop
        {
            get { return selectedLaptop; }
            set
            {
                if (value != null)
                {
                    selectedLaptop = new Laptop()
                    {
                        
                        LaptopName = value.LaptopName,
                        LaptopID = value.LaptopID,
                        OwnerID = value.OwnerID,
                        Price = value.Price,
                        DisplaySize = value.DisplaySize,
                        Colour = value.Colour
                    };
                    OnPropertyChanged();
                    (DeleteLaptopCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateLaptopCommand { get; set; }
        public ICommand DeleteLaptopCommand { get; set; }
        public ICommand UpdateLaptopCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public LaptopViewModel()
        {
            if (!IsInDesignMode)
            {
                Laptops = new RestCollection<Laptop>("http://localhost:25418/", "laptop", "hub");
                CreateLaptopCommand = new RelayCommand(() =>
                {
                    Laptops.Add(new Laptop()
                    {
                        LaptopName = SelectedLaptop.LaptopName,
                        LaptopID = SelectedLaptop.LaptopID,
                        OwnerID = SelectedLaptop.OwnerID,
                        Price = SelectedLaptop.Price,
                        DisplaySize = SelectedLaptop.DisplaySize,
                        Colour = SelectedLaptop.Colour


                    });
                });
                UpdateLaptopCommand = new RelayCommand(() =>
                {
                    Laptops.Update(SelectedLaptop);
                }, () =>
                {
                    return SelectedLaptop != null;
                });
                DeleteLaptopCommand = new RelayCommand(() =>
                {
                    Laptops.Delete(SelectedLaptop.LaptopID);
                }, () =>
                {
                    return SelectedLaptop != null;
                });
                SelectedLaptop = new Laptop();
            }

        }
    }
}
