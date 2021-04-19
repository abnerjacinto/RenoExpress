using Microsoft.Extensions.DependencyInjection;
using RenoExpress.Purchasing.Core.Interfaces;
using RenoExpress.Purchasing.Core.Interfaces.IAgents;
using RenoExpress.Purchasing.Core.Interfaces.IRepositories;
using RenoExpress.Purchasing.Core.Interfaces.IServices;
using RenoExpress.Purchasing.Core.Services;
using RenoExpress.Purchasing.Infrastructure.Repositories;
using RenoExpress.Purchasing.Infrastructure.Repositories.Agents;

namespace RenoExpress.Purchasing.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Service injection Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<IPurchaseDetailService, PurchaseDetailService>();            

            return services;
        }
    }
}
