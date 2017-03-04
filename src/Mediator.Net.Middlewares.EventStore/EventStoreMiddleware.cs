using System;
using Mediator.Net.Pipeline;

namespace Mediator.Net.Middlewares.EventStore
{
    public static class EventStoreMiddleware
    {
        public static void UseEventStore(this IPublishPipeConfigurator configurator, IEventStoreService service = null, Func<bool> shouldExecute = null)
        {
            if (configurator == null)
            {
                throw new ArgumentException(nameof(configurator));
            }
            if (service == null)
            {
                service = configurator.DependancyScope.Resolve<IEventStoreService>();
            }
            if (service == null)
            {
                throw new ArgumentException($"{nameof(IEventStoreService)} is neither provided nor registered from the dependancy injection container");
            }
            
            configurator.AddPipeSpecification(new EventStoreMiddlewareSpecification(service, shouldExecute));
        }
    }
}
