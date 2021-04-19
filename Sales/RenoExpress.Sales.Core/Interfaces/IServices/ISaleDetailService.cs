using RenoExpress.Sales.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Core.Interfaces.IServices
{
    public interface ISaleDetailService
    {
        Task<IEnumerable<SaleDetail>> GetSaleDetailsAsync();

        Task<SaleDetail> GetSaleDetailAsync(string id);        

        Task<bool> InsertSaleDetailAsync(SaleDetail saleDetail);

        Task<bool> UpdateSaleDetailAsync(SaleDetail saleDetail);

        Task<bool> DeleteSaleDetailAsync(string id);
    }
}
