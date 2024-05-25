using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Model { get; set; }
        public string Material { get; set; }
        public Price Price { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<ProductSize> ProductSizes { get; set; } 
        public virtual ICollection<ProductSeason> ProductSeason { get; set; } 
    }
}
