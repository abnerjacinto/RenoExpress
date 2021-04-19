using Microsoft.Extensions.DependencyInjection;
using RenoExpress.Stock.Core.Interfaces;
using RenoExpress.Stock.Core.Interfaces.IRepositories;
using RenoExpress.Stock.Core.Interfaces.IServices;
using RenoExpress.Stock.Core.Services;
using RenoExpress.Stock.Infrastructure.Repositories;

namespace RenoExpress.Stock.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      // Service injection Repositories
      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddTransient<IStockRepository, StockRepository>();
      services.AddTransient<IStockService, StockService>();
     

      return services;
    }
  }
}
