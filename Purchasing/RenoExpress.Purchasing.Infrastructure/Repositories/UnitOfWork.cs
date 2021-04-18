using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Interfaces;
using RenoExpress.Purchasing.Core.Interfaces.IRepositories;
using RenoExpress.Purchasing.Infrastructure.Data;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Infrastructure.Repositories
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
        public IPurchaseRepository purchaseRepository => new PurchaseRepository(_context);
        public IRepository<PurchaseDetail> purchaseDetailRepository => new Repository<PurchaseDetail>(_context);

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

