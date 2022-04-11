using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace SO.API.Responses
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpStatusCode statusCode, string msg) : base(msg)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
