using RenoExpress.Stock.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Stock.Core.Interfaces.IRepositories
{
    public interface IStockRepository:IRepository<ProductStock>
    {      
        Task<IEnumerable<ProductStock>> GetProductsStockByBranch(string branchId);
        Task<ProductStock> GetProductStockByBranch(string productId, string branchId);
    }
}
