using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Workouts.Dtos
{
    public record ListWorkoutDto(List<WorkoutDto> Workouts);
}
