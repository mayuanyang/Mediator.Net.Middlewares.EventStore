using System.Threading.Tasks;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Mediator.Net.Middlewares.EventStore.Console.Events;

namespace Mediator.Net.Middlewares.EventStore.Console.EventHandlers
{
    class OrderPlacedEventHandler :IEventHandler<OrderPlacedEvent>
    {
        public Task Handle(IReceiveContext<OrderPlacedEvent> context)
        {
            return Task.FromResult(0);
        }
    }
}
