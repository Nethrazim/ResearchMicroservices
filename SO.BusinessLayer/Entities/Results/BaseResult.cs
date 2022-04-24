using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SO.BusinessLayer.Entities.Results
{
    public enum BaseResult
    {
        [Description("Error")]
        Error = -1,

        [Description("Success")]
        Success = 0,

        [Description("Warning")]
        Warning = 1
    }
}
