using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Messaging.Events
{
    public class EventChanged : IEvent2
    {
        public string Message { get; set; }
    }
}
