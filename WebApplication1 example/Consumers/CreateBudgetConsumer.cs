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
    public class CreateBudgetConsumer : IConsumer<CreateBudgetRequest>
    {
         private TaskDbContext dbcontext;
        public async Task Consume(ConsumeContext<CreateBudgetRequest> context)
        {
            dbcontext.Budgetss.Add(new DbBudget
            {
                BudgetId = context.Message.Value.BudgetId,
                Sum = context.Message.Value.Sum
            });
            dbcontext.SaveChanges();
            await context.RespondAsync(new OkResponse());
        }

        public CreateBudgetConsumer([FromServices] TaskDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
    }
}
