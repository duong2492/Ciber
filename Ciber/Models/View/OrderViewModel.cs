using Ciber.Models.Repository.Orders;

namespace Ciber.Models.View
{
    public class OrderViewModel
    {
        public List<OrderDTO> OrderList { get; set; }

        public List<ProductCategory> CategoryProductList { get; set; }
    }
}