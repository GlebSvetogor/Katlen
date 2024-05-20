using Katlen.DAL.Entities;

namespace Katlen.WEB.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ProductCardViewModel> PageProductsCards { get; set; }
        public IEnumerable<ProductCardViewModel> ProductsCards {  get; set; }
        public PageViewModel PageViewModel { get; set; }
        
    }
}
