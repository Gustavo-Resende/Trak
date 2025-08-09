using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valhalla.Lib.SharedKernel;

namespace Trak.Core.WorkoutAggregate
{
    public class Workout : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime Date { get; private set; }

        public Workout(Guid userId, DateTime date)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = date;
        }

        private Workout() { }
    }

    public class Exercise : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public DateTime PerformedAt { get; private set; }
        public string? MuscleGroup { get; private set; }

        public Exercise(string name, DateTime performedAt, string musclegroup)
        {
            Id = Guid.NewGuid();
            Name = name;
            PerformedAt = performedAt;
            MuscleGroup = musclegroup;
        }

        // Para uso do EF Core
        public Exercise() { }
    }

    public class PerformedExercise
    {
        public Guid Id { get; private set; }
        public Guid WorkoutId { get; private set; }
        public Guid ExerciseId { get; private set; }
        public double WeightKg { get; private set; }
        public int Repetitions { get; private set; }
        
        public PerformedExercise(Guid workoutId, Guid exerciseId, int repetitions, double weight)
        {
            Id = Guid.NewGuid();
            WorkoutId = workoutId;
            ExerciseId = exerciseId;
            WeightKg = weight;
            Repetitions = repetitions;
        }
        // Para uso do EF Core
        public PerformedExercise() { }
    }
}
