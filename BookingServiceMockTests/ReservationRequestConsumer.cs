
using System.Security.Cryptography.X509Certificates;
using Base.Contracts.RabbitMq;
using Base.Contracts.RabbitMq.Events;
using MassTransit;

namespace BookingServiceMockTests
{
    public class ReservationRequestConsumer:IConsumer<IReservationRequest>
    {
        public async Task Consume(ConsumeContext<IReservationRequest> context)
        {
            await context.Publish<ITableSelected>(new
            {
                UserId = context.Message.UserId,
                TableId = Guid.NewGuid()
            });
        }
    }
}
