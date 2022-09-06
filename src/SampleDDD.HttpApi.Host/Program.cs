using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SampleDDD.Application;
using SampleDDD.Application.Contracts.Customers;
using SampleDDD.Application.Contracts.Products;
using SampleDDD.Application.Customers;
using SampleDDD.Application.Products;
using SampleDDD.Domain.Customers;
using SampleDDD.Domain.Products;
using SampleDDD.Infrastructure.EntityFrameworks.Customers;
using SampleDDD.Infrastructure.EntityFrameworks.EntityFrameworkCore;
using SampleDDD.Infrastructure.EntityFrameworks.Products;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SampleDbContext>(options =>
    options.UseSqlServer(connectionString));

// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(bd =>
{
    bd.Register(
            c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }))
        .AsSelf()
        .SingleInstance();
    
    bd.Register(
            c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
        .As<IMapper>()
        .InstancePerLifetimeScope();

    bd.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
    bd.RegisterType<CustomerAppService>().As<ICustomerAppService>().InstancePerLifetimeScope();
    
    
    bd.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
    bd.RegisterType<ProductAppService>().As<IProductAppService>().InstancePerLifetimeScope();
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();