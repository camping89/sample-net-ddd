using Autofac;
using AutoMapper;
using SampleDDD.Application.Contracts.Customers;
using SampleDDD.Application.Contracts.Products;
using SampleDDD.Application.Customers;
using SampleDDD.Application.Products;
using SampleDDD.Domain;

namespace SampleDDD.Application;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(
                c => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AutoMapperProfile());
                }))
            .AsSelf()
            .SingleInstance();
    
        builder.Register(
                c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerDependency();

        builder.RegisterType<CustomerAppService>().As<ICustomerAppService>().InstancePerDependency();
        builder.RegisterType<ProductAppService>().As<IProductAppService>().InstancePerDependency();
        builder.RegisterModule(new DomainModule());
    }
}