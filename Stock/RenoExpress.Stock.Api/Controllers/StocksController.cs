using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenoExpress.Common.Response;
using RenoExpress.Stock.Core.DTOs;
using RenoExpress.Stock.Core.Entities;
using RenoExpress.Stock.Core.Exceptions;
using RenoExpress.Stock.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RenoExpress.Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        #region Attributes
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StocksController(
                IStockService stockService,
                IMapper mapper
            )
        {
            _stockService = stockService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpPut("{productId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<StockDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put([Required] string productId, [FromBody] StockDTO stockDto)
        {
            var stock = await _stockService.GetProductStockAsync(productId,stockDto.BranchId);
            if (stock != null)
            {
                stock.Quantity = stockDto.Quantity;
                await _stockService.UpdateProductStockAsync(stock);
                stockDto = _mapper.Map<StockDTO>(stock);
                
            }
            else
            {
                stock = _mapper.Map<ProductStock>(stockDto);
                await _stockService.InsertProductStockAsync(stock);
                stockDto = _mapper.Map<StockDTO>(stock);
            }           
            
            var response = new ApiResponse<StockDTO>(stockDto);
            return Ok(response);
        }
        #endregion
    }
}
