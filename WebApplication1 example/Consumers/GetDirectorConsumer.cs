using MassTransit;
using Models.BrokerRequest;
using Models.BrokerResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_example.Consumers
{
    public class GetDirectorConsumer : IConsumer<GetDirectorRequest>
    {
        public async Task Consume(ConsumeContext<GetDirectorRequest> context)
        {
            var directorId = context.Message.DirectorId;
            await context.RespondAsync(new GetDirectorResponse { Value = new Models.Director { DirId = Guid.NewGuid() } });
        }
    }
}
