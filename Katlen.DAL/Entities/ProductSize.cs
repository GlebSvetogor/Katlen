using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class ProductSize
    {
        public Product Product { get; set; }
        public Size Size { get; set; }
        public int IsAvailable { get; set; }
    }
}
