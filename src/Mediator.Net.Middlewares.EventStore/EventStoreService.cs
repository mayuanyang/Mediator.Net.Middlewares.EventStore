using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Newtonsoft.Json;

namespace Mediator.Net.Middlewares.EventStore
{
    public class EventStoreService : IEventStoreService
    {
        public async Task WriteAsync(IPublishContext<IEvent> context)
        {
            var ip = ConfigurationManager.AppSettings["EventStore.IpAddress"];
            var port = ConfigurationManager.AppSettings["EventStore.Port"];
            var streamName = ConfigurationManager.AppSettings["EventStore.StreamName"];
            
            if (ip == null)
            {
                throw new ConfigurationErrorsException("EventStore.IpAddress is missing in config file");
            }
            if (port == null)
            {
                throw new ConfigurationErrorsException("EventStore.Port is missing in config file");
            }

            if (streamName == null)
            {
                throw new ConfigurationErrorsException("EventStore.StreamName is missing in config file");
            }

            object eventMetadata = null;
            if (context.MetaData.ContainsKey("EventMetaData"))
            {
                eventMetadata = context.MetaData["EventMetaData"];
            }
            
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Parse(ip), int.Parse(port)));
            await connection.ConnectAsync();

            var json = JsonConvert.SerializeObject(context.Message);
            var data = Encoding.UTF8.GetBytes(json);

            var metaDataJsonContent = new byte[0];
            if (eventMetadata != null)
            {
                var metaDataJson = JsonConvert.SerializeObject(eventMetadata);
                metaDataJsonContent = Encoding.UTF8.GetBytes(metaDataJson);
            }

            var eventData = new EventData(Guid.NewGuid(), nameof(context.Message), true, data, metaDataJsonContent);

            await connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventData);
        }
    }
}