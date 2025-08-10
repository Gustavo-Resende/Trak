using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trak.UseCases.Exercises.Command.CreateExercise;
using Trak.UseCases.Exercises.Command.DeleteExercise;
using Trak.UseCases.Exercises.Command.UpdateExercise;
using Trak.UseCases.Exercises.Dtos;
using Trak.UseCases.Exercises.Queries;
using Valhalla.Lib.Result;

namespace Trak.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/exercise")]
    public class ExerciseController : ControllerBase
    {
        private readonly ILogger<ExerciseController> _logger;
        private readonly IMediator _mediator;

        public ExerciseController(ILogger<ExerciseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new exercise.
        /// </summary>
        /// <param name="command">The command containing the details of the exercise to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created exercise.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result<ExerciseDto>), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result<ExerciseDto>> ExerciseCreate([FromBody] CreateExerciseCommand command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        /// <summary>
        /// Gets all exercises.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of all exercises.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Result<ExerciseDto>), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result<List<ExerciseDto>>> Exercises(CancellationToken cancellationToken)
            => await _mediator.Send(new GetAllExerciseQuery(), cancellationToken);

        /// <summary>
        /// Updates an existing exercise.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Result<ExerciseDto>), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result<ExerciseDto>> UpdateExercise([FromBody] UpdateExerciseCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        /// <summary>
        /// Updates an existing exercise.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Result<ExerciseDto>), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        public async Task<Result> DeleteExercise([FromQuery] DeleteExerciseCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }
    }
}