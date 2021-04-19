using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Interfaces;
using RenoExpress.Sales.Core.Interfaces.IRepositories;
using RenoExpress.Sales.Infrastructure.Data;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Infrastructure.Repositories
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
        public ISaleRepository saleRepository => new SaleRepository(_context);
        public IRepository<SaleDetail> saleDetailRepository => new Repository<SaleDetail>(_context);

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

