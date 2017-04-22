using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Domain.Services.Storage;
using Samples.Specifications.Server.Host.Data;
using Samples.Specifications.Server.Host.Mappers;

namespace Samples.Specifications.Server.Host.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return _userRepository.GetAll().Select(UserMapper.MapToUserDto);
        }
    }
}