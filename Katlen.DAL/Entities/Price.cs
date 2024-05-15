using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public int SalePrice { get; set; }
        public int FullPrice { get; set; }
    }
}
