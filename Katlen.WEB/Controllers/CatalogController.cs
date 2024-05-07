using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController
        private readonly ICatalog ct;
        private readonly KatlenContext db;

        public CatalogController(ICatalog ct, KatlenContext db)
        {
            this.ct = ct;   
            this.db = db;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<IEnumerable<ProductViewModel>>(ct.GetAllProducts());

            foreach (var product in products)
            {
                product.SalePercent = (int)(100 - (product.Price * 100 / product.FullPrice));
            }

            int pageSize = 9;

            var count = products.Count();
            var items = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            CatalogViewModel viewModel = new CatalogViewModel
            {
                PageViewModel = pageViewModel,
                Products = items
            };

            return View(viewModel);
        }

    }
}
