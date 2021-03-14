using CRUD;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models.BrokerRequest;
using Models.BrokerResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_example.Consumers
{
    public class DeleteFilmConsumer : IConsumer<DeleteFilmRequest>
    {
        private TaskDbContext dbcontext;
        public async Task Consume(ConsumeContext<DeleteFilmRequest> context)
        {
            var filmId = context.Message.FilmId;
            var x = dbcontext.Films.FirstOrDefault(b => b.Id == filmId);
            if (x == null)
            { await context.RespondAsync(new OkResponse()); }
            else
            {
                dbcontext.Films.Remove(x);
            }
            dbcontext.SaveChanges();

            await context.RespondAsync(new OkResponse());
        
        }
        public DeleteFilmConsumer([FromServices] TaskDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
