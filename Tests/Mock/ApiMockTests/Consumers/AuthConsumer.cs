using Base.Contracts.RabbitMq;
using Base.Contracts.RabbitMq.Events;
using MassTransit;

namespace ApiMockTests.Consumers
{
    public class AuthConsumer : IConsumer<IUserCredential>
    {
        public async Task Consume(ConsumeContext<IUserCredential> context)
        {
            await context.RespondAsync<IReservationRequest>(new {UserId = context.Message.UserId});
        }
    }
}
