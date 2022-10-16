using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SO.Messaging.Process
{
    public abstract class BasePublishProcess<T> : IBasePublishProcess<T>, IDisposable
    where T : class
    {
        public IMapper Mapper;

        private static bool isRunning = true;
        public IBasePublisher<T> Publisher { get; private set; }

        public BasePublishProcess(IBasePublisher<T> publisher, IMapper mapper)
        {
            this.Publisher = publisher;
            this.Mapper = mapper;
        }

        public async Task Publish()
        {
            Task.Run(async () =>
            {
                while (isRunning)
                {
                    try
                    {
                        List<T> listOfEvents = await GetEventsToPublish();

                        foreach (T _event in listOfEvents)
                        {
                            Publisher.Publish(_event);
                        }

                        await this.UpdateEventsAsPublished(listOfEvents);
                    }
                    catch (Exception ex)
                    {

                    }

                    Thread.Sleep(4000);
                }
            });
        }

        public async Task StopProcess()
        {
            isRunning = false;    
        }

        public async Task StartProcess()
        {
            isRunning = true;
            await Publish();
        }

        public abstract Task<List<T>> GetEventsToPublish();
        public abstract Task UpdateEventsAsPublished(List<T> events);

        public void Dispose()
        {
    
        }
    }
}
