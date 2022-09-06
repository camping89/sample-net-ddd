using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleDDD.Application.Contracts.Customers;

namespace SampleDDD.HttpApi.Controllers.Customers;

[ApiController]
[Route("[controller]")]
//[Authorize]
public class CustomerController : ControllerBase, ICustomerAppService
{
    private readonly ICustomerAppService _customerAppService;

    public CustomerController(ICustomerAppService customerAppService)
    {
        _customerAppService = customerAppService;
    }

    [HttpPost]
    [Route("insert")]
    public Task<CustomerDto> AddAsync(CustomerCreateOrUpdateDto entityDto)
    {
        return _customerAppService.AddAsync(entityDto);
    }

    [HttpPut]
    [Route("update/{id}")]
    public Task<CustomerDto> UpdateAsync(Guid id, CustomerCreateOrUpdateDto entityDto)
    {
        return _customerAppService.UpdateAsync(id, entityDto);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _customerAppService.DeleteAsync(id);
    }
    
    [HttpGet]
    [Route("get/{id}")]
    public Task<CustomerDto> GetAsync(Guid id)
    {
        return _customerAppService.GetAsync(id);
    }

    [HttpGet]
    [Route("get-all")]
    public Task<List<CustomerDto>> GetListAsync([FromQuery]GetCustomerInput inputDto)
    {
        return _customerAppService.GetListAsync(inputDto);
    }
}