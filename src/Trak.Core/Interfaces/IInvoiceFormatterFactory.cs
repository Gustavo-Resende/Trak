namespace Trak.Core.Interfaces
{
    public interface IInvoiceFormatterFactory
    {
        IInvoiceFormatter GetFormatter(string formatType);
    }
}