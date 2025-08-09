using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Queries
{
    public class GetAllExerciseHandler : IQueryHandler<GetAllExerciseQuery, Result<List<ExerciseDto>>>
    {
        private readonly IReadRepository<Exercise> _exerciseRepository;
        public GetAllExerciseHandler(IReadRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Result<List<ExerciseDto>>> Handle(GetAllExerciseQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepository.ListAsync(cancellationToken);
            if (!exercises.Any())
                return Result.NotFound();

            return Result.Success(exercises.ParseDtoList());
        }
    }
}
