using Trak.Core.PlayAggregate;

namespace Trak.UseCases.Plays.Dtos
{
    public record PlayDTO(Guid Id, string Name, PlayType Type);
}
