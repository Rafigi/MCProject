using System;
using System.Collections.Generic;
using MCAPI.Commands;
using MCAPI.Messages;
using MCAPI.Models;
using MCAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        ISession _session;
        public UserController(ISession session, IUnitOfWork unitOfWork)
        {
            _session = session;
            _unitOfWork = unitOfWork;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/User
        [HttpPost("Create")]
        public IActionResult Create([FromBody] User user)
        {
            _session.Add(new CreateUserCommand(user, _unitOfWork));
            _session.Commit();
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
