using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SampleDDD.Application;
using SampleDDD.Application.Contracts.Customers;
using SampleDDD.Application.Contracts.Products;
using SampleDDD.Application.Customers;
using SampleDDD.Application.Products;
using SampleDDD.Domain.Customers;
using SampleDDD.Domain.Products;
using SampleDDD.Infrastructure.EntityFrameworks;
using SampleDDD.Infrastructure.EntityFrameworks.Customers;
using SampleDDD.Infrastructure.EntityFrameworks.EntityFrameworkCore;
using SampleDDD.Infrastructure.EntityFrameworks.Products;
using SampleDDD.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SampleDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(bd =>
{
    bd.RegisterModule(new ApplicationModule());
    bd.RegisterModule(new InfrastructureModule());
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();