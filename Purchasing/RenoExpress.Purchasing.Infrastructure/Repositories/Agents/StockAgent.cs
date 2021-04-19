using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RenoExpress.Purchasing.Core.Interfaces.IAgents;
using RenoExpress.Purchasing.Core.Models;
using RenoExpress.Purchasing.Core.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RenoExpress.Purchasing.Infrastructure.Repositories.Agents
{
    public class StockAgent : IStockAgent
    {
        #region attributes
        private const int MaxRetries = 3;
        private readonly HttpClient _httpClient;
        private readonly UrlApisOptions _urlApi;
        private readonly AsyncRetryPolicy _retryPolicy;
        private const string endpoint = "stock/v1/stocks/";

        #endregion

        #region Constructor
        public StockAgent(
                HttpClient httpClient,
                IOptions<UrlApisOptions> urlApi                
            )
        {
            _httpClient = httpClient;
            _urlApi = urlApi.Value;            
            _httpClient.BaseAddress = new Uri(_urlApi.RenoExpressUrl);
            _retryPolicy = Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(MaxRetries, sleepDurationProvider: times => TimeSpan.FromMilliseconds(times * 100));
        }

        #endregion

        #region Methods
        
        public async Task<Response> PutStockAsync<T>(string productId, T model)
        {
            var url = $"{endpoint}{productId}";
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                return await _retryPolicy.ExecuteAsync(async () =>
                {
                    var response = await _httpClient.PutAsync(url, content);
                    var result = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {                        
                        return new Response
                        {
                            IsSuccess = false,
                            Message = result,
                        };
                    }

                    var obj = JsonConvert.DeserializeObject<BaseResponse<T>>(result);
                    return new Response
                    {
                        IsSuccess = true,
                        Result = obj.Data,
                    };
                });
            }
            catch (Exception ex)
            {                
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }// end PUT

        #endregion
    }
}
