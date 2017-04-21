using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Storage.Contracts;
using Samples.Specifications.Server.Storage.Contracts.Models;

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
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }
    }
}