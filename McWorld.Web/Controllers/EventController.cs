namespace McWorld.Web.Controllers
{
    using McWorld.Address;
    using McWorld.Event;
    using McWorld.Route;
    using McWorld.Shared.Factory;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.ServicesBus;
    using McWorld.Shared.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IServiceBus _serviceBus;
        private readonly IEventFactory _eventFactory;
        private readonly IEventRepository _eventRepository;

        public EventController(IServiceBus serviceBus, IEventFactory eventFactory, IEventRepository eventRepository)
        {
            _serviceBus = serviceBus;
            _eventFactory = eventFactory;
            _eventRepository = eventRepository;
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public Event GetById(Guid id)
        {
            return _eventRepository.GetEventByID(id);
        }

        // POST: api/Event
        [HttpPost]
        public void Post([FromBody] Event @event)
        {
            var _event = _eventFactory.Create(@event);
            _serviceBus.Add(new CreateEventCommand(_event));
            _serviceBus.Add(new CreateRouteCommand(_event.Route));
            //_serviceBus.Add(new CreateAddressCommand(_event.Route.RouteAddresses));
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
