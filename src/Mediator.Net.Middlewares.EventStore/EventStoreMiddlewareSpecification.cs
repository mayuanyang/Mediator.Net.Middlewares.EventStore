using System;
using System.Threading.Tasks;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Mediator.Net.Pipeline;

namespace Mediator.Net.Middlewares.EventStore
{
    public class EventStoreMiddlewareSpecification : IPipeSpecification<IPublishContext<IEvent>>
    {
        private readonly IEventStoreService _eventStoreService;

        public EventStoreMiddlewareSpecification(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }
        public bool ShouldExecute(IPublishContext<IEvent> context)
        {
            return true;
        }

        public async Task ExecuteBeforeConnect(IPublishContext<IEvent> context)
        {
            if (ShouldExecute(context))
            {
                await _eventStoreService.WriteAsync(context);
            }
        }

        public Task ExecuteAfterConnect(IPublishContext<IEvent> context)
        {
            return Task.FromResult(0);
        }
    }
}
