﻿using Trak.Core.PlayAggregate;
using Trak.UseCases.Plays.Dtos;
using Trak.UseCases.Plays.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Plays.Queries.GetAllPlay
{
    public class GetAllPlayHandler : IQueryHandler<GetAllPlayQuery, Result<ListPlayDTO>>
    {
        private readonly IReadRepository<Play> _playRepository;

        public GetAllPlayHandler(IReadRepository<Play> playRepository)
        {
            _playRepository = playRepository;
        }

        public async Task<Result<ListPlayDTO>> Handle(GetAllPlayQuery request, CancellationToken cancellationToken)
        {
            var plays = await _playRepository.ListAsync(cancellationToken);
            if (!plays.Any())
                return Result.NotFound();

            return Result.Success(plays.ParseDTO());
        }
    }
}