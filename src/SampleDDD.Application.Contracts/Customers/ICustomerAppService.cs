namespace SampleDDD.Application.Contracts.Customers
{
    public interface ICustomerAppService : ICrudAppService<CustomerDto,GetCustomerInput,CustomerCreateOrUpdateDto>
    {
        
    }
}