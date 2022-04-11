using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SO.API.Responses;
using System.Net;
using Newtonsoft.Json;

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
            ErrorResponse errorResponse = null;
            var response = context.Response;
            response.ContentType = "application/json";

            try
            {
                await _next(context);
            }
            catch (HttpResponseException httpException)
            {

                switch (httpException.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorResponse = new NotFoundResponse() { ErrorMessage = httpException.Message };
                        break;
                }
            }

            var result =  JsonConvert.SerializeObject(errorResponse);
            await response.WriteAsync(result);
        }
    }
}
