using AutoMapper;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Entities;

namespace Samples.Specifications.Server.Api.Mappers
{
    internal static class UserMapper
    {
        internal static User MapToUser(UserDto userDto)
        {
            var item = Mapper.Map<User>(userDto);
            return item;
        }

        internal static UserDto MapToUserDto(User user)
        {
            return Mapper.Map<UserDto>(user);
        }
    }
}