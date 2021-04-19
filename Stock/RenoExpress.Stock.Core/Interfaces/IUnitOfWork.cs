using RenoExpress.Stock.Core.Entities;
using RenoExpress.Stock.Core.Interfaces.IRepositories;
using System;
using System.Threading.Tasks;


namespace RenoExpress.Stock.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties       
        
        IStockRepository stockRepository { get; }
        #endregion

        #region Methods        
        int SaveChange();        
        Task<int> SaveChangeAsync();
        #endregion

    }
}
