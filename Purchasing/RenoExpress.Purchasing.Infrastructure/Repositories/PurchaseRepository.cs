using Microsoft.EntityFrameworkCore;
using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Interfaces.IRepositories;
using RenoExpress.Purchasing.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Infrastructure.Repositories
{
    public class PurchaseRepository:Repository<Purchase>,IPurchaseRepository
    {
        #region Contructor
        public PurchaseRepository(DBContext dBcontext) :base(dBcontext)
        {

        }

        public async Task<IEnumerable<Purchase>> GetPurchaseIncludeDetails()
        {
            return await _context.Purchases.Where(x => x.Expired == 0).Include(x => x.PurchaseDetails).ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseIncludeDetailsByBranch(string branchId)
        {
            return await _context.Purchases.Where(x => x.Expired == 0 && x.BranchID==branchId).Include(x => x.PurchaseDetails).ToListAsync();
        }

        public async Task<Purchase> GetPurchaseByIdIncludeDetail(string id)
        {
            return await _context.Purchases.Include(x =>x.PurchaseDetails).FirstOrDefaultAsync(x => x.Expired == 0 && x.ID==id);
        }
        #endregion

    }
}
