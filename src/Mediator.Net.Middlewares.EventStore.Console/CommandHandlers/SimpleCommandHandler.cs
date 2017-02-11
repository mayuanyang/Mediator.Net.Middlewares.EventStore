using System;
using System.Threading.Tasks;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Mediator.Net.Middlewares.EventStore.Console.Commands;
using Mediator.Net.Middlewares.EventStore.Console.Events;

namespace Mediator.Net.Middlewares.EventStore.Console.CommandHandlers
{
    class SimpleCommandHandler : ICommandHandler<SimpleCommand>
    {
        public async Task Handle(ReceiveContext<SimpleCommand> context)
        {
            await context.PublishAsync(new OrderPlacedEvent(Guid.NewGuid(), 100));
        }
    }
}
