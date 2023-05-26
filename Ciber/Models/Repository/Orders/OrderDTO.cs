namespace Ciber.Models.Repository.Orders
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string? OrderName { get; set; }
        public string? CustomerName { get; set; }
        public int? Customer_ID { get; set; }
        public string? ProductName { get; set; }
        public int? Product_ID { get; set; }
        public string? ProductCategoryName { get; set; }
        public int? ProductCategory_ID { get; set; }
        public string? CreateDate { get; set; }
        public string? OrderDate { get; set; }
        public int? Amount { get; set; }
        public int? Status { get; set; }

    }
}
