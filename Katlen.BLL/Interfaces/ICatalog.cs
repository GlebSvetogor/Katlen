using AutoMapper;
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
        public IEnumerable<ProductDTO> GetAllByName(IEnumerable<string> names);
        public IEnumerable<ProductDTO> GetAllByPrice(double[] price);
        public IEnumerable<ProductDTO> GetAllBySize(IEnumerable<string> sizes);
        public IEnumerable<ProductDTO> GetAllByMaterial(IEnumerable<string> materials);
        public IEnumerable<ProductDTO> SortByPrice();
        public IEnumerable<ProductDTO> SortBySize();
        public IEnumerable<ProductDTO> GetAllProducts();
        
    }
}
