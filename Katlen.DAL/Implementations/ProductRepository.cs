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
    public class ProductRepository : IProductRepository
    {
        private KatlenContext db;
        public ProductRepository(KatlenContext db)
        {
            this.db = db;
        }

        public IEnumerable<ProductDAL> GetAll()
        {
            return db.Products;
        }

        public ProductDAL Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<ProductDAL> FindAllByName(IEnumerable<string> names)
        {
            List<ProductDAL> products = new List<ProductDAL>();
            foreach (string name in names)
            {
                var selectedProducts = from p in db.Products where p.Name.Contains(name) select p;
                products.AddRange(selectedProducts);
            }
            return products;
        }

        public IEnumerable<ProductDAL> FindAllByPrice(double[] price)
        {
            var selectedProducts = from p in db.Products where p.Price > price[0] && p.Price < price[1] select p;
            return selectedProducts;
        }

        public IEnumerable<ProductDAL> FindAllBySize(IEnumerable<string> sizes)
        {
            List<ProductDAL> products = new List<ProductDAL>();
            foreach (string size in sizes)
            {
                var selectedProducts = from p in db.Products where p.Sizes.Contains(size) select p;
                products.AddRange(selectedProducts);
            }
            return products;
        }

        public IEnumerable<ProductDAL> FindAllByMaterial(IEnumerable<string> materials)
        {
            List<ProductDAL> products = new List<ProductDAL>();
            foreach (string material in materials)
            {
                var selectedProducts = from p in db.Products where p.Material.Contains(material) select p;
                products.AddRange(selectedProducts);
            }
            return products;
        }

        public IEnumerable<ProductDAL> SortByPrice()
        {
            var sortedProducts = db.Products.OrderBy(p => p.Price);
            return sortedProducts;
        }

        public IEnumerable<ProductDAL> SortBySize()
        {
            var sortedProducts = db.Products.OrderBy(p => p.Sizes);
            return sortedProducts;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
