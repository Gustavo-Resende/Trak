using Trak.Core.Interfaces;
using Trak.UseCases.Invoices.Dtos;
using Trak.UseCases.Invoices.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Invoices.Commands.AddPerformanceInvoice
{
    internal class AddPerformanceInvoiceHandler : ICommandHandler<AddPerformanceInvoiceCommand, Result<InvoiceDTO>>
    {
        private readonly IInvoiceService _invoiceService;

        public AddPerformanceInvoiceHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<Result<InvoiceDTO>> Handle(AddPerformanceInvoiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _invoiceService.AddPerformanceAsync(request.Customer, request.Performance, cancellationToken);

            if (!result.IsSuccess)
                return Result.Error(result.Errors.ToArray());

            return Result.Success(result.Value.ParseDTO());
        }
    }
}
