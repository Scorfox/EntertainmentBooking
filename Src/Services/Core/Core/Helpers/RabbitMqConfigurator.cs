using Base.Objects;
using Base.Objects.Helpers;
using Core.Logic.Consumers;
using MassTransit;
using MassTransit.Monitoring;
using MassTransit.RabbitMqTransport.Configuration;

namespace Core.Helpers
{
    internal class RabbitMqConfigurator
    {
        #region Public members

        public static void ConfigureBus(IRabbitMqBusFactoryConfigurator cfg)
        {
            cfg.Host(new Uri($"rabbitmq://{BookingConstants.RabbitMqHost}:{BookingConstants.RabbitMqPort}/"), ConfigureHost);
            
            BuildEndpoints(cfg);
        }


        #endregion

        #region Connection config

        private static void ConfigureHost(IRabbitMqHostConfigurator host)
        {
            host.Username(BookingConstants.RabbitMqUser);
            host.Password(BookingConstants.RabbitMqPass);
        }

        #endregion

        #region Endpoints config

        private static void BuildEndpoints(IRabbitMqBusFactoryConfigurator configurator)
        {
            configurator.ReceiveEndpoint(RabbitMqChannels.DataServiceChannel, DataServiceEndpointConfiguration);
        }

        public static void DataServiceEndpointConfiguration(IRabbitMqReceiveEndpointConfigurator endpoint)
        {
            endpoint.Lazy = true;
            endpoint.PrefetchCount = 20;
            endpoint.ConfigureConsumeTopology = false;
            endpoint.Bind(RabbitMqChannels.DataServiceChannelBind);
            endpoint.Consumer<DataAccessConsumer>();
        }

        #endregion
    }
}
