using AutoMapper;
using SampleDDD.Application.Contracts.Customers;
using SampleDDD.Domain.Customers;

namespace SampleDDD.Application.Customers;

public class CustomerAppService : ICustomerAppService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerAppService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDto> AddAsync(CustomerCreateOrUpdateDto entityDto)
    {
        var entity = _mapper.Map<Customer>(entityDto);
        await _customerRepository.AddAsync(entity);
        await _customerRepository.SaveChangesAsync();
        
        return  _mapper.Map<CustomerDto>(entity);
        
    }

    public async Task<CustomerDto> UpdateAsync(Guid id,CustomerCreateOrUpdateDto entityDto)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == id);

        // if (entity != null)
        // {
        //     entity.Address = entityDto.Address;
        //     entity.Email = entityDto.Email;
        //     entity.FirstName = entityDto.FirstName;
        //     entity.LastName = entityDto.LastName;
        //     entity.PhoneNumber = entityDto.PhoneNumber;
        //
        //     await _customerRepository.UpdateAsync(entity);
        //     await _customerRepository.SaveChangesAsync();
        // }
        
        if (entity != null)
        {
            _mapper.Map(entityDto, entity);
            await _customerRepository.UpdateAsync(entity);
            await _customerRepository.SaveChangesAsync();
        }

        return _mapper.Map<CustomerDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _customerRepository.DeleteAsync(id);
        await _customerRepository.SaveChangesAsync();
    }

    public async Task<CustomerDto> GetAsync(Guid id)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == id);
        return _mapper.Map<CustomerDto>(entity);
    }

    public async Task<List<CustomerDto>> GetListAsync(GetCustomerInput inputDto)
    {
        var entity = await _customerRepository.GetListAsync(x=> string.IsNullOrEmpty(inputDto.Filter) || x.FirstName.Contains(inputDto.Filter) || x.LastName.Contains(inputDto.Filter));
        return _mapper.Map<List<CustomerDto>>(entity);
    }
}