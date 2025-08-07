using Trak.UseCases.Invoices.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Invoices.Queries
{
    public record GetInvoiceByCustomerQuery(string Customer) : IQuery<Result<InvoiceDTO>>;
}
