using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace Ciber.Models.Repository.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private CiberDbContext _context;

        public CustomerRepository(CiberDbContext context)
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
       
        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

      
    }
}
