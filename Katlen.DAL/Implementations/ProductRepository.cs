using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Implementations
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly KatlenContext dbContext;
        public ProductRepository(KatlenContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<Product> GetAll()
        {
            return dbContext.Products;
        }

        public Product GetById(int id)
        {
            return dbContext.Products.Find(id);
        }
        public void Create(Product item)
        {
            dbContext.Products.Add(item);
        }

        public void Update(Product item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Product product = dbContext.Products.Find(id);
            if (product != null)
                dbContext.Products.Remove(product);
        }
    }
}
