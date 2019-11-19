namespace McWorld.Web.Controllers
{
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using McWorld.Shared.Queryables;
    using McWorld.Shared.QueryStack;
    using McWorld.User;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<CreateUserCommand> _createUserCommandHandler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserQueryables _userQueryables;

        public UserController(ICommandHandler<
            CreateUserCommand> createUserCommandHandler,
            IUnitOfWork unitOfWork,
            IUserQueryables userQueryables)
        {
            _createUserCommandHandler = createUserCommandHandler;
            _unitOfWork = unitOfWork;
            _userQueryables = userQueryables;
        }


        // GET: api/User/GetAll
        [HttpGet]
        public IEnumerable<Users> GetAll()
        {
            return _userQueryables.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public Users GetById(Guid id)
        {
            return _userQueryables.GetById(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _createUserCommandHandler.ExecuteAsync(new CreateUserCommand(user));
            _unitOfWork.Complete();
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
