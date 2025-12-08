using FamilyGuyCoffee.CustomersApp.Data;
using FamilyGuyCoffee.CustomersApp.Models;
using System.Collections.ObjectModel;

namespace FamilyGuyCoffee.CustomersApp.ViewModels
{

    public class CustomersViewModel : ViewModelbase
    {
        private readonly ICustomerDataProvider _customerDataProvider;



        private CustomerItemViewModel? _selectedCustomer;

        private NavigationSide _navigationSidee;

        public NavigationSide NavigationSidee
        {
            get => _navigationSidee;
            set
            {
                _navigationSidee = value;
                RaisePropertyChanged();
            }
        }

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged();
                }
            }
        }

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is null)
            {
                return;
            }

            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }

        internal void AddCustomer()
        {
            var newCustomer = new CustomerItemViewModel(new Customer()
            {
                FirstName = "New First Name",
                LastName = "New Last Name",
                IsDeveloper = false
            });

            Customers.Add(newCustomer);
            SelectedCustomer = newCustomer;
        }

        internal void MoveNavigation()
        {
            NavigationSidee = NavigationSidee == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

    }
    public enum NavigationSide
    {
        Left,
        Right
    }
}