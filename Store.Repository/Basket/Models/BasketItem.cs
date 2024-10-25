namespace Store.Repository.Basket.Models
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string BrandName { get; set; }
        public string TypeName { get; set; }

    }
}