using FamilyGuyCoffee.CustomersApp.Models;

namespace FamilyGuyCoffee.CustomersApp.Data
{
    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>?> GetAllAsync();
    }
    public class ProductDataProvider : IProductDataProvider
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(100);
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Cappuccino",
                    Description = "Espresso with"
                },
                new Product()
                {
                    Name = "Black coffee",
                    Description = "sdfsdf sdf sdf "
                },
                new Product()
                {
                    Name = "Tip coffee",
                    Description = "sdfsdf sdf sdf "
                },
                new Product()
                {
                    Name = "organce coffee",
                    Description = "sdfsdf sdf sdf "
                },
            };
        }
    }
}
