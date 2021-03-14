using MassTransit;
using Models.BrokerRequest;
using Models.BrokerResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_example.Consumers
{
    public class GetFilmConsumer : IConsumer<GetFilmRequest>
    {
        public async Task Consume(ConsumeContext<GetFilmRequest> context)
        {
            var filmId = context.Message.FilmId; 
            await context.RespondAsync(new GetFilmResponse { Value = new Models.Film { Id = Guid.NewGuid()} });   
        }
    }
}
