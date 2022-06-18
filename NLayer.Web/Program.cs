using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using NLayer.Web.Modules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>()); 
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {

        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new repoServiceModul()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
