using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using RenoExpress.Sales.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace RenoExpress.Sales.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
  {    
    public void OnException(ExceptionContext context)
    {
      var traceId = Activity.Current?.Id ?? context?.HttpContext.TraceIdentifier;
      // captura de exceptiones y controlar el mensaje
      if (context.Exception.GetType() == typeof(BusinessException))
      {
        var exception = (BusinessException)context.Exception;

        var json = new
        {
          type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
          title = "Bad Request",
          status = 400,
          traceId = traceId ?? "",
          errors = new { value = exception.Message }
        };
        context.Result = new BadRequestObjectResult(json);
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.ExceptionHandled = true;
      }
     
    }
  }
}
