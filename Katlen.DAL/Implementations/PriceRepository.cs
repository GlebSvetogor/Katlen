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
    public class PriceRepository : IRepository<Price>
    {
        private readonly KatlenContext dbContext;
        public PriceRepository(KatlenContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Price> GetAll()
        {
            return dbContext.Prices;
        }

        public Price GetById(int id)
        {
            return dbContext.Prices.Find(id);
        }
        public void Create(Price item)
        {
            dbContext.Prices.Add(item);
        }

        public void Update(Price item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Price price = dbContext.Prices.Find(id);
            if (price != null)
                dbContext.Prices.Remove(price);
        }
    }
}
