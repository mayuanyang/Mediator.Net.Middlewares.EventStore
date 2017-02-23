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
        private readonly Func<bool> _shouldExecute;

        public EventStoreMiddlewareSpecification(IEventStoreService eventStoreService, Func<bool> shouldExecute )
        {
            _eventStoreService = eventStoreService;
            _shouldExecute = shouldExecute;
        }
        public bool ShouldExecute(IPublishContext<IEvent> context)
        {
            return _shouldExecute();
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
