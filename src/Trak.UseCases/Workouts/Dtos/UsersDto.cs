using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Workouts.Dtos
{
    record UsersDto
    {
        public Guid Id { get; private init; }
        public string? Name { get; private init; }
        public string? Email { get; private init; }

        public UsersDto(Guid id, string? name, string? email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
