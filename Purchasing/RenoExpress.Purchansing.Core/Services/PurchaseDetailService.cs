using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Interfaces;
using RenoExpress.Purchasing.Core.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Core.Services
{
    public class PurchaseDetailService : IPurchaseDetailService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public PurchaseDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public async Task<bool> DeletePurchaseDetailAsync(string id)
        {
            await _unitOfWork.purchaseDetailRepository.DeleteAsync(id);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        public async Task<PurchaseDetail> GetPurchaseDetailAsync(string id)
        {
            return await _unitOfWork.purchaseDetailRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailsAsync()
        {
            return await _unitOfWork.purchaseDetailRepository.GetAllAsync();
        }

        public async Task<bool> InsertPurchaseDetailAsync(PurchaseDetail purchaseDetail)
        {
            await _unitOfWork.purchaseDetailRepository.InsertAsync(purchaseDetail);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        public async Task<bool> UpdatePurchaseDetailAsync(PurchaseDetail purchaseDetail)
        {
            _unitOfWork.purchaseDetailRepository.Update(purchaseDetail);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }
        #endregion

    }
}
