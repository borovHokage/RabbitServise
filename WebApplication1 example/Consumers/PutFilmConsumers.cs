using CRUD;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Models.BrokerRequest;
using Models.BrokerResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_example.Consumers
{
    public class PutFilmConsumer : IConsumer<PutFilmRequest>
    {
        private TaskDbContext dbcontext;
        public async Task Consume(ConsumeContext<PutFilmRequest> context)//, ConsumeContext<PutFilmRequest> contexFilms)
        {
            var filmId = context.Message.FilmId;

            var x = dbcontext.Films.FirstOrDefault(b => b.Id == filmId);
            if (x == null)
            { await context.RespondAsync(new OkResponse()); }
            else 
            {
                x.Id = context.Message.Value.Id;
                x.Name = context.Message.Value.Name;
                x.Year = context.Message.Value.Year;
            }
            dbcontext.SaveChanges();

            await context.RespondAsync(new OkResponse());
        }
        public PutFilmConsumer([FromServices] TaskDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
