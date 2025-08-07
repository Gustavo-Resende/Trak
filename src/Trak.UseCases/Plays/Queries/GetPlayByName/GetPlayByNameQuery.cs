using Trak.UseCases.Plays.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Plays.Queries.GetPlayByName
{
    public record GetPlayByNameQuery(string Name) : IQuery<Result<PlayDTO>>;
}
