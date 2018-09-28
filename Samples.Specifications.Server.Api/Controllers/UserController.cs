using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Api.Mappers;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Services.Storage;

namespace Samples.Specifications.Server.Api.Controllers
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