using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class CommentDAL
    {
        public UserDAL User { get; set; }
        public string Text { get; set; }
    }
}
