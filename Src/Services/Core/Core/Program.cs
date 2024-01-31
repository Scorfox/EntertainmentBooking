using Core.Helpers;
using Core.Logic.Saga;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static MassTransit.MessageHeaders;
using Host = Microsoft.Extensions.Hosting.Host;

namespace Core;

internal class Program
{
    static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).RunAsync();
    }

    public static Microsoft.Extensions.Hosting.IHost CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, service) =>
            {
                service.AddMassTransit(cfg =>
                {
                    cfg.AddSagaStateMachine<BookingStateMachine, BookingState>()
                        .InMemoryRepository();
                    cfg.UsingRabbitMq((_, busFactoryConfigurator) =>
                    {
                        RabbitMqConfigurator.ConfigureBus(busFactoryConfigurator);
                    });
                });
            }).Build();
}
