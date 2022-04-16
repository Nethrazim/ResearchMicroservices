using SO.BusinessLayer.Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Entities.Responses
{
    public class EntitiesResponse<T> : BaseResponse<BaseResult>
    where T : class
    {
        public List<T> Entity { get; set; }
    }

    public class EntitiesResponse<T, TResult> : BaseResponse<TResult>
    where T : class where TResult : System.Enum
    {
        public List<T> Entity { get; set; }
    }
}
