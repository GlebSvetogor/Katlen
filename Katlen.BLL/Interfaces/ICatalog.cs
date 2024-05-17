using Katlen.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.BLL.Interfaces
{
    public interface ICatalog
    {
        public IEnumerable<ProductCardDTO> GetAllByNames(string[] names);
        public IEnumerable<ProductCardDTO> GetAllByPrice(int from, int to);
        public IEnumerable<ProductCardDTO> GetAllBySizes(string[] sizes);
        public IEnumerable<ProductCardDTO> GetAllByMaterials(string[] materials);
        public IEnumerable<ProductCardDTO> GetAllBySizons(string[] sizons);
        public IEnumerable<ProductCardDTO> GetAllByAges(string[] ages);

    }
}
