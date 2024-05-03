using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using SC4690_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Windows.Input;

namespace SC4690_SZTGUI_2023242.WpfClient
{
    public class TabletViewModel: ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<SC4690_HFT_2023241.Models.Tablet> Tablets { get; set; }

        private SC4690_HFT_2023241.Models.Tablet selectedTablet;

        public SC4690_HFT_2023241.Models.Tablet SelectedTablet
        {
            get { return selectedTablet; }
            set
            {
                if (value != null)
                {
                    selectedTablet = new SC4690_HFT_2023241.Models.Tablet()
                    {
                        TabletID = value.TabletID,
                        TabletName = value.TabletName,
                        OwnerID = value.OwnerID,
                        Price = value.Price,
                        Size = value.Size,
                        Colour = value.Colour
                    };
                    OnPropertyChanged();
                    (DeleteTabletCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateTabletCommand { get; set; }
        public ICommand DeleteTabletCommand { get; set; }
        public ICommand UpdateTabletCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public TabletViewModel()
        {
            if (!IsInDesignMode)
            {
                Tablets = new RestCollection<SC4690_HFT_2023241.Models.Tablet>("http://localhost:25418/", "tablet", "hub");
                CreateTabletCommand = new RelayCommand(() =>
                {
                    Tablets.Add(new SC4690_HFT_2023241.Models.Tablet()
                    {
                        TabletID = SelectedTablet.TabletID,
                        TabletName = SelectedTablet.TabletName,
                        OwnerID = SelectedTablet.OwnerID,
                        Price = SelectedTablet.Price,
                        Size = SelectedTablet.Size,
                        Colour = SelectedTablet.Colour

                    });
                });
                UpdateTabletCommand = new RelayCommand(() =>
                {
                    Tablets.Update(SelectedTablet);
                }, () =>
                {
                    return SelectedTablet != null;
                });
                DeleteTabletCommand = new RelayCommand(() =>
                {
                    Tablets.Delete(SelectedTablet.TabletID);
                }, () =>
                {
                    return SelectedTablet != null;
                });
                SelectedTablet = new SC4690_HFT_2023241.Models.Tablet();
            }

        }
    }
}
