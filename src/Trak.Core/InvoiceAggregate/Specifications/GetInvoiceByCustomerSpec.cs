using Valhalla.Lib.Specification;

namespace Trak.Core.InvoiceAggregate.Specifications
{
    public class GetInvoiceByCustomerSpec : Specification<Invoice>
    {
        public GetInvoiceByCustomerSpec(string customer)
        {
            Query
                .Where(p => p.Customer == customer)
                .Include(p => p.Performances);
        }
    }
}