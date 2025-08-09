using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trak.Core.PlayAggregate;
using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Plays.Dtos;
using Trak.UseCases.Workouts.Dtos;

namespace Trak.UseCases.Workouts.Extensions
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
