using FamilyGuyCoffee.CustomersApp.Models;

namespace FamilyGuyCoffee.CustomersApp.Data
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
    }
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            await Task.Delay(100);
            return new List<Customer>
            {
                new Customer()
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Griffin",
                    IsDeveloper = false
                },
                new Customer()
                {
                    Id = 2,
                    FirstName = "Lois",
                    LastName = "Griffin",
                    IsDeveloper = true
                },
                new Customer()
                {
                    Id = 3,
                    FirstName = "Stewie",
                    LastName = "Griffin",
                    IsDeveloper = false
                },
                new Customer()
                {
                    Id = 4,
                    FirstName = "Brian",
                    LastName = "Griffin",
                    IsDeveloper = true
                },
                new Customer()
                {
                    Id = 5,
                    FirstName = "Chris",
                    LastName = "Griffin",
                    IsDeveloper = false

                }
            };
        }
    }
}
