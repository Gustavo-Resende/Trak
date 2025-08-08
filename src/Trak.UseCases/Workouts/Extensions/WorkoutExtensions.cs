using System.Collections.Generic;
using System.Linq;
using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Workouts.Dtos;

namespace Trak.UseCases.Workouts.Extensions
{
    public static class WorkoutExtensions
    {
        public static WorkoutDto ToDto(this Workout workout)
            => new(
                workout.Id,
                workout.UserId,
                workout.Date,
                workout.Name,
                workout.Exercises?.Select(e => e.ToDto()).ToList() ?? new List<ExerciseDto>()
            );

        public static ExerciseDto ToDto(this Exercise exercise)
            => new(
                exercise.Id,
                exercise.Name,
                exercise.Repetitions,
                exercise.Weight,
                exercise.PerformedAt
            );

        public static ListWorkoutDto ToListDto(this IEnumerable<Workout> workouts)
            => new(workouts.Select(w => w.ToDto()).ToList());
    }
}