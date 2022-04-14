using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace SO.API.ResponseExceptions
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public bool HasError { get; }

        public string ErrorMessage { get; }
        public HttpResponseException(HttpStatusCode statusCode, string errorMessage) : base(errorMessage)
        {
            StatusCode = statusCode;
            HasError = true;
            ErrorMessage = errorMessage;
        }
    }
}
