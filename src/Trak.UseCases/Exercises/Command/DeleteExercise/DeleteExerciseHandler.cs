using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trak.Core.WorkoutAggregate;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Exercises.Command.DeleteExercise
{
    public class DeleteExerciseHander : ICommandHandler<DeleteExerciseCommand, Result>
    {
        private readonly IRepository<Exercise> _exerciseRepository;
        public DeleteExerciseHander(IRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Result> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (exercise is null)
            {
                return Result.NotFound($"Exercise with ID {request.Id} not found.");
            }
            await _exerciseRepository.DeleteAsync(exercise, cancellationToken);
            await _exerciseRepository.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
