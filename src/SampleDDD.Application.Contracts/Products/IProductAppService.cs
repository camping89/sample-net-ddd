namespace SampleDDD.Application.Contracts.Products
{
    public interface IProductAppService : ICrudAppService<ProductDto,GetProductInput,ProductCreateOrUpdateDto>
    {
        
    }
}