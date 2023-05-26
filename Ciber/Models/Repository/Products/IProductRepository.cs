using Ciber.Models;

namespace Ciber.Models.Repository.Products
{
    public interface IProductRepository : IDisposable
    {
        List<Product> GetProducts();
    }
}
