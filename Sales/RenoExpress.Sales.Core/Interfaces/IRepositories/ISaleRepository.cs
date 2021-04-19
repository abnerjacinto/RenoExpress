using RenoExpress.Sales.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Core.Interfaces.IRepositories
{
    public interface ISaleRepository:IRepository<Sale>
    {
        Task<Sale> GetSaleByIdIncludeDetail(string id);
        Task<IEnumerable<Sale>> GetSaleIncludeDetails();
        Task<IEnumerable<Sale>> GetSaleIncludeDetailsByBranch(string branchId);
    }
}
