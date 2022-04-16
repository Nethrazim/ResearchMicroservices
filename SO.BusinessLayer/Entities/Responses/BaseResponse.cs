using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
namespace SO.BusinessLayer.Entities.Responses
{
    public class BaseResponse<TResult> where TResult : System.Enum
    {
        public TResult Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool HasError { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public BaseResponse()
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
   
}
