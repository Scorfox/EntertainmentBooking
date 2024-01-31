using MassTransit;

namespace ApiMockTests.Consumers;

public class AuthConsumerDefinition : ConsumerDefinition<AuthConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<AuthConsumer> consumerConfigurator,
        IRegistrationContext context)
    {
        //endpointConfigurator.UseInMemoryOutbox();
    }
}