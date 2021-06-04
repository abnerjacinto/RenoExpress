using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Core.Interfaces.IServices
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetPurchasesAsync(PurchaseQueryFilters queryFilters);

        Task<Purchase> GetPurchaseAsync(string id);

        Task<bool> InsertPurchaseAsync(Purchase purchase);

        Task<bool> UpdatePurchaseAsync(Purchase purchase);

        Task<bool> DeletePurchaseAsync(string id);
        
    }
}
