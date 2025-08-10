using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Queries
{
    public class GetAllWorkoutHandler : IQueryHandler<GetAllWorkoutQuery, Result<List<WorkoutDto>>>
    {
        private readonly IRepository<Workout> _workoutRepository;
        public GetAllWorkoutHandler(IRepository<Workout> workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<Result<List<WorkoutDto>>> Handle(GetAllWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workouts = await _workoutRepository.ListAsync(cancellationToken);
            if (!workouts.Any())
                return Result.NotFound();

            return Result.Success(workouts.ParseDtoList());

        }
    }
}
