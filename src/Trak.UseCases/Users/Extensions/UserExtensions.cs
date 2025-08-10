using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trak.Core.UserAggregate;
using Trak.UseCases.Users.Dtos;

namespace Trak.UseCases.Users.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ParseDto(this User user)
        {
            return new UserDto(
                user.Id,
                user.Name,
                user.Email
            );
        }
        public static List<UserDto> ParseDtoList(this IEnumerable<User> users)
        {
            return users.Select(e => e.ParseDto()).ToList();
        }
    }
}
