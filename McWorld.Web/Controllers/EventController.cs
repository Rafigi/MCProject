namespace McWorld.Web.Controllers
{
    using McWorld.McEvent.Commands;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using McWorld.Shared.Queryables;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ICommandHandler<CreateEventCommand> _createEventCommandHandler;
        private readonly ICommandHandler<UpdateEventCommand> _updateEventCommandHandler;
        private readonly ICommandHandler<DeleteEventCommand> _deleteEventCommandHandler;
        private readonly ICommandHandler<RegisterUserOnEventCommand> _registerUserOnEventCommand;
        private readonly ICommandHandler<UnRegisterUserOnEventCommand> _unRegisterUserOnEventCommand;
        private readonly IEventQueryables _eventQueryables;
        private readonly IUnitOfWork _unitOfWork;

        public EventController
            (
             IUnitOfWork unitOfWork,
             IEventQueryables eventQueryables,
            ICommandHandler<CreateEventCommand> createEventCommandHandler,
            ICommandHandler<UpdateEventCommand> updateEventCommandHandler,
            ICommandHandler<DeleteEventCommand> deleteEventCommandHandler,
            ICommandHandler<RegisterUserOnEventCommand> registerUserOnEventCommand,
            ICommandHandler<UnRegisterUserOnEventCommand> unRegisterUserOnEventCommand
            )
        {
            _createEventCommandHandler = createEventCommandHandler;
            _updateEventCommandHandler = updateEventCommandHandler;
            _deleteEventCommandHandler = deleteEventCommandHandler;
            _registerUserOnEventCommand = registerUserOnEventCommand;
            _unRegisterUserOnEventCommand = unRegisterUserOnEventCommand;
            _eventQueryables = eventQueryables;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<EventDto> GetAll()
        {
            return _eventQueryables.GetAll();
        }

        [HttpGet("{id}")]
        public IEnumerable<EventDto> GetAllUserCreatedEvents(Guid userId)
        {
            return _eventQueryables.GetByUser(userId);
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public EventDto GetById(Guid routeId)
        {
            return _eventQueryables.GetById(routeId);
        }

        [HttpGet("userRegistrated/{id}")]
        public IEnumerable<EventDto> GetUserRegistrated(Guid userId)
        {
            return _eventQueryables.GetUsersRegistered(userId);
        }


        // POST: api/Event
        [HttpPost]
        public void Create([FromBody] Event @event)
        {
            _createEventCommandHandler.ExecuteAsync(new CreateEventCommand(@event));
            _unitOfWork.Complete();
        }

        // PUT: api/Event/5
        [HttpPut("update")]
        public void Update([FromBody] Event @event)
        {
            _updateEventCommandHandler.ExecuteAsync(new UpdateEventCommand(@event));
            _unitOfWork.Complete();
        }


        // PUT: api/Event/registerUser
        [HttpPut("registerUser")]
        public void RegisterUser([FromBody] Registration registration)
        {
            _registerUserOnEventCommand.ExecuteAsync(new RegisterUserOnEventCommand(registration.EventID, registration.UserID));
            _unitOfWork.Complete();
        }


        // PUT: api/Event/unRegisterUser
        [HttpPut("unRegisterUser")]
        public void UnRegisterUser([FromBody] Registration registration)
        {
            _unRegisterUserOnEventCommand.ExecuteAsync(new UnRegisterUserOnEventCommand(registration.EventID, registration.UserID));
            _unitOfWork.Complete();
        }

        // DELETE: api/event/5
        [HttpDelete("delete/{id}")]
        public void Delete(Guid id)
        {
            _deleteEventCommandHandler.ExecuteAsync(new DeleteEventCommand(id));
            _unitOfWork.Complete();
        }
    }
}
