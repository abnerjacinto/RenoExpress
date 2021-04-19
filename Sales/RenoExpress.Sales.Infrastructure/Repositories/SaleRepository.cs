using Microsoft.EntityFrameworkCore;
using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Interfaces.IRepositories;
using RenoExpress.Sales.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Infrastructure.Repositories
{
    public class SaleRepository:Repository<Sale>,ISaleRepository
    {
        #region Contructor
        public SaleRepository(DBContext dBcontext) :base(dBcontext)
        {

        }

        public async Task<IEnumerable<Sale>> GetSaleIncludeDetails()
        {
            return await _context.Sales.Where(x => x.Expired == 0).Include(x => x.SaleDetails).ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSaleIncludeDetailsByBranch(string branchId)
        {
            return await _context.Sales.Where(x => x.Expired == 0 && x.BranchID==branchId).Include(x => x.SaleDetails).ToListAsync();
        }

        public async Task<Sale> GetSaleByIdIncludeDetail(string id)
        {
            return await _context.Sales.Include(x =>x.SaleDetails).FirstOrDefaultAsync(x => x.Expired == 0 && x.ID==id);
        }
        #endregion

    }
}
