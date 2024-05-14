using Katlen.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.EF
{
    public class KatlenContext : DbContext
    {
        public DbSet<UserDAL> Users { get; set; }
        public DbSet<ProductDAL> Products { get; set; }
        //public DbSet<OrderDAL> Orders { get; set; }
        //public DbSet<CommentDAL> Comments { get; set; }
        public KatlenContext(DbContextOptions<KatlenContext> options) : base(options) 
        {
        }
    }
}
