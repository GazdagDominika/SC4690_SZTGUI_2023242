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
    public class OwnerViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Owner> Owners { get; set; }

        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set
            {
                if (value != null)
                {
                    selectedOwner = new Owner()
                    {
                        Age = value.Age,
                        Name = value.Name,
                        PhoneNumber = value.PhoneNumber,
                        OwnerID = value.OwnerID,
                        Salary = value.Salary
                    };
                    OnPropertyChanged();
                    (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public OwnerViewModel()
        {
            if (!IsInDesignMode)
            {
                Owners = new RestCollection<Owner>("http://localhost:25418/", "owner", "hub");
                CreateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Add(new Owner()
                    {
                        Age = SelectedOwner.Age,
                        Name = SelectedOwner.Name,
                        PhoneNumber = SelectedOwner.PhoneNumber,
                        OwnerID = SelectedOwner.OwnerID,
                        Salary = SelectedOwner.Salary

                    });
                });
                UpdateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Update(SelectedOwner);
                }, () =>
                {
                    return SelectedOwner != null;
                });
                DeleteOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Delete(SelectedOwner.OwnerID);
                }, () =>
                {
                    return SelectedOwner != null;
                });
                SelectedOwner = new Owner();
            }

        }
    }
}
