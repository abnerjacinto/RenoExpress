using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RenoExpress.Common.Response;
using RenoExpress.Purchasing.Core.DTOs;
using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Exceptions;
using RenoExpress.Purchasing.Core.Interfaces.IAgents;
using RenoExpress.Purchasing.Core.Interfaces.IServices;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingDetailsController : ControllerBase
    {
        #region Attributes
        private readonly IPurchaseDetailService _purchaseDetailService;
        private readonly IStockAgent _stockAgent;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public PurchasingDetailsController(
                IPurchaseDetailService purchaseDetailService,
                IStockAgent stockAgent,
                IMapper mapper
            )
        {
            _purchaseDetailService = purchaseDetailService;
            _stockAgent = stockAgent;
            _mapper = mapper;
        }
        #endregion

        #region Methods        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<PurchaseDetailDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PurchaseDetailDTO purchaseDetailDto)
        {
            var purchaseDetail = _mapper.Map<PurchaseDetail>(purchaseDetailDto);
            //TODO: API
            if (!await SendApiStock(true, purchaseDetailDto))
                throw new BusinessException("No Completed, transaction");
            await _purchaseDetailService.InsertPurchaseDetailAsync(purchaseDetail);
            purchaseDetailDto = _mapper.Map<PurchaseDetailDTO>(purchaseDetail);
            var response = new ApiResponse<PurchaseDetailDTO>(purchaseDetailDto);
            return Ok(response);
        }

        [HttpPut("{purchaseDetailId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<PurchaseDetailDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([Required] string purchaseDetailId, [FromBody] PurchaseDetailDTO purchaseDetailDto)
        {
            var purchaseDetail = await _purchaseDetailService.GetPurchaseDetailAsync(purchaseDetailId);
            if (purchaseDetail == null)
                throw new BusinessException("Error Change Item");
            //TODO: API
            if (purchaseDetailDto.Quantity > purchaseDetail.Quantity)
            {
                if (!await SendApiStock(true, purchaseDetailDto))
                    throw new BusinessException("No Completed, transaction");
            }
            else if(purchaseDetailDto.Quantity < purchaseDetail.Quantity)
            {
                if (!await SendApiStock(false, purchaseDetailDto))
                    throw new BusinessException("No Completed, transaction");
            }

            purchaseDetail.Price = purchaseDetailDto.Price;
            purchaseDetail.Quantity = purchaseDetailDto.Quantity;
            await _purchaseDetailService.UpdatePurchaseDetailAsync(purchaseDetail);
            purchaseDetailDto = _mapper.Map<PurchaseDetailDTO>(purchaseDetail);
            var response = new ApiResponse<PurchaseDetailDTO>(purchaseDetailDto);
            return Ok(response);
        }

        [HttpDelete("{purchaseDetailId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] string purchaseDetailId)
        {
            var purchaseDetail = await _purchaseDetailService.GetPurchaseDetailAsync(purchaseDetailId);
            if (purchaseDetail == null)
                throw new BusinessException("Product does not exist");
            //TODO: API
            var purchaseDetailDto = _mapper.Map<PurchaseDetailDTO>(purchaseDetail);
            if (!await SendApiStock(false, purchaseDetailDto))
                throw new BusinessException("No Completed, transaction");
            await _purchaseDetailService.DeletePurchaseDetailAsync(purchaseDetailId);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        private async Task<bool> SendApiStock(bool Increase, PurchaseDetailDTO purchaseDetailDTO)
        {
            StockDTO stockDTO = new StockDTO()
            {
                ProductId = purchaseDetailDTO.ProductID,
                Quantity = purchaseDetailDTO.Quantity,
                BranchId = purchaseDetailDTO.BranchId,
                Increase = Increase

            };
            var responseApi = await _stockAgent.PutStockAsync<StockDTO>(purchaseDetailDTO.ProductID, stockDTO);
            return responseApi.IsSuccess;
        }
        #endregion
    }
}
