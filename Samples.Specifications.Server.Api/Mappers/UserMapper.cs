using AutoMapper;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Entities;

namespace Samples.Specifications.Server.Api.Mappers
{
    internal static class UserMapper
    {
        internal static User MapToUser(UserDto userDto) => Mapper.Map<User>(userDto);

        internal static UserDto MapToUserDto(User user) => Mapper.Map<UserDto>(user);
    }
}