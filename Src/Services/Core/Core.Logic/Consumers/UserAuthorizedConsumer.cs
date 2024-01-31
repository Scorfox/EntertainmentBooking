using Base.Contracts.RabbitMq;
using Base.Contracts.RabbitMq.Events;
using MassTransit;

namespace Core.Logic.Consumers
{
    public class UserAuthorizedConsumer:IConsumer<IUserCredential>
    {
        public async Task Consume(ConsumeContext<IUserCredential> context)
        {
            if (context.RequestId != null)
            {
                await context.RespondAsync(new{UserId = context.Message.UserId});
            }
        }
    }
}
