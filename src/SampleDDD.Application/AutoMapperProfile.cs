using AutoMapper;
using SampleDDD.Application.Contracts.Customers;
using SampleDDD.Application.Contracts.Products;
using SampleDDD.Domain.Customers;
using SampleDDD.Domain.Products;

namespace SampleDDD.Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<CustomerCreateOrUpdateDto, Customer>().ForMember(x=>x.Id, opt => opt.Ignore());
        
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductCreateOrUpdateDto, Product>().ForMember(x=>x.Id, opt => opt.Ignore());
    }
}