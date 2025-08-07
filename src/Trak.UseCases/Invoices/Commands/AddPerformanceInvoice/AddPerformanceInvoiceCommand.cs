using Trak.Core.InvoiceAggregate;
using Trak.UseCases.Invoices.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Invoices.Commands.AddPerformanceInvoice
{
    public record AddPerformanceInvoiceCommand(string Customer, Performance Performance) : ICommand<Result<InvoiceDTO>>;
}
