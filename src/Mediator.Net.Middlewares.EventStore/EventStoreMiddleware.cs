using Mediator.Net.Pipeline;

namespace Mediator.Net.Middlewares.EventStore
{
    public static class EventStoreMiddleware
    {
        public static void UseEventStore(this IPublishPipeConfigurator configurator, IEventStoreService service = null)
        {
            if (service == null)
            {
                service = configurator.DependancyScope.Resolve<IEventStoreService>();
            }
            
            configurator.AddPipeSpecification(new EventStoreMiddlewareSpecification(service));
        }
    }
}
