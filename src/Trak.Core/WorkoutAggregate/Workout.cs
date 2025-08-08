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
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

        public Workout(Guid userId, DateTime date, string name)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Date = date;
            Name = name;
            Exercises = new List<Exercise>();
        }

        private Workout() { }
    }

    public class Exercise
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int Repetitions { get; private set; }
        public DateTime PerformedAt { get; private set; }

        public Exercise(string name, double weight, int repetitions, DateTime performedAt)
        {
            Id = Guid.NewGuid();
            Name = name;
            Weight = weight;
            Repetitions = repetitions;
            PerformedAt = performedAt;
        }

        // Para uso do EF Core
        public Exercise() { }
    }
}
