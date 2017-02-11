using System;
using Mediator.Net.Contracts;

namespace Mediator.Net.Middlewares.EventStore.Console.Events
{
    [Serializable]
    public class OrderPlacedEvent : IEvent
    {
        public Guid Id { get; }
        public decimal Amount { get; }

        public OrderPlacedEvent(Guid id, decimal amount )
        {
            Id = id;
            Amount = amount;
        }
    }
}
