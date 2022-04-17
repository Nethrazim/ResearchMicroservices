using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace SO.BusinessLayer.Entities.Responses
{
    public class BaseResponse<TResult> where TResult : System.Enum
    {
        [JsonProperty("Result")]
        public TResult Result { get; set; }

        [JsonProperty("StatusCode")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("HasError")]
        public bool HasError { get; set; } = false;

        [JsonProperty("Message")]
        public string Message { get; set; } = string.Empty;

        public BaseResponse()
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
   
}
