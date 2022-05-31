using Newtonsoft.Json;
using SO.BusinessLayer.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Entities.Responses
{
    public class ValueResponse<T> : BaseResponse<BaseResult>
       where T : struct
    {
        public T Value { get; set; }
    }

    public class ValueResponse<T,TEnum> : BaseResponse<TEnum>
        where T : struct
        where TEnum: System.Enum
    { 
        public T Value { get; set; }
    }
}
