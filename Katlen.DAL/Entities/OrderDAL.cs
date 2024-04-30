using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Katlen.DAL.Entities
{
    public class OrderDAL
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Payment { get; set; }
        public ICollection<ProductDAL> Products { get; set; }
    }
}
