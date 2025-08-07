﻿using Trak.Core.PlayAggregate;
using Trak.UseCases.Plays.Dtos;
using Trak.UseCases.Plays.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Plays.Commands
{
    public class CreatePlayHandler : ICommandHandler<CreatePlayCommand, Result<PlayDTO>>
    {
        private readonly IRepository<Play> _playRepository;

        public CreatePlayHandler(IRepository<Play> playRepository)
        {
            _playRepository = playRepository;
        }

        public async Task<Result<PlayDTO>> Handle(CreatePlayCommand request, CancellationToken cancellationToken)
        {
            var play = new Play(request.Name, request.Lines, request.Type);
            var newPlay = await _playRepository.AddAsync(play, cancellationToken);

            await _playRepository.SaveChangesAsync(cancellationToken);

            return Result.Success(newPlay.ParseDTO());
        }
    }
}
