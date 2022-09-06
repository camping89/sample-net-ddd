using SampleDDD.Domain.Customers;
using SampleDDD.Infrastructure.EntityFrameworks.EntityFrameworkCore;
using SampleDDD.Infrastructure.EntityFrameworks.Generics;

namespace SampleDDD.Infrastructure.EntityFrameworks.Customers;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(SampleDbContext dbContext) : base(dbContext)
    {
    }
}