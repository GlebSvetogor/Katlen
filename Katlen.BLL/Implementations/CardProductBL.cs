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
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, CardProductDTO>());
                // Настройка AutoMapper
                var mapper = new Mapper(config);
                // сопоставление
                var cardProduct = mapper.Map<CardProductDTO>(pr.Get(id));

                return cardProduct;
            }
            return null;
        }
    }
}
