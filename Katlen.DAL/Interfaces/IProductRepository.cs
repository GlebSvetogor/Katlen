using Katlen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        public IEnumerable<ProductDAL> GetAll();
        public ProductDAL Get(int id);
        public IEnumerable<ProductDAL> FindAllByName(IEnumerable<string> names);
        public IEnumerable<ProductDAL> FindAllByPrice(double[] price);
        public IEnumerable<ProductDAL> FindAllBySize(IEnumerable<string> sizes);
        public IEnumerable<ProductDAL> FindAllByMaterial(IEnumerable<string> materials);
        public IEnumerable<ProductDAL> SortByPrice();
        public IEnumerable<ProductDAL> SortBySize();
        public void Save();
    }
}
