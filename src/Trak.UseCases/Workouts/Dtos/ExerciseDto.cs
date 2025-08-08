using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Workouts.Dtos
{
    public record class ExerciseDto(
            Guid Id,
            string Name,
            int Repetitions,
            double Weight,
            DateTime PerformedAt
        );
}
