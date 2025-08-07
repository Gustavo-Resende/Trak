using Trak.UseCases.Invoices.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Invoices.Commands.SummarizeInvoice
{
    public record SummarizeInvoiceCommand(string Customer) : ICommand<Result<InvoiceDTO>>;
}
