using Trak.Core.InvoiceAggregate;
using Trak.UseCases.Invoices.Dtos;

namespace Trak.UseCases.Invoices.Extensions
{
    public static class InvoiceExtensions
    {
        public static InvoiceDTO ParseDTO(this Invoice invoice)
            => new(invoice.Customer, invoice.Performances);
    }
}