using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CTTPB.MESCDP.Application.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CTTPB.MESCDP.Application.WebApi.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LoggerFactory _logger;
        public ExceptionMiddleware(RequestDelegate next)//, LoggerFactory logger)
        {
            //_logger = logger;
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var arrayErrorMessage = exception.Message.Split("__");
            string errorMessage = String.Empty;
            int errorCode = 0;
            if (arrayErrorMessage.Length > 0)
            {
                if (arrayErrorMessage.First().Equals("PERMISSÃO"))
                {
                    errorMessage = arrayErrorMessage.Last();
                    errorCode = 403;
                }
                else
                {
                    errorMessage = exception.Message;
                }
            }
                 

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = (errorCode == 0)? context.Response.StatusCode: errorCode,
                Message = String.IsNullOrEmpty(errorMessage) ? "Internal Server Error from the custom middleware."
                                                                  : errorMessage
            }.ToString());
        }
    }
}
