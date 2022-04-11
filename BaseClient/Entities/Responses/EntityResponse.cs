using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClientNS.Entities.Responses
{ 
    public class EntityResponse<T> : BaseResponse
    where T : class
    {
        public T Entity { get; set; }
    }

    public class EntityValueResponse<T> : BaseResponse
    where T : struct
    {
        public T Result { get; set; }
    }
}
