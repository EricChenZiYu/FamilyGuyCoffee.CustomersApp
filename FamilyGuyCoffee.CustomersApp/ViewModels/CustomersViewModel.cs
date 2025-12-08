using FamilyGuyCoffee.CustomersApp.Commands;
using FamilyGuyCoffee.CustomersApp.Data;
using FamilyGuyCoffee.CustomersApp.Models;
using System.Collections.ObjectModel;

namespace FamilyGuyCoffee.CustomersApp.ViewModels
{

    public class CustomersViewModel : ViewModelbase
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }

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

        public bool HasCustomerSelected => SelectedCustomer is not null;
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(HasCustomerSelected));
                    DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(AddCustomer);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
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

        private void AddCustomer(object? parameter)
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

        private void MoveNavigation(object? parameter)
        {
            NavigationSidee = NavigationSidee == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }
        private bool CanDelete(object? parameter)
        {
            return SelectedCustomer is not null;
        }

        private void Delete(object? parameter)
        {
            if (SelectedCustomer is null)
            {
                return;
            }
            Customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }

    }
    public enum NavigationSide
    {
        Left,
        Right
    }
}