using AutoMapper;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Entities;

namespace Samples.Specifications.Server.Api.Mappers
{
    public class UserMapper
    {
        private readonly IMapper _mapper;

        public UserMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        internal User MapToUser(UserDto userDto) => _mapper.Map<User>(userDto);

        internal UserDto MapToUserDto(User user) => _mapper.Map<UserDto>(user);
    }
}