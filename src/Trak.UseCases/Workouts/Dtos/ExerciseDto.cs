using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Workouts.Dtos
{
    public record class ExerciseDto(
        Guid Id,
        Guid WorkoutId,
        string Name,
        string Description,
        int Sets,
        int Repetitions,
        double Weight,
        TimeSpan Duration,
        DateTime CreatedAt,
        DateTime PerformedAt
    );
}
