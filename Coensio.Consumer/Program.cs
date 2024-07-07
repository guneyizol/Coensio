using Coensio.Consumer.Consumers;
using Coensio.Contexts;

using MassTransit;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using System.Threading.Tasks;

namespace Coensio.Consumer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();

                        x.AddConsumer<CoensioConsumer>();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("rabbitmq", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    services.AddDbContext<TestContext>(opts =>
                        opts.UseNpgsql(hostContext.Configuration.GetConnectionString("Postgres"))
                        .UseSnakeCaseNamingConvention());
                });
    }
}
