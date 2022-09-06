using Autofac;
using SampleDDD.Domain.Customers;

namespace SampleDDD.Domain;

public class DomainModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerManager>().As<CustomerManager>().InstancePerLifetimeScope();
    }
}