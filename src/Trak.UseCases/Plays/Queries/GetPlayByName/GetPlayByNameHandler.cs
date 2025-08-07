using Trak.Core.PlayAggregate;
using Trak.Core.PlayAggregate.Specifications;
using Trak.UseCases.Plays.Dtos;
using Trak.UseCases.Plays.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Plays.Queries.GetPlayByName
{
    public class GetPlayByNameHandler : IQueryHandler<GetPlayByNameQuery, Result<PlayDTO>>
    {
        private readonly IReadRepository<Play> _playRepository;

        public GetPlayByNameHandler(IReadRepository<Play> playRepository)
        {
            _playRepository = playRepository;
        }

        public async Task<Result<PlayDTO>> Handle(GetPlayByNameQuery request, CancellationToken cancellationToken)
        {
            var play = await _playRepository.FirstOrDefaultAsync(new GetPlayByNameSpec(request.Name), cancellationToken);
            if (play is null)
                return Result.NotFound();

            return Result.Success(play.ParseDTO());
        }
    }
}
