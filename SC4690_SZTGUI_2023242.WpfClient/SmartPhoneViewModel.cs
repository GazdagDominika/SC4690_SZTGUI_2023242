using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using SC4690_HFT_2023241.Models;

namespace SC4690_SZTGUI_2023242.WpfClient
{
    public class SmartPhoneViewModel: ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<SmartPhone> SmartPhones { get; set; }

        private SmartPhone selectedSmartPhone;

        public SmartPhone SelectedSmartPhone
        {
            get { return selectedSmartPhone; }
            set
            {
                if (value != null)
                {
                    selectedSmartPhone = new SmartPhone()
                    {
                        PhoneID = value.PhoneID,
                        PhoneName = value.PhoneName,
                        OwnerID = value.OwnerID,
                        Price = value.Price,
                        Size = value.Size,
                        Colour = value.Colour
                    };
                    OnPropertyChanged();
                    (DeleteSmartPhoneCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateSmartPhoneCommand { get; set; }
        public ICommand DeleteSmartPhoneCommand { get; set; }
        public ICommand UpdateSmartPhoneCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public SmartPhoneViewModel()
        {
            if (!IsInDesignMode)
            {
                SmartPhones = new RestCollection<SmartPhone>("http://localhost:25418/", "smartphone", "hub");
                CreateSmartPhoneCommand = new RelayCommand(() =>
                {
                    SmartPhones.Add(new SmartPhone()
                    {
                        PhoneID = SelectedSmartPhone.PhoneID,
                        PhoneName = SelectedSmartPhone.PhoneName,
                        OwnerID = SelectedSmartPhone.OwnerID,
                        Price = SelectedSmartPhone.Price,
                        Size = SelectedSmartPhone.Size,
                        Colour = SelectedSmartPhone.Colour

                    });
                });
                UpdateSmartPhoneCommand = new RelayCommand(() =>
                {
                    SmartPhones.Update(SelectedSmartPhone);
                }, () =>
                {
                    return SelectedSmartPhone != null;
                });
                DeleteSmartPhoneCommand = new RelayCommand(() =>
                {
                    SmartPhones.Delete(SelectedSmartPhone.PhoneID);
                }, () =>
                {
                    return SelectedSmartPhone != null;
                });
                SelectedSmartPhone = new SmartPhone();
            }

        }
    }
}
