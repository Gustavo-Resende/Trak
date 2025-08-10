using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Exercises.Dtos;

namespace Trak.UseCases.Exercises.Extensions
{
    public static class ExerciseExtensions
    {
        public static ExerciseDto ParseDto(this Exercise exercise)
        {
            return new ExerciseDto(
                exercise.Id,
                exercise.Name ?? string.Empty,
                exercise.PerformedAt,
                exercise.MuscleGroup ?? string.Empty
            );
        }

        public static List<ExerciseDto> ParseDtoList(this IEnumerable<Exercise> exercises)
        {
            return exercises.Select(e => e.ParseDto()).ToList();
        }
    }
}
