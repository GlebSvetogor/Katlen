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
        public List<ProductDTO> GetAllBySeasons(string[] seasons);
        public List<ProductDTO> GetAllByNew();
        public List<ProductDTO> GetAllByRate();
        public List<ProductDTO> GetAllByCategory(string category);
        public List<ProductDTO> MakeFiltr(string[] names = null, int priceFrom = 0, int priceTo = 0, string[] sizes = null, string[] materials = null, string[] seasons = null);
        public Dictionary<string, string> GetFiltr(string[] names = null, int priceFrom = 0, int priceTo = 0, string[] sizes = null, string[] materials = null, string[] seasons = null);
        public Dictionary<string, string> InitFiltrs();


    }
}
