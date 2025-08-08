using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trak.Core.WorkoutAggregate;
using Trak.UseCases.Plays.Dtos;
using Trak.UseCases.Plays.Queries.GetAllPlay;
using Trak.UseCases.Workouts.Dtos;
using Trak.UseCases.Workouts.Queries;
using Valhalla.Lib.Result;
using Valhalla.Lib.SharedKernel;

namespace Trak.UseCases.Queries
{
    public class GetAllWorkoutHandler : IQuery<GetAllWorkoutQuery, Result<ListWorkoutDto>>
    {
        private readonly IReadRepository<Workout> _workoutRepository;
        public GetAllWorkoutHandler(IReadRepository<Workout> workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
        public async Task<Result<ListWorkoutDto>> Handle(GetAllWorkoutQuery request, CancellationToken cancellationToken)
        {
            var workouts = await _workoutRepository.ListAsync(cancellationToken);

            if (workouts == null || !workouts.Any())
                return Result.NotFound();

            var workoutDtos = new List<WorkoutDto>();

            foreach (var workout in workouts)
            {
                var exerciseDtos = new List<ExerciseDto>();
                if (workout.Exercises != null)
                {
                    foreach (var exercise in workout.Exercises)
                    {
                        // Ajuste para usar o construtor correto de ExerciseDto
                        exerciseDtos.Add(new ExerciseDto(
                            exercise.Id,
                            exercise.Name,
                            exercise.Description,
                            exercise.Sets,
                            exercise.Repetitions,
                            exercise.Weight,
                            exercise.Duration,
                            exercise.PerformedAt,
                            exercise.CreatedAt
                        ));
                    }
                }

                // Ajuste para usar o construtor correto de WorkoutDto
                workoutDtos.Add(new WorkoutDto(
                    workout.Id,
                    workout.UserId,
                    workout.Date,
                    workout.Name,
                    exerciseDtos
                ));
            }

            var resultDto = new ListWorkoutDto(workoutDtos);
            return Result.Success(resultDto);
        }
    }
