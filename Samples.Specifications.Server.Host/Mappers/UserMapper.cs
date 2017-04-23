using AutoMapper;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Host.Data;

namespace Samples.Specifications.Server.Host.Mappers
{
    static class UserMapper
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