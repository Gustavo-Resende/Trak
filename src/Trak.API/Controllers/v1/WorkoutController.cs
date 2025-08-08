using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Queries;
using Valhalla.Lib.Result;

namespace Trak.API.Controllers.v1
{
    public class WorkoutController
    {
        private readonly IMediator _mediator;

        public WorkoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all workouts.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Result<List<WorkoutDto>>), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result<List<WorkoutDto>>> GetAll(CancellationToken cancellationToken)
            => await _mediator.Send(new GetAllWorkoutQuery(), cancellationToken);

    }
}
