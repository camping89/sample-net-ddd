using System.ComponentModel.DataAnnotations.Schema;
using SampleDDD.Domain.Customers;
using SampleDDD.Domain.Products;

namespace SampleDDD.Domain.Orders;

public class Order : BaseEntity
{
    [ForeignKey("Product")]
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    
    [ForeignKey("Customer")]
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    
    public DateTime CreatedAt { get; set; }
}