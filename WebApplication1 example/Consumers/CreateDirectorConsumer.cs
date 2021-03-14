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
    public class CreateDirectorConsumer : IConsumer<CreateDirectorRequest>
    {
            private TaskDbContext dbcontext;
        public async Task Consume(ConsumeContext<CreateDirectorRequest> context)
        {
            dbcontext.Directors.Add(new DbDirector
            {
                DirId = context.Message.Value.DirId,
                Name = context.Message.Value.Name
            });
            dbcontext.SaveChanges();
            await context.RespondAsync(new OkResponse());
        }
    
        public CreateDirectorConsumer([FromServices] TaskDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
