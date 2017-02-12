![Build status](https://ci.appveyor.com/api/projects/status/c3j3jfuvpe5cafrp?svg=true) [![Mediator.Net on Stack Overflow](https://img.shields.io/badge/stack%20overflow-Mediator.Net-yellowgreen.svg)](http://stackoverflow.com/questions/tagged/memdiator.net)

# Mediator.Net.Middlewares.EventStore
Middleware for Mediator.Net to write event to GetEventStore, it is a Middleware for Mediator.Net that plugs intothe publish pipeline

## Setup
Create a BusBuilder as normal and add this middleware by using .ConfigurePublishPipe
```C#

var bus = builder.RegisterHandlers(typeof(Program).Assembly)
  .ConfigurePublishPipe(x =>
        {
            // Add this middleware into the PublishPipe
            x.UseEventStore(new EventStoreService());
        }).Build();
   
   // Send the command, any event that being raised by the behavior triggered by 
   // this command will then be sent to EventStore
   await bus.SendAsync(new SimpleCommand());
                
```

## Configuration
Add the following settings into you app/web.config
```C#
<appSettings>
    <add key="EventStore.IpAddress" value="127.0.0.1"/>
    <add key="EventStore.Port" value="1113"/>
    <add key="EventStore.StreamName" value="Whatever"/>
    <add key="EventStore.StreamVersion" value="1"/>
</appSettings>
```
