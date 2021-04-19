using RenoExpress.Stock.Core.Entities;
using RenoExpress.Stock.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Stock.Core.Interfaces.IServices
{
    public interface IStockService
    {
        Task<IEnumerable<ProductStock>> GetProductStocksAsync(StockQueryFilters queryFilters);

        Task<ProductStock> GetProductStockAsync(string id);
        Task<ProductStock> GetProductStockAsync(string productId, string branchId);

        Task<bool> InsertProductStockAsync(ProductStock stock);

        Task<bool> UpdateProductStockAsync(ProductStock stock);

        Task<bool> DeleteProductStockAsync(string id);
    }
}
