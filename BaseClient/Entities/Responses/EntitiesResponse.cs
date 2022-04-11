using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClientNS.Entities.Responses
{
    public class EntitiesResponse<T> : BaseResponse
    where T : class
    {
        public List<T> Entity { get; set; }
    }
}
