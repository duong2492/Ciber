using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace Ciber.Models.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private CiberDbContext _context;

        public ProductRepository(CiberDbContext context)
        {
            this._context = context;
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
       
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
