using System.Windows.Controls;

namespace FamilyGuyCoffee.CustomersApp.Views
{
    /// <summary>
    /// CustomersView.xaml 的交互逻辑
    /// </summary>
    public partial class CustomersView : UserControl
    {
        //private CustomersViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            //_viewModel = new CustomersViewModel(new CustomerDataProvider());
            //DataContext = _viewModel;
            //Loaded += CustomersView_Loaded;
        }

        //private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        //{
        //    await _viewModel.LoadAsync();
        //}
        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    //var column = (int)CustomerListGrid.GetValue(Grid.ColumnProperty);
        //    //var newColumn = column == 0 ? 2 : 0;
        //    //CustomerListGrid.SetValue(Grid.ColumnProperty, newColumn);

        //    //var column = Grid.GetColumn(CustomerListGrid);
        //    //var newColumn = column == 0 ? 2 : 0;
        //    //Grid.SetColumn(CustomerListGrid, newColumn);

        //    _viewModel.MoveNavigation();


        //}

        //private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        //{

        //    _viewModel.AddCustomer();
        //}
    }
}
