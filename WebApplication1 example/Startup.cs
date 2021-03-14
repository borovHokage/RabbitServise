using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using System;
using Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1_example.Consumers;

namespace CRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<GetFilmsCommand>();
            //services.AddTransient<PutFilmCommand>();
            services.AddDbContext<TaskDbContext>();
            services.AddControllers();
            services.AddMassTransitHostedService();
            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateDirectorConsumer>();
                x.AddConsumer<CreateFilmConsumer>();
                x.AddConsumer<CreateBudgetConsumer>();
                x.AddConsumer<GetDirectorConsumer>();
                x.AddConsumer<GetBudgetConsumer>();
                x.AddConsumer<GetFilmConsumer>();
                x.AddConsumer<PutFilmConsumer>();
                x.AddConsumer<DeleteFilmConsumer>();
                x.UsingRabbitMq((context, cfg) =>//??????? ??????? ??? ????? ???????????? ???????
                {
                    cfg.Host("localhost", "/", host =>
                    {
                        host.Username("service1");
                        host.Password("service1");
                    });
                    cfg.ReceiveEndpoint("getfilm", ep =>
                    {
                        ep.ConfigureConsumer<GetFilmConsumer>(context);
                    });
                    cfg.ReceiveEndpoint("getdirector", ep =>
                    {
                        ep.ConfigureConsumer<GetDirectorConsumer>(context);
                    });
                    cfg.ReceiveEndpoint("getbudget", ep =>
                    {
                        ep.ConfigureConsumer<GetBudgetConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("createfilm", ep =>
                    {
                        ep.ConfigureConsumer<CreateFilmConsumer>(context);
                    });
                    cfg.ReceiveEndpoint("createdirector", ep =>
                    {
                        ep.ConfigureConsumer<CreateDirectorConsumer>(context);
                    });
                    cfg.ReceiveEndpoint("createbudget", ep =>
                    {
                        ep.ConfigureConsumer<CreateBudgetConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("puttfilm", ep =>
                    { 
                        ep.ConfigureConsumer<PutFilmConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("delfilm", ep =>
                    {
                        ep.ConfigureConsumer<DeleteFilmConsumer>(context);
                    });
                });

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            UpdateDatabase(app);
        }
        private void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TaskDbContext>();
            context.Database.Migrate();
        }
    }
}
