using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trak.UseCases.Workouts.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Queries
{
    public record GetAllWorkoutQuery : IQuery<Result<List<WorkoutDto>>>;
}
