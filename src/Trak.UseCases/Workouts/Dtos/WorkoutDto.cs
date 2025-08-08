using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Workouts.Dtos
{
    public record WorkoutDto(Guid Id, Guid UserId, DateTime Date, string Name, List<ExerciseDto> Exercises);
}
