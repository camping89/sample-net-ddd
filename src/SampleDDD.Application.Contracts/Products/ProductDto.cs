namespace SampleDDD.Application.Contracts.Products
{
    public class ProductDto : BaseEntityDto
    {
        public string Title { get; set; }
    
        public string Description { get; set; }
    
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}