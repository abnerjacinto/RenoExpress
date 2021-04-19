using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Interfaces.IRepositories;
using System;
using System.Threading.Tasks;


namespace RenoExpress.Sales.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties       
        ISaleRepository saleRepository { get; }
        IRepository<SaleDetail> saleDetailRepository { get; }
        #endregion

        #region Methods        
        int SaveChange();        
        Task<int> SaveChangeAsync();
        #endregion

    }
}
