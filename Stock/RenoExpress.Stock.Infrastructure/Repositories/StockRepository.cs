using Microsoft.EntityFrameworkCore;
using RenoExpress.Stock.Core.Entities;
using RenoExpress.Stock.Core.Interfaces.IRepositories;
using RenoExpress.Stock.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenoExpress.Stock.Infrastructure.Repositories
{
    public class StockRepository:Repository<ProductStock>,IStockRepository
    {
        #region Contructor
        public StockRepository(DBContext dBcontext) :base(dBcontext)
        {

        }       

        public async Task<IEnumerable<ProductStock>> GetProductsStockByBranch(string branchId)
        {
            return await _context.ProductStocks.Where(
                x => x.Expired == 0 &&
                x.BranchId==branchId)
                .ToListAsync();
        }
        public async Task<ProductStock> GetProductStockByBranch(string productId, string branchId)
        {
            return await _context.ProductStocks.FirstOrDefaultAsync(
                x => x.Expired == 0 &&
                x.BranchId == branchId &&
                x.ProductId == productId);
        }

        #endregion

    }
}
