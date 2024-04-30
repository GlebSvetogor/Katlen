using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.BLL.DTO
{
    public class SearchProductDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Sale { get; set; }
        public string Name { get; set; }
        public string ImgSource { get; set; }
    }
}
