using SO.BusinessLayer.Entities;
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
