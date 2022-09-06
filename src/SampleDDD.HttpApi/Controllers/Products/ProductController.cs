using Microsoft.AspNetCore.Mvc;
using SampleDDD.Application.Contracts.Products;

namespace SampleDDD.HttpApi.Controllers.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase , IProductAppService
{
    private readonly IProductAppService _productAppService;

    public ProductController(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    [HttpPost]
    [Route("insert")]
    public Task<ProductDto> AddAsync(ProductCreateOrUpdateDto entityDto)
    {
        return _productAppService.AddAsync(entityDto);
    }


    [HttpPut]
    [Route("update/{id}")]
    public Task<ProductDto> UpdateAsync(Guid id, ProductCreateOrUpdateDto entityDto)
    {
        return _productAppService.UpdateAsync(id, entityDto);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public Task DeleteAsync(Guid id)
    {
        return _productAppService.DeleteAsync(id);
    }

    [HttpGet]
    [Route("get/{id}")]
    public Task<ProductDto> GetAsync(Guid id)
    {
        return _productAppService.GetAsync(id);
    }

    [HttpGet]
    [Route("get-list")]
    public Task<List<ProductDto>> GetListAsync(GetProductInput inputDto)
    {
        return _productAppService.GetListAsync(inputDto);
    }
}