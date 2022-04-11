using System;
using System.Collections.Generic;
using System.Text;

namespace BaseClientNS.Entities.Responses
{
    public class BaseResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

}
