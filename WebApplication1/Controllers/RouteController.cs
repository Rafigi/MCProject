

namespace MCAPI.McWorld.Web.Controllers
{
    using MCAPI.McWorld.Shared.Models;
    using MCAPI.McWorld.Shared.Factory;
    using MCAPI.McWorld.Shared.IRepository;
    using MCAPI.McWorld.Shared.ServicesBus;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using MCAPI.McWorld.Address;
    using MCAPI.McWorld.Route;

    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IServiceBus _serviceBus;
        private readonly IRouteFactory _routeFactory;
        private readonly IRouteRepository _routeRepository;
        public RouteController(IServiceBus serviceBus, IRouteFactory routeFactory, IRouteRepository routeRepository)
        {
            _serviceBus = serviceBus;
            _routeFactory = routeFactory;
            _routeRepository = routeRepository;
        }

        // GET: api/Route By ID
        [HttpGet("{id}")]
        public Route Get(Guid id)
        {
            return _routeRepository.GetRouteByID(id);
        }
        // GET: api/Route
        [HttpGet]
        public IEnumerable<Route> Get()
        {
            return _routeRepository.GetAll();
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
        public void Delete(Route route)
        {
            _routeRepository.Remove(route);
        }
    }
}
