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
    class UserRepository : IRepository<UserDAL>
    {
        private KatlenContext db;
        public UserRepository(KatlenContext db)
        {
            this.db = db;
        }
        public void Create(UserDAL user)
        {
            db.Users.Add(user);
        }

        public void Delete(int id)
        {
            UserDAL user = db.Users.Find(id);
            if(user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<UserDAL> Find(Func<UserDAL, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public UserDAL Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<UserDAL> GetAll()
        {
            return db.Users;
        }

        public void Update(UserDAL user)
        {
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
