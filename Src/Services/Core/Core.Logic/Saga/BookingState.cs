using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Objects;
using MassTransit;

namespace Core.Logic.Saga
{
    public class BookingState: SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public int StateId { get; set; }

        public Entity Entity { get; set; }

    }
}
