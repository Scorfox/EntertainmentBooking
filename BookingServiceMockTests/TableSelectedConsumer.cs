using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Contracts.RabbitMq.Events;
using MassTransit;

namespace BookingServiceMockTests
{
    public class TableSelectedConsumer:IConsumer<ITableSelected>
    {
        private readonly ILogger<TableSelectedConsumer> _logger;

        public TableSelectedConsumer(ILogger<TableSelectedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<ITableSelected> context)
        {
           _logger.Log(LogLevel.Error, $"DEBUG INFO: TABLE RESERVED ID {context?.Message?.TableId.ToString() ?? "!!!!!"}");
            return Task.CompletedTask;
        }
    }
}
