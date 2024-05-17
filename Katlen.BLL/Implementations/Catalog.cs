using AutoMapper;
using Azure;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.Entities;
using Katlen.DAL.Implementations;
using Katlen.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Katlen.BLL.Implementations
{
    public class Catalog : ICatalog
    {
        UnitOfWork unitOfWork;
        public Catalog(IRepository<Product> rp)
        {
            unitOfWork = new UnitOfWork();
        }
        public IEnumerable<ProductCardDTO> GetAllByAges(string[] ages)
        {
            List<ProductCardDTO> products = new List<ProductCardDTO>();
            foreach (string age in ages)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductCardDTO>());
                var mapper = new Mapper(config);
                var list = mapper.Map<List<ProductCardDTO>>(unitOfWork.Products.GetAll().Where(b => b.Age == age));
                products.AddRange(list);
            }

            return products;
        }

        public IEnumerable<ProductCardDTO> GetAllByNames(string[] names)
        {
            List<ProductCardDTO> products = new List<ProductCardDTO>();
            foreach(string name in names)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductCardDTO>());
                var mapper = new Mapper(config);
                var list = mapper.Map<List<ProductCardDTO>>(unitOfWork.Products.GetAll().Where(b => b.Name == name));
                products.AddRange(list);
            }

            return products;    
        }

        public IEnumerable<ProductCardDTO> GetAllByPrice(int from, int to)
        {
            List<ProductCardDTO> products = new List<ProductCardDTO>();
            
            var list = unitOfWork.Prices.GetAll().Where(b => b.SalePrice >= from && b.SalePrice <= to);
            foreach (var item in list)
            {
                products.Add(unitOfWork.Products.GetById(item.Product));
            }

            return products;
        }

        public IEnumerable<ProductCardDTO> GetAllByMaterials(string[] materials)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCardDTO> GetAllBySizes(string[] sizes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCardDTO> GetAllBySizons(string[] sizons)
        {
            throw new NotImplementedException();
        }
    }
}
