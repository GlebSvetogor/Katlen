using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class UserDAL
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        //public ICollection<OrderDAL> Orders { get; set; }
        //public ICollection<CommentDAL> Comments { get; set; }
        //public ICollection<ProductDAL> Baskets { get; set; }
        //public ICollection<ProductDAL> Likes { get; set; }
    }
}
