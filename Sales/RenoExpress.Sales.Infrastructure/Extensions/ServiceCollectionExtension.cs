using Microsoft.Extensions.DependencyInjection;
using RenoExpress.Sales.Core.Interfaces;
using RenoExpress.Sales.Core.Interfaces.IAgents;
using RenoExpress.Sales.Core.Interfaces.IRepositories;
using RenoExpress.Sales.Core.Interfaces.IServices;
using RenoExpress.Sales.Core.Services;
using RenoExpress.Sales.Infrastructure.Repositories;
using RenoExpress.Sales.Infrastructure.Repositories.Agents;

namespace RenoExpress.Sales.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Service injection Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<ISaleService, SaleService>();
            services.AddTransient<ISaleDetailService, SaleDetailService>();
            services.AddTransient<IStockAgent, StockAgent>();

            return services;
        }
    }
}
