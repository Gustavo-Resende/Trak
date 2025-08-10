using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trak.UseCases.Workouts.Command.CreateWorkout;
using Trak.UseCases.Workouts.Command.DeleteWorkout;
using Trak.UseCases.Workouts.Command.UpdateWorkout;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Queries;
using Valhalla.Lib.Result;

namespace Trak.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/workout")]
    public class WorkoutController : ControllerBase
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IMediator _mediator;

        public WorkoutController(ILogger<WorkoutController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new workout.
        /// </summary>
        /// <param name="command">The command containing the details of the workout to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created workout.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result<WorkoutDto>), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result<WorkoutDto>> WorkoutCreate([FromBody] CreateWorkoutCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        /// <summary>
        /// Gets all workouts.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of all workouts.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Result<WorkoutDto>), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result<List<WorkoutDto>>> Workouts(CancellationToken cancellationToken)
            => await _mediator.Send(new GetAllWorkoutQuery(), cancellationToken);

        /// <summary>
        /// Updates an existing workout.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Result<WorkoutDto>), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result<WorkoutDto>> UpdateWorkout([FromBody] UpdateWorkoutCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Deletes an existing workout.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Result<WorkoutDto>), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result> DeleteWorkout([FromQuery] DeleteWorkoutCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }
    }
}