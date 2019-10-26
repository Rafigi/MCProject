namespace McWorld.Web.Controllers
{
    using McWorld.Route;
    using McWorld.Shared.Dtos;
    using McWorld.Shared.Factory;
    using McWorld.Shared.Models;
    using McWorld.Shared.Queryables;
    using McWorld.Shared.ServicesBus;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IServiceBus _serviceBus;
        private readonly IRouteFactory _routeFactory;
        private readonly IQueryables _queryables;

        public RouteController(IServiceBus serviceBus, IRouteFactory routeFactory, IQueryables queryables)
        {
            _serviceBus = serviceBus;
            _routeFactory = routeFactory;
            _queryables = queryables;
        }

        // GET: api/Route/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<RouteDto> GetAll()
        {
            return _queryables.GetAllRoutesWithAddress();
        }

        [HttpGet]
        public IEnumerable<RouteDto> GetAllUserCreatedRoutes(Guid userId)
        {
            return _queryables.GetAllUserCreatedRoutes(userId);
        }


        // GET: api/Route/5
        [HttpGet("{id}")]
        public Route GetById(Guid id)
        {
            return null;
        }

        // POST: api/Route/Create
        [HttpPost]
        public IActionResult Create([FromBody] Route route)
        {
            //For creating a mock data
            //var _route = CreateDefaultValues();

            var _route = _routeFactory.Create(route);
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

        //Only for test purpose.
        Route CreateDefaultValues()
        {
            List<Address> _addresses = new List<Address>();

            _addresses.Add(new Address()
            {
                AddressId = Guid.NewGuid(),
                StreetName = "Jyllingevej",
                StreetNumber = "2",
                City = "Kolding",
                Country = "Denmark",
                Zipcode = 6000,
                Latitude = "12132654132432",
                Longitude = "6546546546545"
            });

            _addresses.Add(new Address()
            {
                AddressId = Guid.NewGuid(),
                StreetName = "Vejlevej",
                StreetNumber = "34",
                City = "Vejle",
                Country = "Denmark",
                Zipcode = 7100,
                Latitude = "16554654654564",
                Longitude = "8794546546465"
            });

            var route = new Route()
            {
                RouteID = Guid.NewGuid(),
                Distance = 132,
                Created = new DateTime().ToShortDateString(),
                Ferry = false,
                Toll = false,
                Motorway = true,
                UserID = Guid.Parse("12864cd9-5da3-4124-a837-04717b90784d"),
                Events = null,
                Addresses = _addresses
            };

            return route;
        }
    }
}
