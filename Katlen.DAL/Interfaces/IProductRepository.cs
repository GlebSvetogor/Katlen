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
        public IEnumerable<Product> GetAll();
        public Product Get(int id);
        public IEnumerable<Product> FindAllByName(IEnumerable<string> names);
        public IEnumerable<Product> FindAllByPrice(double[] price);
        public IEnumerable<Product> FindAllBySize(IEnumerable<string> sizes);
        public IEnumerable<Product> FindAllByMaterial(IEnumerable<string> materials);
        public IEnumerable<Product> SortByPrice();
        public IEnumerable<Product> SortBySize();
        public void Save();
    }
}
