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
    public class RouteController : ControllerBase
    {
        private readonly IServiceBus _serviceBus;
        private readonly IRouteFactory _routeFactory;
        public RouteController(IServiceBus serviceBus, IRouteFactory routeFactory )
        {
            _serviceBus = serviceBus;
            _routeFactory = routeFactory;
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
            var _route = _routeFactory.Create(route);

            _serviceBus.Add(new CreateAddressCommand(_route.Address));
            _serviceBus.Add(new CreateRouteCommand(_route));
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
