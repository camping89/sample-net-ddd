using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleDDD.Domain.Products;

[Table("Products")]
public class Product : BaseEntity
{
    [Required]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}