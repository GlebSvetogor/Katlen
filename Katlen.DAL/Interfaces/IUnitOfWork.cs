using Katlen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserDAL> Users { get; }
        IRepository<ProductDAL> Products { get; }
        void Save();
    }
}
