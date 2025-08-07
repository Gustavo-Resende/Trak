using Trak.Core.PlayAggregate;
using Trak.UseCases.Plays.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Plays.Commands
{
    public record CreatePlayCommand(string Name, int Lines, PlayType Type) : ICommand<Result<PlayDTO>>;
}
