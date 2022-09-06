using Microsoft.EntityFrameworkCore;
using SampleDDD.Domain.Customers;
using SampleDDD.Domain.Orders;
using SampleDDD.Domain.Products;

namespace SampleDDD.Infrastructure.EntityFrameworks.EntityFrameworkCore;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> dbContextOptions) : base(dbContextOptions){}
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    public  DbSet<Order> Orders { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    //
    //     optionsBuilder.UseSqlServer(@"Server=localhost;Database=SampleDDD_db;Trusted_Connection=True;");
    // }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        /* Configure your own tables/entities inside here */
        builder.Entity<Customer>();
        builder.Entity<Product>();
        builder.Entity<Order>();
    }
}