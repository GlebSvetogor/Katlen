using Katlen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Model { get; set; }
        public string Material { get; set; }
        public int SalePrice { get; set; }
        public int FullPrice { get; set; }
        public List<string> Images { get; set; } 
        public List<string> Sizes { get; set; } 
        public List<string> SizesAreAvailable { get; set; } 

    }
}
