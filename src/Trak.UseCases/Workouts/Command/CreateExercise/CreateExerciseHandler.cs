using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Command.CreateExercise
{
    public class CreateExerciseHandler : ICommandHandler<CreateExerciseCommand, Result<ExerciseDto>>
    {
        private readonly IRepository<Exercise> _exerciseRepository;

        public CreateExerciseHandler(IRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Result<ExerciseDto>> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {

            var exercise = new Exercise(request.Name, request.PerformedAt, request.MuscleGroup);
            var newExercise = await _exerciseRepository.AddAsync(exercise, cancellationToken);

            await _exerciseRepository.SaveChangesAsync(cancellationToken);
            return Result.Success(newExercise.ParseDto());
        }
    }
}
