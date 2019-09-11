using MCAPI.Commands;
using MCAPI.Models;
using MCAPI.ServicesBus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IServiceBus _serviceBus;
        public RouteController(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }
        // GET: api/Route
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Route
        [HttpPost]
        public IActionResult CreateRoute([FromBody] Route route)
        {
            var addressId = Guid.NewGuid();
            _serviceBus.Add(new CreateAddressCommand(addressId, route.Address));
            _serviceBus.Add(new CreateRouteCommand(addressId, route));
            _serviceBus.Complete();
            return Ok();
        }

        // PUT: api/Route/5
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
