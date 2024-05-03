using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Katlen.BLL.Implementations
{
    public class CatalogBL : ICatalog
    {
        private readonly KatlenContext db;
        private readonly IProductRepository pr;

        public CatalogBL(KatlenContext db, IProductRepository pr)
        {
            this.db = db;
            this.pr = pr;
        }
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDAL, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductDTO>>(pr.GetAll());

            return products;
        }
        public IEnumerable<ProductDTO> GetAllByName(IEnumerable<string> names)
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDAL, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductDTO>>(pr.FindAllByName(names));

            return products;
        }

        public IEnumerable<ProductDTO> GetAllByPrice(double[] price)
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDAL, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductDTO>>(pr.FindAllByPrice(price));

            return products;
        }

        public IEnumerable<ProductDTO> GetAllBySize(IEnumerable<string> sizes)
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDAL, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductDTO>>(pr.FindAllBySize(sizes));

            return products;
        }

        public IEnumerable<ProductDTO> GetAllByMaterial(IEnumerable<string> materials)
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDAL, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductDTO>>(pr.FindAllByMaterial(materials));

            return products;
        }

        public IEnumerable<ProductDTO> SortByPrice()
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDAL, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductDTO>>(pr.SortByPrice());

            return products;
        }

        public IEnumerable<ProductDTO> SortBySize()
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDAL, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductDTO>>(pr.SortBySize());

            return products;
        }

    }
}
