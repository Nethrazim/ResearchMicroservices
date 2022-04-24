using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace SO.API.ResponseExceptions
{
    public class BadRequestResponse : HttpResponseException
    {
        public BadRequestResponse(string errorMessage) : base(HttpStatusCode.NotFound, errorMessage) 
        { 

        } 
    }
}
