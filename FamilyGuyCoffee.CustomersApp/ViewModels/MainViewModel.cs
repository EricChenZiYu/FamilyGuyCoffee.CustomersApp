namespace FamilyGuyCoffee.CustomersApp.ViewModels
{
    public class MainViewModel : ViewModelbase
    {
        private ViewModelbase? _selectedViewModel;
        private CustomersViewModel _customerViewModel;

        public MainViewModel(CustomersViewModel customersViewModel)
        {


            _customerViewModel = customersViewModel;
            _selectedViewModel = customersViewModel;
        }
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
    }
}
