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
        public IEnumerable<ProductDTO> GetAll();
        public List<ProductDTO> GetAllByNames(string[] names);
        public List<ProductDTO> GetAllByPrice(int from, int to);
        public List<ProductDTO> GetAllBySizes(string[] sizes);
        public List<ProductDTO> GetAllByMaterials(string[] materials);
        //public IEnumerable<ProductDTO> GetAllBySizons(string[] sizons);
        //public IEnumerable<ProductDTO> GetAllByAges(string[] ages);

    }
}
