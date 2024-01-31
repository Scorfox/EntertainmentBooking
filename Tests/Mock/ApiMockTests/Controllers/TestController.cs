using Base.Contracts.RabbitMq.Events;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiMockTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public TestController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task TryAuthAndReserv()
        {
            Guid id = Guid.NewGuid();
            await _publishEndpoint.Publish<IUserCredential>(new
            {
                UserId = id
            });

           
        }
    }
}
