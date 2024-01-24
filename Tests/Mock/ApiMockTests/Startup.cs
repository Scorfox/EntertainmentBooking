using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiMockTests.Consumers;
using Base.Contracts.RabbitMq.Events;
using Base.Objects;
using Base.Objects.Helpers;
using MassTransit;
using Microsoft.OpenApi.Models;
using Prometheus;

namespace ApiMockTests
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestsWebApi", Version = "v1" });
            });

            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<AuthConsumer>();
                cfg.AddRequestClient<IUserCredential>();


                cfg.UsingRabbitMq((context, config) =>
                {
                    
                    config.ConfigureEndpoints(context);

                    config.Host(new Uri($"rabbitmq://{BookingConstants.RabbitMqHost}:{BookingConstants.RabbitMqPort}/"), "/", h =>
                    {
                        h.Username(BookingConstants.RabbitMqUser);
                        h.Password(BookingConstants.RabbitMqPass);
                    });
                });
            });


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserWebApi v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapMetrics();
                endpoints.MapControllers();
            });
        }
    }
}
