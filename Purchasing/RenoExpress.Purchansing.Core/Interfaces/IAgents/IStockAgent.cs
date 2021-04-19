using RenoExpress.Purchasing.Core.Models;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Core.Interfaces.IAgents
{
    public interface IStockAgent
    {
        Task<Response> PutStockAsync<T>(string productId, T model);
    }
}
