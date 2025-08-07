using Trak.Core.InvoiceAggregate;

namespace Trak.UseCases.Invoices.Dtos
{
    public record InvoiceDTO(string Customer, IEnumerable<Performance> Performances);
}
