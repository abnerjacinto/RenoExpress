using RenoExpress.Stock.Core.Entities;
using RenoExpress.Stock.Core.Interfaces;
using RenoExpress.Stock.Core.Interfaces.IRepositories;
using RenoExpress.Stock.Infrastructure.Data;
using System.Threading.Tasks;

namespace RenoExpress.Stock.Infrastructure.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        #region Attributes
        private readonly DBContext _context;
        #endregion

        #region Constructor
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        #endregion
        public IStockRepository stockRepository => new StockRepository(_context);
       

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public int SaveChange() => _context.SaveChanges();
        public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
    }
}

