using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Workouts.Dtos
{
    public record WorkoutDto
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public DateTime Date { get; init; }
        public WorkoutDto(Guid id, DateTime date, Guid userId)
        {
            Id = id;
            UserId = userId;
            Date = date;
        }
    }
}
