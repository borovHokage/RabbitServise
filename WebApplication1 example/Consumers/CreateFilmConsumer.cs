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
    public class CreateFilmConsumer : IConsumer<CreateFilmRequest>
    {
        private TaskDbContext dbcontext;
        public async Task Consume(ConsumeContext<CreateFilmRequest> context)
        {
            dbcontext.Films.Add(new DbFilm 
            { 
                Id = context.Message.Value.Id,
                Name = context.Message.Value.Name,
                Year = context.Message.Value.Year
            });
            dbcontext.SaveChanges();
            await context.RespondAsync(new OkResponse());
        }
        public CreateFilmConsumer([FromServices] TaskDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
