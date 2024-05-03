using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController
        private readonly ICatalog ct;

        public CatalogController(ICatalog ct)
        {
            this.ct = ct;   
        }

        public ActionResult Index()
        {
            // Создание конфигурации сопоставления
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var products = mapper.Map<List<ProductViewModel>>(ct.GetAllProducts());

            foreach (var product in products)
            {
                product.SalePercent = (int)(100 - (product.Price * 100 / product.FullPrice));
            }

            return View(products);
        }

        // GET: CatalogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
