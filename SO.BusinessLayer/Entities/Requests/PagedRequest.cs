﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Entities.Requests
{
    public class PagedRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
