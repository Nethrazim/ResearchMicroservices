using SO.BusinessLayer.Entities;
using SO.BusinessLayer.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.API.ResponseExceptions
{
    public class ErrorResponse : BaseResponse
    {
        public ErrorResponse()
        {
            HasError = true;
        }
    }
}
