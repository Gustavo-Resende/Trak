using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Exercises.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Exercises.Command.UpdateExercise
{
    public class UpdateExerciseHandler : ICommandHandler<UpdateExerciseCommand, Result<ExerciseDto>>
    {
        private readonly IRepository<Exercise> _exerciseRepository;

        public UpdateExerciseHandler(IRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Result<ExerciseDto>> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.ExerciseId, cancellationToken);
            if (exercise is null)
            {
                return Result.NotFound($"Exercise with ID {request.ExerciseId} not found.");
            }

            var dto = new ExerciseDto(
                exercise.Id,
                request.Name,
                request.PerformedAt,
                request.MuscleGroup
            );

            return Result.Success(dto);

        }
    }
}
