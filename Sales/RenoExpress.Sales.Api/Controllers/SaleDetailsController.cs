using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RenoExpress.Common.Response;
using RenoExpress.Sales.Core.DTOs;
using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Exceptions;
using RenoExpress.Sales.Core.Interfaces.IAgents;
using RenoExpress.Sales.Core.Interfaces.IServices;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailsController : ControllerBase
    {
        #region Properties
        private readonly ISaleDetailService _saleDetailService;
        private readonly IStockAgent _stockAgent;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SaleDetailsController(
                ISaleDetailService saleDetailService,
                IStockAgent stockAgent,
                IMapper mapper
            )
        {
            _saleDetailService = saleDetailService;
            _stockAgent = stockAgent;
            _mapper = mapper;
        }
        #endregion

        #region Methods        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SaleDetailDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] SaleDetailDTO saleDetailDto)
        {
            var saleDetail = _mapper.Map<SaleDetail>(saleDetailDto);
            //TODO: API
            if (!await SendApiStock(false, saleDetailDto))
                throw new BusinessException("No Completed, transaction");
            await _saleDetailService.InsertSaleDetailAsync(saleDetail);
            saleDetailDto = _mapper.Map<SaleDetailDTO>(saleDetail);
            var response = new ApiResponse<SaleDetailDTO>(saleDetailDto);
            return Ok(response);
        }

        [HttpPut("{saleDetailId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SaleDetailDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([Required] string saleDetailId, [FromBody] SaleDetailDTO saleDetailDto)
        {
            var saleDetail = await _saleDetailService.GetSaleDetailAsync(saleDetailId);
            if (saleDetail == null)
                throw new BusinessException("Error Change Item");
            //TODO: API
            if (saleDetailDto.Quantity > saleDetail.Quantity)
            {
                if (!await SendApiStock(false, saleDetailDto))
                    throw new BusinessException("No Completed, transaction");
            }
            else if (saleDetailDto.Quantity < saleDetail.Quantity)
            {
                if (!await SendApiStock(true, saleDetailDto))
                    throw new BusinessException("No Completed, transaction");
            }

            saleDetail.Price = saleDetailDto.Price;
            saleDetail.Quantity = saleDetailDto.Quantity;
            await _saleDetailService.UpdateSaleDetailAsync(saleDetail);
            saleDetailDto = _mapper.Map<SaleDetailDTO>(saleDetail);
            var response = new ApiResponse<SaleDetailDTO>(saleDetailDto);
            return Ok(response);
        }

        [HttpDelete("{saleDetailId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] string saleDetailId)
        {
            var saleDetail = await _saleDetailService.GetSaleDetailAsync(saleDetailId);
            if (saleDetail == null)
                throw new BusinessException("Product does not exist");
            //TODO: API
            var saleDetailDto = _mapper.Map<SaleDetailDTO>(saleDetail);
            if (!await SendApiStock(false, saleDetailDto))
                throw new BusinessException("No Completed, transaction");
            await _saleDetailService.DeleteSaleDetailAsync(saleDetailId);            
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        private async Task<bool> SendApiStock(bool Increase, SaleDetailDTO saledetailDTO)
        {
            StockDTO stockDTO = new StockDTO()
            {
                ProductId = saledetailDTO.ProductID,
                Quantity = saledetailDTO.Quantity,
                BranchId = saledetailDTO.BranchId,
                Increase = Increase

            };
            var responseApi = await _stockAgent.PutStockAsync<StockDTO>(saledetailDTO.ProductID, stockDTO);
            return responseApi.IsSuccess;
        }
        #endregion
    }
}
