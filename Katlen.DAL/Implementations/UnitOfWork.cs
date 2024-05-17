using Katlen.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly KatlenContext dbContext = new KatlenContext();
        private ProductRepository productRepository;
        private PriceRepository priceRepository;

        public PriceRepository Prices
        {
            get
            {
                if(priceRepository == null)
                    priceRepository = new PriceRepository(dbContext);
                return priceRepository;
            }
        }

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(dbContext);
                return productRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
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
