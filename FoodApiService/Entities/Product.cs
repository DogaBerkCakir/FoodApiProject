namespace FoodApiService.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
