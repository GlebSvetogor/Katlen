using Katlen.DAL.Entities;

namespace Katlen.WEB.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ProductCardViewModel> PageProductsCards { get; set; }
        public int ProductsCardsQuality {  get; set; }
        public PageViewModel PageViewModel { get; set; }
        public Dictionary<string, string> Filtrs { get; set; }
        public string SortOption = null;
        
    }
}
