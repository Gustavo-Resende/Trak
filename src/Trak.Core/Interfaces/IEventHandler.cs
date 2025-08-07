using Valhalla.Lib.SharedKernel;

namespace Trak.Core.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : DomainEventBase
    {
        Task HandleAsync(TEvent @event, CancellationToken ct);
    }
}