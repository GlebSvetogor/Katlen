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
    public class ProductSizeRepository : IRepository<ProductSize>
    {
        private readonly KatlenContext dbContext;
        public ProductSizeRepository(KatlenContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(ProductSize item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductSize> GetAll()
        {
            return dbContext.ProductSizes;
        }

        public ProductSize GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductSize item)
        {
            throw new NotImplementedException();
        }
    }
}
