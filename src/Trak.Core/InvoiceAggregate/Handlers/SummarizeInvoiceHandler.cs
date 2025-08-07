using MediatR;
using Trak.Core.Interfaces;
using Trak.Core.InvoiceAggregate.Events.Domain;

namespace Trak.Core.InvoiceAggregate.Handlers
{
    internal class SummarizeInvoiceHandler : INotificationHandler<SummarizeInvoiceEvent>
    {
        private readonly IEventBus _eventBus;

        public SummarizeInvoiceHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(SummarizeInvoiceEvent notification, CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(notification, cancellationToken);
        }
    }
}
