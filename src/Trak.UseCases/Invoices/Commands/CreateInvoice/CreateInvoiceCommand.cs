using Trak.UseCases.Invoices.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Invoices.Commands.CreateInvoice
{
    public record CreateInvoiceCommand(string Customer) : ICommand<Result<InvoiceDTO>>;
}
