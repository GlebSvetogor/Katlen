using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.BLL.Interfaces;
using Katlen.DAL.EF;
using Katlen.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.BLL.Implementations
{
    public class CardProductBL : ICardProduct
    {
        private readonly IProductRepository pr;

        public CardProductBL(IProductRepository pr)
        {
            this.pr = pr;
        }
        public CardProductDTO GetCardProductById(int id)
        {
            var product = pr.Get(id);
            if (product is not null)
            {
                var cardProduct = new CardProductDTO();
                cardProduct.Id = product.Id;
                cardProduct.Name = product.Name;
                cardProduct.Rate = product.Rate;
                cardProduct.Price = product.Price;
                cardProduct.Tall = product.Tall;
                cardProduct.Material = product.Material;
                cardProduct.ImgSource = product.ImgSource;
                cardProduct.FullPrice = product.FullPrice;
                cardProduct.Model = product.Model;


                //var config = new MapperConfiguration(cfg => cfg.CreateMap<CardProductDTO, ProductDTO>());
                //// Настройка AutoMapper
                //var mapper = new Mapper(config);
                //// сопоставление
                //var cardProduct = mapper.Map<CardProductDTO>(pr.Get(id));

                var cardProductSizes = new Dictionary<string, bool>();
                var sizes = product.Sizes.Split(',');
                var areSizesAvailable = product.SizesAreAvailable.Split(",");
                if(sizes.Length == areSizesAvailable.Length)
                {
                    for (int i = 0; i < sizes.Length; i++)
                    {
                        bool isSizeAvailable = areSizesAvailable[i] == "0" ? false : true;
                        cardProductSizes.Add(sizes[i], isSizeAvailable);
                    }
                }
                else
                {
                    cardProductSizes = null;
                }

                cardProduct.Sizes = cardProductSizes;
                return cardProduct;
            }
            return null;
        }
    }
}
