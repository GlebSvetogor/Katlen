using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class ProductSize
    {
        public Product ProductId { get; set; }
        public Size SizeId { get; set; }
        public int IsAvailable { get; set; }
    }
}
