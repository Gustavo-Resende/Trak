using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trak.UseCases.Exercises.Dtos;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Exercises.Command.CreateExercise
{
    public record CreateExerciseCommand(
        string Name,
        DateTime PerformedAt,
        string MuscleGroup
    ) : ICommand<Result<ExerciseDto>>;
}
