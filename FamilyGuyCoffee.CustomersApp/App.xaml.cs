using FamilyGuyCoffee.CustomersApp.Data;
using FamilyGuyCoffee.CustomersApp.ViewModels;
using System.Windows;

namespace FamilyGuyCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow(new MainViewModel(new CustomersViewModel(new CustomerDataProvider()), new ProductsViewModel()));
            mainWindow.Show();
        }
    }

}
