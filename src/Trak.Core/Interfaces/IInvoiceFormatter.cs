using Trak.Core.InvoiceAggregate;

namespace Trak.Core.Interfaces
{
    public interface IInvoiceFormatter
    {
        string Format(Invoice invoice);
    }
}
