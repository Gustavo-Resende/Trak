using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Exercises.Dtos
{
    public record ExerciseDto
    {
        public Guid Id { get;  init; }
        public string? Name { get;  init; }
        public DateTime PerformedAt { get;  init; }
        public string? MuscleGroup { get;  init; }

        public ExerciseDto(Guid id, string? name, DateTime performedAt, string? muscleGroup)
        {
            Id = id;
            Name = name;
            PerformedAt = performedAt;
            MuscleGroup = muscleGroup;
        }
    }
}
