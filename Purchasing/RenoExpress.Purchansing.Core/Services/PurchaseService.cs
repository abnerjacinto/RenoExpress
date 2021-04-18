using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Interfaces;
using RenoExpress.Purchasing.Core.Interfaces.IServices;
using RenoExpress.Purchasing.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Core.Services
{    
    public class PurchaseService : IPurchaseService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseDetailService _purchaseDetailService;
        #endregion

        #region Constructor
        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public async Task<bool> DeletePurchaseAsync(string id)
        {
            await _unitOfWork.purchaseRepository.DeleteAsync(id);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            if (saveItem > 0)
            {
                await ExpiredPurchaseDetail(id);
            }
            
            return saveItem == 0 ? false : true;
        }

        public async Task<Purchase> GetPurchaseAsync(string id)
        {
            return await _unitOfWork.purchaseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesAsync(PurchaseQueryFilters queryFilters)
        {
            if (String.IsNullOrEmpty(queryFilters.BranchId))
                return await _unitOfWork.purchaseRepository.GetPurchaseIncludeDetails();

            return await _unitOfWork.purchaseRepository.GetPurchaseIncludeDetailsByBranch(queryFilters.BranchId);
        }

        public async Task<bool> InsertPurchaseAsync(Purchase purchase)
        {
            await _unitOfWork.purchaseRepository.InsertAsync(purchase);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        public async Task<bool> UpdatePurchaseAsync(Purchase purchase)
        {
            _unitOfWork.purchaseRepository.Update(purchase);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        private async Task ExpiredPurchaseDetail(string purchaseId)
        {   // TODO: Crear un metodo en el repositorio.
            var items = await _purchaseDetailService.GetPurchaseDetailsAsync();
            var purchaseItem = items.Where(x => x.ProductID == purchaseId);
            if (purchaseItem != null)
            {
                foreach(var detail in purchaseItem)
                {
                    await _purchaseDetailService.DeletePurchaseDetailAsync(detail.ID);
                }
            }
        }
        #endregion

    }
}
