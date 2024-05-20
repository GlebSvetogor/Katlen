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
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.IO;

namespace Katlen.WEB.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICatalog ct;
        private readonly int pageSize = 1;

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
                PageProductsCards = items,
                ProductsCards = productsCards
            };

            HttpContext.Session.Set<List<ProductCardViewModel>>("productsCards", productsCards);


            return View(viewModel);
        }

        public IActionResult IndexDefault(int page)
        {
            List<ProductCardViewModel> productsCards = HttpContext.Session.Get<List<ProductCardViewModel>>("productsCards");

            var count = productsCards.Count();
            var items = productsCards.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                PageProductsCards = items,
                ProductsCards = productsCards
            };

            return View("Index", viewModel);
        }

        //public IActionResult Filtr(string[] names, int page = 1)
        //{
        //    List<ProductCardViewModel> productsCards = new List<ProductCardViewModel>();
        //    var products = ct.GetAllByNames(names);

        //    foreach (var product in products)
        //    {
        //        ProductCardViewModel productCard = _mapper.Map<ProductCardViewModel>(product);
        //        productCard.Image = product.Images[0];
        //        productCard.SalePercent = CountProductSale(productCard.SalePrice, productCard.FullPrice);

        //        productsCards.Add(productCard);
        //    }

        //    var count = productsCards.Count();
        //    var items = productsCards.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
        //    IndexViewModel viewModel = new IndexViewModel
        //    {
        //        PageViewModel = pageViewModel,
        //        PageProductsCards = items,
        //        ProductsCards = productsCards
        //    };

        //    return View("Index", viewModel);
        //}

        public int CountProductSale(int salePrice, int fullPrice)
        {
            int salePercent = (int)(100 - (salePrice * 100 / fullPrice));
            return salePercent;
        }

    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }
    }
}
