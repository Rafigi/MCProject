namespace McWorld.Web.Controllers
{
    using McWorld.Event.Commands;
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
        private readonly UnitOfWork _unitOfWork;
        private readonly IEventQueryables _eventQueryables;

        public EventController
            (
             UnitOfWork unitOfWork,
             IEventQueryables eventQueryables,
            ICommandHandler<CreateEventCommand> createEventCommandHandler,
            ICommandHandler<UpdateEventCommand> updateEventCommandHandler,
            ICommandHandler<DeleteEventCommand> deleteEventCommandHandler
            )
        {
            _createEventCommandHandler = createEventCommandHandler;
            _updateEventCommandHandler = updateEventCommandHandler;
            _deleteEventCommandHandler = deleteEventCommandHandler;
            _unitOfWork = unitOfWork;
            _eventQueryables = eventQueryables;
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

        [HttpGet("userRegistrated/{id}")]
        public IEnumerable<EventDto> GetUserRegistrated(Guid userId)
        {
            return _eventQueryables.GetRegistrated(userId);
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public EventDto GetById(Guid routeId)
        {
            return _eventQueryables.GetById(routeId);
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
        public void UpdateEvent([FromBody] Event @event)
        {
            _updateEventCommandHandler.ExecuteAsync(new UpdateEventCommand(@event));
            _unitOfWork.Complete();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/B{id}")]
        public void Delete(Guid id)
        {
            _deleteEventCommandHandler.ExecuteAsync(new DeleteEventCommand(id));
            _unitOfWork.Complete();
        }
    }
}
