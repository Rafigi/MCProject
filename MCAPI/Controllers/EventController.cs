using MCAPI.Commands;
using MCAPI.Factory;
using MCAPI.Models;
using MCAPI.ServicesBus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IServiceBus _serviceBus;
        IEventFactory _eventFactory;
        public EventController(IServiceBus serviceBus, IEventFactory eventFactory)
        {
            _serviceBus = serviceBus;
            _eventFactory = eventFactory;
        }
        // GET: api/Event
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Event
        [HttpPost]
        public void Post([FromBody] Event @event)
        {
            var _event = _eventFactory.Create(@event);
            _serviceBus.Add(new CreateEventCommand(_event));
            _serviceBus.Add(new CreateRouteCommand(_event.Route));
            _serviceBus.Add(new CreateAddressCommand(_event.Route.Address));
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
