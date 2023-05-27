using Ciber.Models.Repository.Orders;

namespace Ciber.Models.View
{
    public class CreateOrderViewModel
    {
        public OrderDTO Order { get; set; }
        public List<Product> ProductList { get; set; }
        public List<Customer> CustomerList { get; set; }
    }
}