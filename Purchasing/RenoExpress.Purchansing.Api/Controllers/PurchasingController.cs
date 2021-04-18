using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RenoExpress.Common.Response;
using RenoExpress.Purchasing.Core.DTOs;
using RenoExpress.Purchasing.Core.Entities;
using RenoExpress.Purchasing.Core.Interfaces.IServices;
using RenoExpress.Purchasing.Core.QueryFilters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        #region Attributes
        private readonly IPurchaseService _purchaseService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public PurchasingController(
                IPurchaseService purchaseService,
                IMapper mapper
            )
        {
            _purchaseService = purchaseService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PurchaseDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] PurchaseQueryFilters queryFilter)
        {
            var purchases = await _purchaseService.GetPurchasesAsync(queryFilter);
            var purchaseDto = _mapper.Map<IEnumerable<PurchaseDTO>>(purchases);
            var response = new ApiResponse<IEnumerable<PurchaseDTO>>(purchaseDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<PurchaseDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PurchaseDTO purchaseDto)
        {
            var purchase = _mapper.Map<Purchase>(purchaseDto);
            await _purchaseService.InsertPurchaseAsync(purchase);
            purchaseDto = _mapper.Map<PurchaseDTO>(purchase);            
            var response = new ApiResponse<PurchaseDTO>(purchaseDto);
            return Ok(response);
        }
        #endregion
    }
}
