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
    public class SeasonRepository : IRepository<Season> 
    {
        private readonly KatlenContext dbContext;
        public SeasonRepository(KatlenContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Season item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Season> GetAll()
        {
            return dbContext.Seasons;
        }

        public Season GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Season item)
        {
            throw new NotImplementedException();
        }
    }
}
