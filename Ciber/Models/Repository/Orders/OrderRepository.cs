using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Ciber.Models.Repository.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private CiberDbContext _context;

        public OrderRepository(CiberDbContext context)
        {
            this._context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public List<OrderDTO> GetOrdersList(int ProductCategory_ID)
        {
            var query = (from order in _context.Orders.Where(x => x.Status == 1)
                         join product in _context.Products
                         .Where(x => x.Status == 1)
                         on order.ProductId equals product.ProductId
                         join productCategory in _context.ProductCategories.Where(x => x.Status == 1)
                         on product.ProductCategoryId equals productCategory.ProductCategoryId
                         join customer in _context.Customers.Where(x => x.Status == 1) on order.CustomerId equals customer.CustomerId
                         orderby order.OrderDate descending
                         select new OrderDTO
                         {
                             OrderId = order.OrderId,
                             OrderName = order.OrderName,
                             CustomerName = customer.Name,
                             ProductName = product.Name,
                             ProductCategory_ID = product.ProductCategoryId,
                             ProductCategoryName = productCategory.Name,
                             OrderDate = DateTime.Parse(order.OrderDate.ToString()).ToString("dd/MM/yyyy"),
                             Amount = order.Amount,
                             Status = order.Status,
                         });
            if (ProductCategory_ID > 0)
            {
                query = query.Where(x => x.ProductCategory_ID == ProductCategory_ID);
            }
            return query.ToList();
        }
        public void InsertOrder(Order order)
        {
            _context.Orders.Add(order);
        }
        public int? CountOrder()
        {
            var listOrder = _context.Orders.Where(x => x.Status == 1);
            return listOrder.Sum(x => x.Amount);
        }
        public int? ProductLeft(int ProductID)
        {
            var quantity = _context.Products.Find(ProductID).Quantity;
            var countSold = _context.Orders.Where(x => x.Status == 1).Sum(x=>x.Amount);
            return (quantity - countSold);
        }
    }
}
