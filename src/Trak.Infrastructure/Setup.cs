using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trak.Core.Interfaces;
using Trak.Infrastructure.Data.PostgreSQL;
using Trak.Infrastructure.EventBus;
using Trak.Infrastructure.Formatter;
using Valhalla.Lib.SharedKernel;

namespace Trak.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ILogger logger, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PgSqlDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddSingleton<InMemoryEventBus>();
            services.AddSingleton<IEventBus>(sp => sp.GetRequiredService<InMemoryEventBus>());
            services.AddHostedService<LocalEventConsumer>();

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            services.AddScoped<TextInvoiceFormatter>();
            services.AddScoped<XmlInvoiceFormatter>();
            services.AddScoped<IInvoiceFormatterFactory, InvoiceFormatterFactory>();

            services.AddMediatRDomainEventDispatcher(logger);

            logger.LogInformation("{Project} services registered", "Infrastructure");


            return services;
        }
    }
}
