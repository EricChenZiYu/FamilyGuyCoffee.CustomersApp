using FamilyGuyCoffee.CustomersApp.Data;
using FamilyGuyCoffee.CustomersApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FamilyGuyCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //var mainWindow = new MainWindow(new MainViewModel(new CustomersViewModel(new CustomerDataProvider()), new ProductsViewModel()));
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
