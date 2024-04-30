using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Implementations
{
    public class ProductRepository : IRepository<ProductDAL>
    {
        private KatlenContext db;
        public ProductRepository(KatlenContext db)
        {
            this.db = db;
        }
        public void Create(ProductDAL product)
        {
            db.Products.Add(product);
        }

        public void Delete(int id)
        {
            ProductDAL product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
            }
        }

        public IEnumerable<ProductDAL> Find(Func<ProductDAL, bool> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public ProductDAL Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<ProductDAL> GetAll()
        {
            return db.Products;
        }

        public void Update(ProductDAL product)
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
