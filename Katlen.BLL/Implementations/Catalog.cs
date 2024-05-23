using AutoMapper;
using Azure;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.DAL.Implementations;
using Katlen.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;

namespace Katlen.BLL.Implementations
{
    public class Catalog : ICatalog
    {
        private readonly IMapper _mapper;
        UnitOfWork unitOfWork;
        public Catalog(KatlenContext db, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var list = unitOfWork.Products.GetAll()
                .Include(p => p.Images)
                .Include(p => p.Price)
                .Include(p => p.ProductSizes)
                    .ThenInclude(c => c.Size);
                    
            BindTables(list, products);

            return products;

        }

        public List<ProductDTO> GetAllByNames(string[] names)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            
            var list = unitOfWork.Products.GetAll()
                .Where(item => names.Any(name => item.Name.Contains(name)))
                .Include(p => p.Images)
                .Include(p => p.Price)
                .Include(p => p.ProductSizes)
                .ThenInclude(c => c.Size)
                .ToList();

            BindTables(list, products);

            return products;

        }
        public List<ProductDTO> GetAllByPrice(int from, int to)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            var list = unitOfWork.Products.GetAll().Where(item => item.Price.SalePrice >= from && item.Price.SalePrice <= to)
                .Include(p => p.Images)
                .Include(p => p.Price)
                .Include(p => p.ProductSizes)
                    .ThenInclude(c => c.Size);

            BindTables(list, products);

            return products;
        }
        public List<ProductDTO> GetAllBySizes(string[] sizes)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            var sizesIdentifiers = unitOfWork.Sizes.GetAll().Where(size => sizes.Any(sizeValue => size.SizeValue == sizeValue)).Select(size => size.Id);
            var productsIdentifiers = unitOfWork.ProductSizes.GetAll().Where(productSize => sizesIdentifiers.Any(sizeId => sizeId == productSize.SizeId)).Select(productSize => productSize.ProductId);
            var list = unitOfWork.Products.GetAll().Where(product => productsIdentifiers.Any(productId => product.Id == productId))
                .Include(p => p.Images)
                .Include(p => p.Price)
                .Include(p => p.ProductSizes)
                    .ThenInclude(c => c.Size);

            BindTables(list, products);

            return products;
        }
        public List<ProductDTO> GetAllByMaterials(string[] materials)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            var list = unitOfWork.Products.GetAll()
                .Where(product => materials.Any(material => product.Material == material))
                .Include(p => p.Images)
                .Include(p => p.Price)
                .Include(p => p.ProductSizes)
                .ThenInclude(c => c.Size)
                .ToList();

            BindTables(list, products);

            return products;
        }
        //public IEnumerable<ProductDTO> GetAllByAges(string[] ages)
        //{

        //}




        //public IEnumerable<ProductDTO> GetAllBySizons(string[] sizons)
        //{

        //}


        public void BindTables(IEnumerable<Product> list, List<ProductDTO> products)
        {
            foreach (var item in list)
            {
                List<string> imgSources = new List<string>();
                List<string> sizes = new List<string>();
                List<string> sizesAreAvailable = new List<string>();
                imgSources = item.Images.Select(image => image.ImageSource).ToList();

                foreach (var productSize in item.ProductSizes)
                {
                    sizes.Add(productSize.Size.SizeValue);
                    if (productSize.IsSizeAvailable == 1)
                    {
                        sizesAreAvailable.Add(productSize.Size.SizeValue);
                    }
                }

                ProductDTO product = _mapper.Map<ProductDTO>(item);
                product.Images = imgSources;
                product.Sizes = sizes;
                product.SizesAreAvailable = sizesAreAvailable;
                product.SalePrice = item.Price.SalePrice;
                product.FullPrice = item.Price.FullPrice;

                products.Add(product);
            }
        }

    }
}
