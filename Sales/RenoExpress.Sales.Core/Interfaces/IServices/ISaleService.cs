using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Core.Interfaces.IServices
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetSalesAsync(SaleQueryFilters queryFilters);

        Task<Sale> GetSaleAsync(string id);

        Task<bool> InsertSaleAsync(Sale sale);

        Task<bool> UpdateSaleAsync(Sale sale);

        Task<bool> DeleteSaleAsync(string id);
    }
}
