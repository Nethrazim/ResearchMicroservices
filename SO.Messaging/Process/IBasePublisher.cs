using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Messaging.Process
{
    public interface IBasePublisher<T> where T : class
    {
        Task Publish(T entity);
    } 
}
