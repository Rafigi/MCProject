using System;
using System.Collections.Generic;
using MCAPI.Commands;
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
        public UserController(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        // POST: api/User
        [HttpPost("Create")]
        public IActionResult Create([FromBody] User user)
        {
            _serviceBus.Add(new CreateUserCommand(user));
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

        public class Test
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
