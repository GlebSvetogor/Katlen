using Katlen.DAL.Entities;

namespace Katlen.WEB.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ProductCardViewModel> ProductCards { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
