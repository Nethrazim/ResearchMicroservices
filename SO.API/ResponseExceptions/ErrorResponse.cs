using SO.BusinessLayer.Entities;
using SO.BusinessLayer.Entities.Responses;
using SO.BusinessLayer.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.API.ResponseExceptions
{
    public class ErrorResponse : BaseResponse<BaseResult>
    {
        public ErrorResponse()
        {
            HasError = true;
            Result = BaseResult.Error; 
        }
    }
}
