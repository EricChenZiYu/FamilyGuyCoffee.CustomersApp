using System.Windows;
using System.Windows.Controls;

namespace FamilyGuyCoffee.CustomersApp.Views
{
    /// <summary>
    /// CustomersView.xaml 的交互逻辑
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //var column = (int)CustomerListGrid.GetValue(Grid.ColumnProperty);
            //var newColumn = column == 0 ? 2 : 0;
            //CustomerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            var column = Grid.GetColumn(CustomerListGrid);
            var newColumn = column == 0 ? 2 : 0;
            Grid.SetColumn(CustomerListGrid, newColumn);


        }
    }
}
