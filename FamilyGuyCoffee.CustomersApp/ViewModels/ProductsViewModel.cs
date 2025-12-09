using FamilyGuyCoffee.CustomersApp.Data;
using FamilyGuyCoffee.CustomersApp.Models;
using System.Collections.ObjectModel;

namespace FamilyGuyCoffee.CustomersApp.ViewModels
{
    public class ProductsViewModel : ViewModelbase
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductsViewModel(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;

        }

        public ObservableCollection<Product> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            var products = await _productDataProvider.GetAllAsync();
            if (products != null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }
    }
}
