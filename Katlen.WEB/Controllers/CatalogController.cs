using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.DAL.Entities;
using Katlen.WEB.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICatalog ct;
        private readonly int pageSize = 9;

        public CatalogController(ICatalog ct, IMapper mapper)
        {
            this.ct = ct;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            List<ProductCardViewModel> productsCards = new List<ProductCardViewModel>();
            var products = ct.GetAll();

            foreach (var product in products)
            {
                ProductCardViewModel productCard = _mapper.Map<ProductCardViewModel>(product);
                productCard.Image = product.Images[0];
                productCard.SalePercent = CountProductSale(productCard.SalePrice, productCard.FullPrice);

                productsCards.Add(productCard);
            }

            var count = productsCards.Count();
            var items = productsCards.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                ProductCards = items
            };
            return View(viewModel);
        }

        public int CountProductSale(int salePrice, int fullPrice)
        {
            int salePercent = (int)(100 - (salePrice * 100 / fullPrice));
            return salePercent;
        }

    }
}
