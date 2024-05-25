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
    public class SizeRepository : IRepository<Size>
    {
        private readonly KatlenContext dbContext;
        public SizeRepository(KatlenContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Size item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Size> GetAll()
        {
            return dbContext.Sizes;
        }

        public Size GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Size item)
        {
            throw new NotImplementedException();
        }

    }
}
