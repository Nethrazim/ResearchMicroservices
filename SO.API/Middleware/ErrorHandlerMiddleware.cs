using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using SO.API.ResponseExceptions;

namespace SO.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
            var response = context.Response;
            response.ContentType = "application/json";

            string result = string.Empty;
            ErrorResponse errorResponse = null;

            try
            {
                await _next(context);
            }
            catch (HttpResponseException ex)
            {
                if (ex is NotFoundResponse)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse = new ErrorResponse()
                    {
                        Message = ex.ErrorMessage,
                        StatusCode = HttpStatusCode.NotFound,
                    };
                    result = JsonConvert.SerializeObject(errorResponse);
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse = new ErrorResponse()
                {
                    Message = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                };

                result = JsonConvert.SerializeObject(errorResponse);
            }

            await response.WriteAsync(result);
        }
    }
}
