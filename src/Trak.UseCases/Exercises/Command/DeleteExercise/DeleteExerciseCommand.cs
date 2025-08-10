using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Exercises.Command.DeleteExercise
{
    public record DeleteExerciseCommand(
        Guid Id
    ) : ICommand<Result>;
}
