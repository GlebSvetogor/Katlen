using AutoMapper;
using Azure;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.DAL.Implementations;
using Katlen.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private readonly string[] filtrNames = new string[]{"Костюм", "Платье", "Комплект"};
        private readonly string[] filtrSizes = new string[]{"XS", "S", "M", "L", "XL", "XXL"};
        private readonly string[] filtrMaterials = new string[]{"Шелк", "Ткань", "Синтетика"};
        private readonly string[] filtrSeasons = new string[]{"Лето", "Осень", "Зима", "Весна"};
        public Catalog(KatlenContext db, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return GetProducts(p => true);

        }

        public List<ProductDTO> GetAllByNames(string[] names)
        {
            return GetProducts(item => names.Any(name => item.Name.Contains(name)));

        }
        public List<ProductDTO> GetAllByPrice(int from, int to)
        {
            return GetProducts(item => item.Price.SalePrice >= from && item.Price.SalePrice <= to);
        }
        public List<ProductDTO> GetAllBySizes(string[] sizes)
        {
            var sizesIdentifiers = unitOfWork.Sizes.GetAll()
                .Where(size => sizes.Any(sizeValue => size.SizeValue == sizeValue))
                .Select(size => size.Id)
                .ToList();

            var productsIdentifiers = unitOfWork.ProductSizes.GetAll()
                .Where(productSize => sizesIdentifiers.Contains(productSize.SizeId))
                .Select(productSize => productSize.ProductId)
                .ToList();

            return GetProducts(p => productsIdentifiers.Contains(p.Id));
        }
        public List<ProductDTO> GetAllByMaterials(string[] materials)
        {
            return GetProducts(item => materials.Contains(item.Material));
        }

        public List<ProductDTO> GetAllBySeasons(string[] seasons)
        {
            if (seasons.Contains("allSeasons"))
            {
                return GetProducts(p => p.ProductSeason.Any());
            }
            else
            {
                var seasonsIdentifiers = unitOfWork.Seasons.GetAll()
                    .Where(season => seasons.Contains(season.Name))
                    .Select(season => season.Id)
                .ToList();


                var productsIdentifiers = unitOfWork.ProductSeasons.GetAll()
                    .Where(productSeason => seasonsIdentifiers.Contains(productSeason.SeasonId))
                    .Select(productSeason => productSeason.ProductId)
                .ToList();


                return GetProducts(p => productsIdentifiers.Contains(p.Id));
            }
        }
        public List<ProductDTO> GetAllByNew()
        {
            return GetProducts(p => true).AsEnumerable().Reverse().ToList();
        }

        public List<ProductDTO> GetAllByRate()
        {
            return GetProducts(p => true).OrderByDescending(p => p.Rate).ToList();
        }

        public List<ProductDTO> GetAllByCategory(string value)
        {
            //return GetProducts(p => p.Category == value).OrderByDescending(p => p.Rate).ToList();
            return null;
        }

        public List<ProductDTO> MakeFiltr(string[] names = null, int priceFrom = 0, int priceTo = 0, string[] sizes = null, string[] materials = null, string[] seasons = null)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            if (names != null)
            {
                if(products.Count() < 1)
                {
                    products = GetAllByNames(names);
                }
                else
                {
                    var filtrProducts = GetAllByNames(names);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id));
                }
            }

            if (priceFrom != priceTo)
            {
                if(products.Count() < 1)
                {
                    products = GetAllByPrice(priceFrom, priceTo);
                }
                else
                {
                    var filtrProducts = GetAllByPrice(priceFrom, priceTo);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id));
                }
            }

            if (sizes != null)
            {
                if(products.Count() < 1)
                {
                    products = GetAllBySizes(sizes);
                }
                else
                {
                    var filtrProducts = GetAllBySizes(sizes);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id));
                }
            }

            if (materials != null)
            {
                if(products.Count() < 1)
                {
                    products = GetAllByMaterials(materials);
                }
                else
                {
                    var filtrProducts = GetAllByMaterials(materials);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id));
                }
            }

            if (seasons != null)
            {
                if(products.Count() < 1)
                {
                    products = GetAllBySeasons(seasons);
                }
                else
                {
                    var filtrProducts = GetAllBySeasons(seasons);
                    products.RemoveAll(product => !filtrProducts.Any(fp => fp.Id == product.Id));
                }
            }

            return products;
        }

        public ProductDTO GetProductById(int id)
        {
            return GetProducts(p =>  p.Id == id).FirstOrDefault();
        }

        private List<ProductDTO> GetProducts(Func<Product, bool> predicate)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var list = unitOfWork.Products.GetAll()
                .Include(p => p.Images)
                .Include(p => p.Price)
                .Include(p => p.ProductSeason)
                    .ThenInclude(c => c.Season)
                .Include(p => p.ProductSizes)
                    .ThenInclude(c => c.Size)
                .Where(predicate);

            BindTables(list, products);

            return products;
        }

        public void BindTables(IEnumerable<Product> list, List<ProductDTO> products)
        {
            foreach (var item in list)
            {
                List<string> imgSources = new List<string>();
                List<string> sizes = new List<string>();
                List<string> sizesAreAvailable = new List<string>();
                List<int> sizesIds = new List<int>();
                List<string> seasons = new List<string>();

                imgSources = item.Images.Select(image => image.ImageSource).ToList();

                foreach (var productSize in item.ProductSizes)
                {
                    sizes.Add(productSize.Size.SizeValue);
                    if (productSize.IsSizeAvailable == 1)
                    {
                        sizesAreAvailable.Add(productSize.Size.SizeValue);
                        sizesIds.Add(productSize.Size.Id);
                    }
                }

                foreach (var productSeason in item.ProductSeason)
                {
                    seasons.Add(productSeason.Season.Name);
                }

                sizesIds.Sort();
                ProductDTO product = _mapper.Map<ProductDTO>(item);
                product.Images = imgSources;
                product.Sizes = sizes;
                product.SizesAreAvailable = sizesAreAvailable;
                product.SalePrice = item.Price.SalePrice;
                product.FullPrice = item.Price.FullPrice;
                product.MinimumAvailableSize = sizesIds.Count > 0 ? sizesIds[0] : -1;
                product.Seasons = seasons;

                products.Add(product);
            }
        }

        public Dictionary<string, string> GetFiltr(string[] names = null, int priceFrom = 0, int priceTo = 0, string[] sizes = null, string[] materials = null, string[] seasons = null)
        {
            Dictionary<string, string> filtrs = new();
            foreach (var name in filtrNames)
            {
                filtrs[name] = "false";
                if (names != null)
                {
                    if (names.Contains(name)) { filtrs[name] = "true"; }
                }
            }

            if(priceFrom != 0) { filtrs["priceFrom"] = priceFrom.ToString(); }
            else { filtrs["priceFrom"] = "false"; }

            if (priceTo != 0) { filtrs["priceTo"] = priceTo.ToString(); }
            else { filtrs["priceTo"] = "false"; }

            foreach (var size in filtrSizes)
            {
                filtrs[size] = "false";
                if (sizes != null)
                {
                    if (sizes.Contains(size)) { filtrs[size] = "true"; }
                }
            }

            foreach (var material in filtrMaterials)
            {
                filtrs[material] = "false";
                if(materials != null)
                {
                    if (materials.Contains(material)) { filtrs[material] = "true"; } 
                }
            }

            foreach (var season in filtrSeasons)
            {
                filtrs[season] = "false";
                if(seasons != null)
                {
                    if (seasons.Contains(season)) { filtrs[season] = "true"; } 
                }
            }

            return filtrs;
        }

        public Dictionary<string, string> InitFiltrs()
        {
            Dictionary<string, string> filtrs = new();
            foreach (var name in filtrNames)
            {
                filtrs[name] = "false"; 
            }

            filtrs["priceFrom"] = "false"; 
            filtrs["priceTo"] = "false"; 

            foreach (var size in filtrSizes)
            {
                filtrs[size] = "false"; 
            }

            foreach (var material in filtrMaterials)
            {
                filtrs[material] = "false"; 
            }

            foreach (var season in filtrSeasons)
            {
                filtrs[season] = "false"; 
            }

            return filtrs;
        }

    }
}
