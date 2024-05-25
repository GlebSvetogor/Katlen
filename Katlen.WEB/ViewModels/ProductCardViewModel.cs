using Katlen.DAL.Entities;

namespace Katlen.WEB.ViewModels
{
    public class ProductCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public string Material { get; set; }
        public string Image { get; set; }
        public int SalePrice { get; set; }
        public int FullPrice { get; set; }
        public int SalePercent { get; set; }
        public int MinimumAvailableSize { get; set; }



    }
}
