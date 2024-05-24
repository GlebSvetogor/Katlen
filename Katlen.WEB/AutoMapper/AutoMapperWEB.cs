using AutoMapper;
using Katlen.BLL.DTO;
using Katlen.WEB.ViewModels;

namespace Katlen.WEB.AutoMapper
{
    public class AutoMapperWEB
    {
        private readonly IMapper _mapper;
        public AutoMapperWEB(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void MapProductsToProductCards(List<ProductCardViewModel> productsCards, IEnumerable<ProductDTO> products)
        {
            foreach (var product in products)
            {
                ProductCardViewModel productCard = _mapper.Map<ProductCardViewModel>(product);
                productCard.Image = product.Images[0];
                productCard.SalePercent = CountProductSale(productCard.SalePrice, productCard.FullPrice);

                productsCards.Add(productCard);
            }
        }

        public int CountProductSale(int salePrice, int fullPrice)
        {
            int salePercent = (int)(100 - (salePrice * 100 / fullPrice));
            return salePercent;
        }
    }
}
