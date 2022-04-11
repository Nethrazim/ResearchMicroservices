using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace SO.API.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse(HttpStatusCode statusCode) {
            StatusCode = statusCode;
            HasError = true;
        }



        public HttpStatusCode StatusCode { get; }
        public bool HasError { get; }
        public string ErrorMessage { get; set; }
    }
}
