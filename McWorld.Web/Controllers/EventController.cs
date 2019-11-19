namespace McWorld.Web.Controllers
{
    using McWorld.Event;
    using McWorld.Route;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.Messages;
    using McWorld.Shared.Models;
    using McWorld.Shared.Persistence;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ICommandHandler<CreateEventCommand> _createEventCommandHandler;
        private readonly UnitOfWork _unitOfWork;

        public EventController(ICommandHandler<CreateEventCommand> createEventCommandHandler, UnitOfWork unitOfWork)
        {
            _createEventCommandHandler = createEventCommandHandler;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<EventDto> GetAll()
        {
            return null;
        }

        [HttpGet("{id}")]
        public IEnumerable<EventDto> GetAllUserCreatedEvents(Guid userId)
        {
            return null;
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public Event GetById(Guid id)
        {
            return null;
        }

        // POST: api/Event
        [HttpPost]
        public void Create([FromBody] Event @event)
        {
            _createEventCommandHandler.ExecuteAsync(new CreateEventCommand(@event));
            _unitOfWork.Complete();
        }

        // PUT: api/Event/5
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
