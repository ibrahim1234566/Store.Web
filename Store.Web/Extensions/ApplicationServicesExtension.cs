using Store.Repository.Interfaces;
using Store.Repository.UnitOfWork;
using Store.Service.Services.Products.Dtos;
using Store.Service.Services.Products;

namespace Store.Web.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection ApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductService, ProductService>();


            return services;
        }
    }
}
