using Trak.UseCases.Exercises.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Exercises.Queries
{
    public record GetAllExerciseQuery : IQuery<Result<List<ExerciseDto>>>;
}
