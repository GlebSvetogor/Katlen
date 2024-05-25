using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class ProductSeason
    {
        public int ProductId { get; set; }
        public int SeasonId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Season Season { get; set; }
    }
}
