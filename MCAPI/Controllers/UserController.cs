using System;
using System.Collections.Generic;
using MCAPI.Commands;
using MCAPI.Factory;
using MCAPI.IRepository;
using MCAPI.Messages;
using MCAPI.Models;
using MCAPI.Persistence;
using MCAPI.ServicesBus;
using Microsoft.AspNetCore.Mvc;

namespace MCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceBus _serviceBus;
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        public UserController(IServiceBus serviceBus, IUserFactory userFactory, IUserRepository userRepository)
        {
            _serviceBus = serviceBus;
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public User GetUser(Guid id)
        {
            return _userRepository.GetUserByID(id);
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        // POST: api/User
        [HttpPost("Create")]
        public IActionResult Create([FromBody] User user)
        {
            _serviceBus.Add(new CreateUserCommand(_userFactory.Create(user)));
            _serviceBus.Complete();
            return Ok();
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(User user)
        {
            _userRepository.Remove(user);
        }
    }
}
