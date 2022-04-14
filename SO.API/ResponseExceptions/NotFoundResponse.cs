using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace SO.API.ResponseExceptions
{
    public class NotFoundResponse : HttpResponseException
    {
        public NotFoundResponse(string errorMessage) : base(HttpStatusCode.NotFound, errorMessage) 
        { 

        } 
    }
}
