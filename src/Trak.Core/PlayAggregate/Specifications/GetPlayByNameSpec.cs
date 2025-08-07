using Valhalla.Lib.Specification;

namespace Trak.Core.PlayAggregate.Specifications
{
    public class GetPlayByNameSpec : Specification<Play>
    {
        public GetPlayByNameSpec(string name)
        {
            Query
                .Where(p => p.Name == name);
        }
    }
}
