using RenoExpress.Sales.Core.DTOs;
using RenoExpress.Sales.Core.Models;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Core.Interfaces.IAgents
{
    public interface IStockAgent
    {
        Task<Response> PutStockAsync<T>(string productId, T model);
    }
}
