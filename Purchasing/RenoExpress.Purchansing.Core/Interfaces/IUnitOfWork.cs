using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Interfaces.IRepositories;
using System;
using System.Threading.Tasks;


namespace RenoExpress.Purchasing.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties       
        IPurchaseRepository purchaseRepository { get; }
        IRepository<PurchaseDetail> purchaseDetailRepository { get; }
        #endregion

        #region Methods        
        int SaveChange();        
        Task<int> SaveChangeAsync();
        #endregion

    }
}
