using RenoExpress.Stock.Core.Entities;
using RenoExpress.Stock.Core.Interfaces;
using RenoExpress.Stock.Core.Interfaces.IServices;
using RenoExpress.Stock.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenoExpress.Stock.Core.Services
{
    public class StockService : IStockService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;        
        #endregion

        #region Constructor
        public StockService(
            IUnitOfWork unitOfWork
          )
        {
            _unitOfWork = unitOfWork;
            
        }
        #endregion

        #region Methods
        public async Task<bool> DeleteProductStockAsync(string id)
        {
            await _unitOfWork.stockRepository.DeleteAsync(id);
            var saveItem = await _unitOfWork.SaveChangeAsync();     
            
            return saveItem == 0 ? false : true;
        }

        public async Task<ProductStock> GetProductStockAsync(string id)
        {
            return await _unitOfWork.stockRepository.GetByIdAsync(id);
        }

        public async Task<ProductStock> GetProductStockAsync(string productId, string branchId)
        {
            return await _unitOfWork.stockRepository.GetProductStockByBranch(productId,branchId);
        }

        public async Task<IEnumerable<ProductStock>> GetProductStocksAsync(StockQueryFilters queryFilters)
        {
            if (String.IsNullOrEmpty(queryFilters.BranchId))
                return await _unitOfWork.stockRepository.GetAllAsync();

            return await _unitOfWork.stockRepository.GetProductsStockByBranch(queryFilters.BranchId);
        }

        public async Task<bool> InsertProductStockAsync(ProductStock stock)
        {
            await _unitOfWork.stockRepository.InsertAsync(stock);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        public async Task<bool> UpdateProductStockAsync(ProductStock stock)
        {
            _unitOfWork.stockRepository.Update(stock);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

       
        #endregion

    }
}
