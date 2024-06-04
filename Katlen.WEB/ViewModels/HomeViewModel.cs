using Katlen.BLL.DTO;

namespace Katlen.WEB.ViewModels
{
    public class HomeViewModel
    {
        public List<ProductCardViewModel> NewProductsCards { get; internal set; }
        public List<ProductCardViewModel> RateProductsCards { get; internal set; }
    }
}
