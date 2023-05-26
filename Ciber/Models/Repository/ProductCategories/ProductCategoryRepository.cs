using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace Ciber.Models.Repository.ProductCategories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private CiberDbContext _context;

        public ProductCategoryRepository(CiberDbContext context)
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
       
        public List<ProductCategory> GetProductCategories()
        {
            return _context.ProductCategories.ToList();
        }
        public ProductCategory GetProductCategoryByID(int ProductCategoryId)
        {
            return _context.ProductCategories.Find(ProductCategoryId);
        }

        public void InsertProductCategory(ProductCategory ProductCategory)
        {
            _context.ProductCategories.Add(ProductCategory);
        }

        public void DeleteProductCategory(int ProductCategoryID)
        {
            ProductCategory ProductCategory = _context.ProductCategories.Find(ProductCategoryID);
            _context.ProductCategories.Remove(ProductCategory);
        }

        public void UpdateProductCategory(ProductCategory ProductCategory)
        {
            _context.Entry(ProductCategory).State = EntityState.Modified;
        }
    }
}
