using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Trak.Core.Interfaces;
using Trak.Core.Services;
using Valhalla.Lib.SharedKernel;

namespace Trak.Core
{
    public static class Setup
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, ILogger logger)
        {
            services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            logger.LogInformation("{Project} services registered", "Core");

            return services;
        }
    }
}
