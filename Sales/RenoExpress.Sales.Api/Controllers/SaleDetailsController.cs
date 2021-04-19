using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RenoExpress.Common.Response;
using RenoExpress.Sales.Core.DTOs;
using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Exceptions;
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
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SaleDetailsController(
                ISaleDetailService saleDetailService,
                IMapper mapper
            )
        {
            _saleDetailService = saleDetailService;
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
            await _saleDetailService.InsertSaleDetailAsync(saleDetail);
            saleDetailDto = _mapper.Map<SaleDetailDTO>(saleDetail);
            var response = new ApiResponse<SaleDetailDTO>(saleDetailDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SaleDetailDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([Required] string Id, [FromBody] SaleDetailDTO saleDetailDto)
        {
            var saleDetail = await _saleDetailService.GetSaleDetailAsync(Id);
            if (saleDetail == null)
                throw new BusinessException("Error Change Item");
            //TODO: API

            saleDetail.Price = saleDetailDto.Price;
            saleDetail.Quantity = saleDetailDto.Quantity;
            await _saleDetailService.UpdateSaleDetailAsync(saleDetail);
            saleDetailDto = _mapper.Map<SaleDetailDTO>(saleDetail);
            var response = new ApiResponse<SaleDetailDTO>(saleDetailDto);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] string Id)
        {
            var saleDetail = await _saleDetailService.GetSaleDetailAsync(Id);
            if (saleDetail == null)
                throw new BusinessException("Product does not exist");
            await _saleDetailService.DeleteSaleDetailAsync(Id);
            //TODO: API
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        #endregion
    }
}
