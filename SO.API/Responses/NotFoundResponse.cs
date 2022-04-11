using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace SO.API.Responses
{
    public class NotFoundResponse : ErrorResponse
    {
        public NotFoundResponse() : base(HttpStatusCode.NotFound) { } 
    }
}
