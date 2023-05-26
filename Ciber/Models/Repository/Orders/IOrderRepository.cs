namespace Ciber.Models.Repository.Orders
{
    public interface IOrderRepository : IDisposable
    {
        List<OrderDTO> GetAllOrders(int ProductCategory_ID);
        int? CountOrder();
        int? ProductLeft(int Product_ID);
        void InsertOrder(Order order);
        void Save();
    }
}
