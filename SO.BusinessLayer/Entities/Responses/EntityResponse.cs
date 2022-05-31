using Newtonsoft.Json;
using SO.BusinessLayer.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Entities.Responses
{
    public class EntityResponse<T> : BaseResponse<BaseResult>
    where T : class
    {
        [JsonProperty("Entity")]
        public T Entity { get; set; }
    }

    public class EntityResponse<T, TResult> : BaseResponse<TResult>
    where T : class 
    where TResult : System.Enum
    {
        public T Entity { get; set; }
    }
}
