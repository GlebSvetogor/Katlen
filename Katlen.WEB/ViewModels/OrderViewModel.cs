namespace Katlen.WEB.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public List<BasketViewModel>? Basket;
        public int TotalFullPrice { get; set; }
        public int TotalSale { get; set; }
        public int TotalPrice { get; set; }
    }
}
