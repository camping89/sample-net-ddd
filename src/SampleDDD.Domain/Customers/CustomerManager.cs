namespace SampleDDD.Domain.Customers;

public class CustomerManager
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerManager(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> GetListAsync(string filter)
    {
       return await _customerRepository.GetListAsync(x=> string.IsNullOrEmpty(filter) || x.FirstName.Contains(filter) || x.LastName.Contains(filter));
    }
}