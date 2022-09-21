using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayCore.ProductCatalog.Service.Interfaces.Repositories;
using PayCore.ProductCatalog.Service.Interfaces.UnitOfWork;
using PayCore.ProductCatalog.Repository.Extension;
using PayCore.ProductCatalog.Repository.Repositories;

namespace PayCore.ProductCatalog.Repository.DependencyContainers
{
    public static class DependencyRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // hibernate
            var connStr = configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connStr);
        }
    }
}
