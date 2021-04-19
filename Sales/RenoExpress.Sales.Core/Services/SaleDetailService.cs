using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Interfaces;
using RenoExpress.Sales.Core.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Core.Services
{
    public class SaleDetailService : ISaleDetailService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public SaleDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public async Task<bool> DeleteSaleDetailAsync(string id)
        {
            await _unitOfWork.saleDetailRepository.DeleteAsync(id);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        public async Task<SaleDetail> GetSaleDetailAsync(string id)
        {
            return await _unitOfWork.saleDetailRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SaleDetail>> GetSaleDetailsAsync()
        {
            return await _unitOfWork.saleDetailRepository.GetAllAsync();
        }

        public async Task<bool> InsertSaleDetailAsync(SaleDetail saleDetail)
        {
            await _unitOfWork.saleDetailRepository.InsertAsync(saleDetail);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        public async Task<bool> UpdateSaleDetailAsync(SaleDetail saleDetail)
        {
            _unitOfWork.saleDetailRepository.Update(saleDetail);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }
        #endregion

    }
}
