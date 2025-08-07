using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trak.Core.Interfaces;
using Trak.Infrastructure.Data.SQLServer;
using Trak.Infrastructure.EventBus;
using Trak.Infrastructure.Formatter;
using Valhalla.Lib.SharedKernel;

namespace Trak.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ILogger logger)
        {
            services.AddDbContext<SqlDbContext>(options =>
            {
                options.UseSqlite("Data Source=Valhalla.db");
            });

            services.AddSingleton<InMemoryEventBus>();
            services.AddSingleton<IEventBus>(sp => sp.GetRequiredService<InMemoryEventBus>());
            services.AddHostedService<LocalEventConsumer>();

            services.AddScoped<SqlDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            services.AddScoped<TextInvoiceFormatter>();
            services.AddScoped<XmlInvoiceFormatter>();
            services.AddScoped<IInvoiceFormatterFactory, InvoiceFormatterFactory>();

            services.AddMediatRDomainEventDispatcher(logger);

            logger.LogInformation("{Project} services registered", "Infrastructure");


            return services;
        }
    }
}
