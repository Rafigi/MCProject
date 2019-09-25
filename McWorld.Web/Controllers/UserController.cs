
namespace McWorld.Web.Controllers
{
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using McWorld.Shared.ServicesBus;
    using Microsoft.AspNetCore.Mvc;
    using McWorld.User;
    using System;
    using System.Collections.Generic;
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
        // GET: api/User/GetAll
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User GetById(Guid id)
        {
            return _userRepository.GetUserByID(id);
        }

        // POST: api/User
        [HttpPost]
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
        public void Delete(int id)
        {
        }
    }
}
