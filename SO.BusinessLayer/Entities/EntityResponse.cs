using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Entities
{
    public class EntityResponse<T> : BaseResponse
    where T : class
    {
        public T Entity { get; set; }
    }

    public class ValueResponse<T> : BaseResponse
    where T : struct
    {
        public T Result { get; set; }  
    }
}
