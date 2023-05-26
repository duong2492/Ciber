using Ciber.Models;

namespace Ciber.Models.Repository.Customers
{
    public interface ICustomerRepository : IDisposable
    {
        List<Customer> GetCustomers();
    }
}
