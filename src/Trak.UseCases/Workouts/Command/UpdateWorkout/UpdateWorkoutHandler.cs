using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Exercises.Dtos;
using Trak.UseCases.Workouts.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Command.UpdateWorkout
{
    class UpdateWorkoutHandler : ICommandHandler<UpdateWorkoutCommand, Result<WorkoutDto>>
    {
        private readonly IRepository<Workout> _workoutRepository;
        public UpdateWorkoutHandler(IRepository<Workout> workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        public async Task<Result<WorkoutDto>> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.Id, cancellationToken);
            if (workout is null)
            {
                return Result.NotFound($"Workout with ID {request.Id} not found.");
            }
            
            var dto = new WorkoutDto(
                workout.Id,
                workout.Date,
                workout.UserId
            );

            return Result.Success(dto);
        }
    }
}
