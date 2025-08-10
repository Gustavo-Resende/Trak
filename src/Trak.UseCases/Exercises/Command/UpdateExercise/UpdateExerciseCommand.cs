using Trak.UseCases.Exercises.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Exercises.Command.UpdateExercise
{
    public record UpdateExerciseCommand(
        Guid ExerciseId,
        string Name,
        DateTime PerformedAt,
        string MuscleGroup
    ) : ICommand<Result<ExerciseDto>>;
}