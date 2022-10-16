using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Messaging.Process
{
    public interface IBasePublishProcess<T> where T : class 
    {
        Task Publish();
        Task StopProcess();
        Task StartProcess();
        Task<List<T>> GetEventsToPublish();
    }
}
