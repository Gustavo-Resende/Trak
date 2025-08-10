using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trak.UseCases.Users.Dtos
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string? Username { get; init; }
        public string? Email { get; init; }
        public UserDto(Guid id, string? username, string? email)
        {
            Id = id;
            Username = username;
            Email = email;
        }
    }
}
