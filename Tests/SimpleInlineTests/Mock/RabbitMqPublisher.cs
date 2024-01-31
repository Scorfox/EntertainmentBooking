using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Contracts.RabbitMq.Events;
using Core.Helpers;
using MassTransit;

namespace SimpleInlineTests.Mock
{
    public class RabbitMqPublisher
    {
        private readonly IBusControl _busControl = Bus.Factory.CreateUsingRabbitMq(RabbitMqConfigurator.ConfigureBus);

        public void UserAuthorized(Guid userId)
        {
            _busControl.Publish<IUserCredential>(new User() {UserId = userId}).Wait();
        }
        public void UserSelectTable(Guid userId, Guid table) { }


    }
}
