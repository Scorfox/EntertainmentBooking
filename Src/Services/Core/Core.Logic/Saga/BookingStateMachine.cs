using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Contracts.RabbitMq;
using Base.Contracts.RabbitMq.Events;
using MassTransit;

namespace Core.Logic.Saga
{
    public class BookingStateMachine:MassTransitStateMachine<BookingState>
    {
        #region State machine logic
        
        public Event<IUserCredential> UserAuthorized { get; set; }
        public Event<ITableSelected> TableSelected { get; set; }
        public State AwaitingReservationConfirmation { get; set; }
        public State AwaitingReservationSelection { get; set; }

        #endregion
        #region Ctor...

        protected BookingStateMachine()
        {

            InitializeStateMachine();
            InitializeStateLogic();
        }


        #region Logic

        private void InitializeStateLogic()
        {
            Initially(When(UserAuthorized).
                Then(context =>
                {
                    context.Saga.CorrelationId = context.Message.UserId;

                })
                .PublishAsync(context => context.Init<IReservationRequest>(new {UserId = context.Saga.CorrelationId}))
                .TransitionTo(AwaitingReservationSelection)
            );

            During(AwaitingReservationSelection,
                When(TableSelected)
                    .PublishAsync(x=>x.Init<ITableSelected>(new
                {
                    UserId = x.Saga.CorrelationId,  TableId = x.Saga.Entity.Id
                })).Finalize());
        }
        private void InitializeStateMachine()
        {
            InstanceState(x => x.StateId);
            Event(()=>UserAuthorized, context=>context.CorrelateById(x=>x.Message.UserId));
            Event(() => TableSelected, context => context.CorrelateById(x => x.Message.UserId));
        }
        
        #endregion
        

        #endregion
    }
}
