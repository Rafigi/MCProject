namespace McWorld.Web.Controllers
{
    using McWorld.Address;
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

        // GET: api/Route/GetAll
        [HttpGet]
        public IEnumerable<Route> GetAll()
        {
            return _routeRepository.GetAll();
        }


        // GET: api/Route/5
        [HttpGet("{id}")]
        public Route GetById(Guid id)
        {
            return _routeRepository.GetRouteByID(id);
        }

        // POST: api/Route/Create
        [HttpPost]
        public IActionResult Create([FromBody] Route route)
        {
            var _route = _routeFactory.Create(route);

            _serviceBus.Add(new CreateAddressCommand(_route.Addresses));
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
        [HttpDelete]
        public void Delete(Guid id)
        {
          
        }
    }
}
