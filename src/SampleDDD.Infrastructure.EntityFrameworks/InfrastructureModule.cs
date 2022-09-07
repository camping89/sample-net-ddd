using Autofac;
using SampleDDD.Domain;
using SampleDDD.Domain.Customers;
using SampleDDD.Domain.Products;
using SampleDDD.Infrastructure.EntityFrameworks.Customers;
using SampleDDD.Infrastructure.EntityFrameworks.Products;

namespace SampleDDD.Infrastructure.EntityFrameworks;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerDependency();
        builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
        
        //Domain Module
        //builder.RegisterModule(new DomainModule());
    }
}