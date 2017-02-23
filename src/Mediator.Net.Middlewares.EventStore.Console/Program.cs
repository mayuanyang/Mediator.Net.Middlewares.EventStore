using System.Threading.Tasks;
using Mediator.Net.Middlewares.EventStore.Console.Commands;

namespace Mediator.Net.Middlewares.EventStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new MediatorBuilder();
            var bus = builder.RegisterHandlers(typeof(Program).Assembly)
                .ConfigurePublishPipe(x =>
                {
                    x.UseEventStore(new EventStoreService(), () => true);
                }).Build();

            RunAsync(bus).Wait();
            System.Console.Read();
        }

        private static async Task RunAsync(IMediator bus)
        {
            for (int i = 0; i < 10; i++)
            {
                await bus.SendAsync(new SimpleCommand());
            }

        }
    }
}
