using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Extensions;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Command.CreateWorkout
{
    public class CreateWorkoutHandler : ICommandHandler<CreateWorkoutCommand, Result<WorkoutDto>>
    {
        private readonly IRepository<Workout> _workoutRepository;
        public CreateWorkoutHandler(IRepository<Workout> workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        public async Task<Result<WorkoutDto>> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = new Workout(request.UserId, request.Date);
            await _workoutRepository.AddAsync(workout, cancellationToken);
            await _workoutRepository.SaveChangesAsync(cancellationToken);
            return Result.Success(workout.ParseDto());
        }
    }
}
