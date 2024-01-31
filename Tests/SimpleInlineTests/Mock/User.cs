using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Contracts.RabbitMq.Events;

namespace SimpleInlineTests.Mock
{
    public class User:IUserCredential
    {
        public Guid UserId { get; set; }
    }
}
