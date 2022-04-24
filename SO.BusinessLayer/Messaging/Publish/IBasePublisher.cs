using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Messaging.Publish
{
    public interface IBasePublisher<T> where T : class
    {
        Task Publish(T entity);
    } 
}
