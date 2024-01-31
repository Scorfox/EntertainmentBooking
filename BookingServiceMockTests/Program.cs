using Base.Contracts.RabbitMq;
using Base.Contracts.RabbitMq.Events;
using Base.Objects;
using BookingServiceMockTests;
using Core.Helpers;
using MassTransit;
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
                service.AddLogging(l=>l.AddDebug());
                service.AddMassTransit(cfg =>
                {
                    cfg.AddConsumer<TableSelectedConsumer>();
                    cfg.AddConsumer<ReservationRequestConsumer>();
                    cfg.AddRequestClient<IReservationRequest>();


                        cfg.UsingRabbitMq((context, config) =>
                        {

                            config.ConfigureEndpoints(context);

                            config.Host(new Uri($"rabbitmq://{BookingConstants.RabbitMqHost}:{BookingConstants.RabbitMqPort}/"), "/", h =>
                            {
                                h.Username(BookingConstants.RabbitMqUser);
                                h.Password(BookingConstants.RabbitMqPass);
                            });
                        });
                    
                });
            }).Build();
}