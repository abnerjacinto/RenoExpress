using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RenoExpress.Common.Response;
using RenoExpress.Purchasing.Core.DTOs;
using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Exceptions;
using RenoExpress.Purchasing.Core.Interfaces.IServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchansingDetailsController : ControllerBase
    {
        #region Attributes
        private readonly IPurchaseDetailService _purchaseDetailService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public PurchansingDetailsController(
                IPurchaseDetailService purchaseDetailService,
                IMapper mapper
            )
        {
            _purchaseDetailService = purchaseDetailService;
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
            await _purchaseDetailService.InsertPurchaseDetailAsync(purchaseDetail);
            purchaseDetailDto = _mapper.Map<PurchaseDetailDTO>(purchaseDetail);
            var response = new ApiResponse<PurchaseDetailDTO>(purchaseDetailDto);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<PurchaseDetailDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([Required]string Id,[FromBody] PurchaseDetailDTO purchaseDetailDto)
        {
            var purchaseDetail = await _purchaseDetailService.GetPurchaseDetailAsync(Id);
            if(purchaseDetail==null)
                throw new BusinessException("Error Change Item");
            //TODO: API

            purchaseDetail.Price = purchaseDetailDto.Price;
            purchaseDetail.Quantity = purchaseDetailDto.Quantity;            
            await _purchaseDetailService.UpdatePurchaseDetailAsync(purchaseDetail);
            purchaseDetailDto = _mapper.Map<PurchaseDetailDTO>(purchaseDetail);
            var response = new ApiResponse<PurchaseDetailDTO>(purchaseDetailDto);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete([FromQuery] string Id)
        {
            var purchaseDetail = await _purchaseDetailService.GetPurchaseDetailAsync(Id);
            if (purchaseDetail == null)
                throw new BusinessException("Product does not exist");            
            await _purchaseDetailService.DeletePurchaseDetailAsync(Id);
            //TODO: API
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }
        
        #endregion
    }
}
