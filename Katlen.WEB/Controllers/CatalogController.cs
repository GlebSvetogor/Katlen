using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController
        private readonly ICatalog ct;
        private readonly KatlenContext db;
        private readonly int PageSize = 9;

        public CatalogController(ICatalog ct, KatlenContext db)
        {
            this.ct = ct;   
            this.db = db;
        }

        //public async Task<IActionResult> Index(int page = 1)
        //{
        //    // Создание конфигурации сопоставления
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
        //    // Настройка AutoMapper
        //    var mapper = new Mapper(config);
        //    // сопоставление
        //    var products = mapper.Map<IEnumerable<ProductViewModel>>(ct.GetAllProducts());

        //    CountProductSale(products);

        //    var viewModel = GetCatalogViewModel(products, page);

        //    return View(viewModel);
        //}

        [HttpGet]
        public IActionResult Index(bool isCostum = false, bool isDress = false, bool isComplect = false, string priceFrom = null, string priceTo = null, bool smallSize = false, bool middleSize = false, bool bigSize = false, bool isShelkMaterial = false,bool isTextileMaterial = false, bool isMeshMaterial = false, int page = 1)
        {
            List<bool> closeFiltr = new() { isCostum, isDress, isComplect };
            List<string> priceFiltr = new() { priceFrom, priceTo };
            List<bool> sizeFiltr = new() { smallSize, middleSize, bigSize};
            List<bool> materialFiltr = new() { isShelkMaterial, isTextileMaterial, isMeshMaterial};
            List<ProductViewModel> products = new();

            if(closeFiltr.Any(item => item == true))
            {
                List<string> closeKeyNames = new List<string>();
                if(isCostum) { closeKeyNames.Add("Костюм"); }
                if(isDress) { closeKeyNames.Add("Платье"); }
                if(isComplect) { closeKeyNames.Add("Комплект"); }
                // Создание конфигурации сопоставления
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
                // Настройка AutoMapper
                var mapper = new Mapper(config);
                // сопоставление
                var closeProducts = mapper.Map<IEnumerable<ProductViewModel>>(ct.GetAllByName(closeKeyNames));

                if(products.Count > 0) 
                {
                    foreach(var product in products)
                    {
                        if (!closeProducts.Contains(product))
                        {
                            products.Remove(product);
                        }
                    }
                }
                else { products.AddRange(closeProducts); }
            }

            //if (priceFiltr.Any(item => item != null))
            //{
            //    List<string> prices = new List<string>();
            //    if (priceFrom != null) { prices.Add(priceFrom); }
            //    if (priceTo != null) { prices.Add(priceTo); }
            //    // Создание конфигурации сопоставления
            //    var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            //    // Настройка AutoMapper
            //    var mapper = new Mapper(config);
            //    // сопоставление
            //    var closeProducts = mapper.Map<IEnumerable<ProductViewModel>>(ct.GetAllByPrice(prices));

            //    if (products.Count > 0)
            //    {
            //        foreach (var product in products)
            //        {
            //            if (!closeProducts.Contains(product))
            //            {
            //                products.Remove(product);
            //            }
            //        }
            //    }
            //    else { products.AddRange(closeProducts); }
            //}

            if (products.IsNullOrEmpty())
            {
                // Создание конфигурации сопоставления
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
                // Настройка AutoMapper
                var mapper = new Mapper(config);
                // сопоставление
                var allProducts = mapper.Map<IEnumerable<ProductViewModel>>(ct.GetAllProducts());

                products.AddRange(allProducts);
            }

            CountProductSale(products);

            var viewModel = GetCatalogViewModel(products, page);

            return View(viewModel);
        }

        public CatalogViewModel GetCatalogViewModel(IEnumerable<ProductViewModel> products, int page)
        {
            var count = products.Count();
            var items = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, PageSize);
            CatalogViewModel viewModel = new CatalogViewModel
            {
                PageViewModel = pageViewModel,
                Products = items
            };

            return viewModel;
        }

        public void CountProductSale(IEnumerable<ProductViewModel> products)
        {
            foreach (var product in products)
            {
                product.SalePercent = (int)(100 - (product.Price * 100 / product.FullPrice));
            }
        }

    }
}
