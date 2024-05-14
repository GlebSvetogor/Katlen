using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class CommentDAL
    {
        public int Id { get; set; }
        //public UserDAL User { get; set; }
        //public ProductDAL Product { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
    }
}