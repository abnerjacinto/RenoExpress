using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenoExpress.Common.Response;
using RenoExpress.Sales.Core.DTOs;
using RenoExpress.Sales.Core.Entities;
using RenoExpress.Sales.Core.Interfaces.IServices;
using RenoExpress.Sales.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RenoExpress.Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        #region Attributes
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SalesController(
                ISaleService saleService, 
                IMapper mapper
            )
        {
            _saleService = saleService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<SaleDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] SaleQueryFilters queryFilter)
        {
            var sales = await _saleService.GetSalesAsync(queryFilter);
            var salesDto = _mapper.Map<IEnumerable<SaleDTO>>(sales);
            var response = new ApiResponse<IEnumerable<SaleDTO>>(salesDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SaleDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] SaleDTO saleDto)
        {
            var sale = _mapper.Map<Sale>(saleDto);
            await _saleService.InsertSaleAsync(sale);
            saleDto = _mapper.Map<SaleDTO>(sale);
            var response = new ApiResponse<SaleDTO>(saleDto);
            return Ok(response);
        }
        #endregion
    }
}
