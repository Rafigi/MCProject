namespace McWorld.Web.Controllers
{
    using McWorld.McUser.Commands;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using McWorld.Shared.Queryables;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<CreateUserCommand> _createUserCommandHandler;
        private readonly ICommandHandler<UpdateUserCommand> _updateUserCommandHandler;
        private readonly ICommandHandler<DeleteUserCommand> _deleteUserCommandHandler;
        private readonly ICommandHandler<UpdatePasswordCommand> _updatePasswordcommandHandler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserQueryables _userQueryables;

        public UserController(
            ICommandHandler<CreateUserCommand> createUserCommandHandler,
            ICommandHandler<UpdateUserCommand> updateUserCommandHandler,
            ICommandHandler<DeleteUserCommand> deleteUserCommandHandler,
            ICommandHandler<UpdatePasswordCommand> updatePasswordcommandHandler,
            IUnitOfWork unitOfWork,
            IUserQueryables userQueryables
            )
        {
            _createUserCommandHandler = createUserCommandHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _deleteUserCommandHandler = deleteUserCommandHandler;
            _updatePasswordcommandHandler = updatePasswordcommandHandler;
            _unitOfWork = unitOfWork;
            _userQueryables = userQueryables;
        }

        // GET: api/User/5
        [HttpGet("login")]
        public IActionResult Login(string username, string password)
        {
            var user = _userQueryables.GetByUsername(username);
            if (user.Password == password)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public UserDto GetById(Guid id)
        {
            return _userQueryables.GetById(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (_userQueryables.GetByUsername(user.Username) != null)
                return Ok("The username has been taken");
            if (_userQueryables.GetByMail(user.Email) != null)
                return Ok("There is already a User with that Mail");

            _createUserCommandHandler.ExecuteAsync(new CreateUserCommand(user));
            _unitOfWork.Complete();
            return Ok();
        }

        // PUT: api/User/Update
        [HttpPut("Update/mail")]
        public void UpdateMail([FromBody] User user)
        {
            _updateUserCommandHandler.ExecuteAsync(new UpdateUserCommand(user.UserID, user.Email));
            _unitOfWork.Complete();
        }

        // PUT: api/User/5
        [HttpPut("Update/password")]
        public void UpdatePassword([FromBody] User user)
        {
            _updatePasswordcommandHandler.ExecuteAsync(new UpdatePasswordCommand(user));
            _unitOfWork.Complete();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _deleteUserCommandHandler.ExecuteAsync(new DeleteUserCommand(id));
            _unitOfWork.Complete();
        }
    }
}
