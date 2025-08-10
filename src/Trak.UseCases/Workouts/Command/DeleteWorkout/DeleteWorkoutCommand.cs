using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Workouts.Command.DeleteWorkout
{
    public record DeleteWorkoutCommand(Guid Id) : ICommand<Result>;
}
