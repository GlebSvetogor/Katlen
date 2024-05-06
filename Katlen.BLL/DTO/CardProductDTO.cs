using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.BLL.DTO
{
    public class CardProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Model { get; set; }
        public string Tall { get; set; }
        public Dictionary<string, bool> Sizes { get; set; }
        public string Material { get; set; }
        public string ImgSource { get; set; }
        public int Price { get; set; }
        public int FullPrice { get; set; }
    }
}
