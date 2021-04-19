using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Interfaces;
using RenoExpress.Sales.Core.Interfaces.IServices;
using RenoExpress.Sales.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Core.Services
{    
    public class SaleService : ISaleService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleDetailService _saleDetailService;
        #endregion

        #region Constructor
        public SaleService(
            IUnitOfWork unitOfWork,
            ISaleDetailService saleDetailService)
        {
            _unitOfWork = unitOfWork;
            _saleDetailService = saleDetailService;
        }
        #endregion

        #region Methods
        public async Task<bool> DeleteSaleAsync(string id)
        {
            await _unitOfWork.saleRepository.DeleteAsync(id);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            if (saveItem > 0)
            {
                await ExpiredSaleDetail(id);
            }
            
            return saveItem == 0 ? false : true;
        }

        public async Task<Sale> GetSaleAsync(string id)
        {
            return await _unitOfWork.saleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync(SaleQueryFilters queryFilters)
        {
            if (String.IsNullOrEmpty(queryFilters.BranchId))
                return await _unitOfWork.saleRepository.GetSaleIncludeDetails();

            return await _unitOfWork.saleRepository.GetSaleIncludeDetailsByBranch(queryFilters.BranchId);
        }

        public async Task<bool> InsertSaleAsync(Sale sale)
        {
            await _unitOfWork.saleRepository.InsertAsync(sale);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        public async Task<bool> UpdateSaleAsync(Sale sale)
        {
            _unitOfWork.saleRepository.Update(sale);
            var saveItem = await _unitOfWork.SaveChangeAsync();
            return saveItem == 0 ? false : true;
        }

        private async Task ExpiredSaleDetail(string purchaseId)
        {   // TODO: Crear un metodo en el repositorio.
            var items = await _saleDetailService.GetSaleDetailsAsync();
            var purchaseItem = items.Where(x => x.ProductID == purchaseId);
            if (purchaseItem != null)
            {
                foreach(var detail in purchaseItem)
                {
                    await _saleDetailService.DeleteSaleDetailAsync(detail.ID);
                }
            }
        }
        #endregion

    }
}
