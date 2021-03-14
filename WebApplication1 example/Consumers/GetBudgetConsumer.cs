using MassTransit;
using Models.BrokerRequest;
using Models.BrokerResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_example.Consumers
{
    public class GetBudgetConsumer : IConsumer<GetBudgetRequest>
    {
        public async Task Consume(ConsumeContext<GetBudgetRequest> context)
        {
            var budgetrId = context.Message.BudgetId;
            await context.RespondAsync(new GetBudgetResponse { Value = new Models.Budget { BudgetId = Guid.NewGuid() } });
        }
    }
}
