using FamilyGuyCoffee.CustomersApp.Commands;

namespace FamilyGuyCoffee.CustomersApp.ViewModels
{
    public class MainViewModel : ViewModelbase
    {
        private ViewModelbase? _selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            ProductsViewModel = productsViewModel;
            CustomerViewModel = customersViewModel;
            _selectedViewModel = CustomerViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public ProductsViewModel ProductsViewModel { get; }
        public CustomersViewModel CustomerViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }

        public ViewModelbase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {

                if (_selectedViewModel != value)
                {
                    _selectedViewModel = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is null)
            {
                return;
            }
            await SelectedViewModel.LoadAsync();

        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelbase;
            await LoadAsync();
        }

    }
}
