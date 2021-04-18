using RenoExpress.Purchasing.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Core.Interfaces.IServices
{
    public interface IPurchaseDetailService
    {
        Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailsAsync();

        Task<PurchaseDetail> GetPurchaseDetailAsync(string id);        

        Task<bool> InsertPurchaseDetailAsync(PurchaseDetail purchaseDetail);

        Task<bool> UpdatePurchaseDetailAsync(PurchaseDetail purchaseDetail);

        Task<bool> DeletePurchaseDetailAsync(string id);
    }
}
