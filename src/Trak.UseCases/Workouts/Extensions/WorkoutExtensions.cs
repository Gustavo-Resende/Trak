using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Workouts.Dtos;

namespace Trak.UseCases.Workouts.Extensions
{
    public static class WorkoutExtensions
    {
        public static WorkoutDto ParseDto(this Workout workout)
        {
            return new WorkoutDto(
                workout.Id,
                workout.Date,
                workout.UserId
            );
        }
        public static List<WorkoutDto> ParseDtoList(this IEnumerable<Workout> workout)
        {
            return workout.Select(e => e.ParseDto()).ToList();
        }

    }
}
