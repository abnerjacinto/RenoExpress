using RenoExpress.Purchasing.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Core.Interfaces.IRepositories
{
    public interface IPurchaseRepository:IRepository<Purchase>
    {
        Task<Purchase> GetPurchaseByIdIncludeDetail(string id);
        Task<IEnumerable<Purchase>> GetPurchaseIncludeDetails();
        Task<IEnumerable<Purchase>> GetPurchaseIncludeDetailsByBranch(string branchId);
    }
}
