using System.Text;
using System.Threading.Tasks;
using Mediator.Net.Context;
using Mediator.Net.Contracts;

namespace Mediator.Net.Middlewares.EventStore
{
    public interface IEventStoreService
    {
        Task WriteAsync(IPublishContext<IEvent> context);
    }
}