using Trak.UseCases.Workouts.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Queries
{
    public record GetAllWorkoutQuery : IQuery<Result<List<WorkoutDto>>>;
}
