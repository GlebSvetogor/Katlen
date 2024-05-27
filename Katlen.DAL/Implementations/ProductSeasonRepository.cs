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
    public class ProductSeasonRepository : IRepository<ProductSeason>
    {
        private readonly KatlenContext dbContext;
        public ProductSeasonRepository(KatlenContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(ProductSeason item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductSeason> GetAll()
        {
            return dbContext.ProductSeasons;
        }

        public ProductSeason GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductSeason item)
        {
            throw new NotImplementedException();
        }
    }
}
