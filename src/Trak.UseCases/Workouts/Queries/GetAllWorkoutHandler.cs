using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Extensions;
using Trak.UseCases.Workouts.Queries;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Queries
{
    public class GetAllWorkoutHandler : IQuery<Result<ListWorkoutDto>>
    {
        private readonly IReadRepository<Workout> _workoutRepository;

        public GetAllWorkoutHandler(IReadRepository<Workout> workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<Result<ListWorkoutDto>> Handle(GetAllWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workouts = await _workoutRepository.ListAsync(cancellationToken);

            if (workouts is null || !workouts.Any())
                return Result.NotFound();

            return Result.Success(workouts.ToListDto());
        }
    }
}