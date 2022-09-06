using AutoMapper;
using SampleDDD.Application.Contracts.Products;
using SampleDDD.Domain.Products;

namespace SampleDDD.Application.Products;

public class ProductAppService : IProductAppService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductAppService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> AddAsync(ProductCreateOrUpdateDto entityDto)
    {
        var entity = _mapper.Map<Product>(entityDto);
        await _productRepository.AddAsync(entity);
        await _productRepository.SaveChangesAsync();

        return _mapper.Map<ProductDto>(entity);
    }

    public async Task<ProductDto> UpdateAsync(Guid id, ProductCreateOrUpdateDto entityDto)
    {
        var entity = await _productRepository.GetAsync(id);
        if (entity != null)
        {
            _mapper.Map(entityDto, entity);
            await _productRepository.UpdateAsync(entity);
            await _productRepository.SaveChangesAsync();
        }
        return _mapper.Map<ProductDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
        await _productRepository.SaveChangesAsync();
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var entity = await _productRepository.GetAsync(id);
        return _mapper.Map<ProductDto>(entity);
    }

    public async Task<List<ProductDto>> GetListAsync(GetProductInput inputDto)
    {
        var entity = await _productRepository.GetListAsync(x=> string.IsNullOrEmpty(inputDto.Filter) || x.Title.Contains(inputDto.Filter));
        return _mapper.Map<List<ProductDto>>(entity);
    }
}