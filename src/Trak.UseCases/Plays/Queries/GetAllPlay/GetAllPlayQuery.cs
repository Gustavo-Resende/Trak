using Trak.UseCases.Plays.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Plays.Queries.GetAllPlay
{
    public record GetAllPlayQuery() : IQuery<Result<ListPlayDTO>>;
}
