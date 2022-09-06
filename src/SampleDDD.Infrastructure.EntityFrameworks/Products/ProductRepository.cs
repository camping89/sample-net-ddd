using SampleDDD.Domain.Products;
using SampleDDD.Infrastructure.EntityFrameworks.EntityFrameworkCore;
using SampleDDD.Infrastructure.EntityFrameworks.Generics;

namespace SampleDDD.Infrastructure.EntityFrameworks.Products;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(SampleDbContext dbContext) : base(dbContext)
    {
    }
}