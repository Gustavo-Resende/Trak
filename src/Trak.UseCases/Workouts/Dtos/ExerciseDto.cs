using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Workouts.Dtos
{
    public record ExerciseDto
    {
        public Guid Id { get; private init; }
        public string Name { get; private init; }
        public DateTime PerformedAt { get; private init; }
        public string MuscleGroup { get; private init; }
        public ExerciseDto(Guid id, string name, DateTime performedAt, string muscleGroup)
        {
            Id = id;
            Name = name;
            PerformedAt = performedAt;
            MuscleGroup = muscleGroup;
        }
    }
}
