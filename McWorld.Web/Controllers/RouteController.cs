namespace McWorld.Web.Controllers
{
    using McWorld.Route.Commands;
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
    public class RouteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRouteQueryables _routeQueryables;
        private readonly ICommandHandler<CreateRouteCommand> _createRouteCommandHandler;
        //private readonly ICommandHandler<UpdateRouteCommand> _updateRouteCommandHandler;
        //private readonly ICommandHandler<DeleteRouteCommand> _deleteRouteCommandHandler;

        public RouteController
            (
            IUnitOfWork unitOfWork,
            IRouteQueryables routeQueryables,
            ICommandHandler<CreateRouteCommand> createRouteCommandHandler
            //ICommandHandler<UpdateRouteCommand> updateRouteCommandHandler,
            //ICommandHandler<DeleteRouteCommand> deleteRouteCommandHandler
            )
        {
            _unitOfWork = unitOfWork;
            _routeQueryables = routeQueryables;
            _createRouteCommandHandler = createRouteCommandHandler;
            //_updateRouteCommandHandler = updateRouteCommandHandler;
            //_deleteRouteCommandHandler = deleteRouteCommandHandler;
        }

        // GET: api/Route/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<RouteDto> GetAll()
        {
            return _routeQueryables.GetAll();
        }

        [HttpGet("userCreated/{id}")]
        public IEnumerable<RouteDto> GetAllUserCreatedRoutes(Guid userId)
        {
            return _routeQueryables.GetByUser(userId);
        }


        // GET: api/Route/5
        [HttpGet("{id}")]
        public RouteDto GetById(Guid id)
        {
            return _routeQueryables.GetById(id);
        }

        // POST: api/Route/Create
        [HttpPost]
        public IActionResult Create([FromBody] Route route)
        {
            _createRouteCommandHandler.ExecuteAsync(new CreateRouteCommand(route));
            _unitOfWork.Complete();
            return Ok();
        }

        // PUT: api/Route/5
        [HttpPut("Update")]
        public void Update([FromBody] Route route)
        {
           // _updateRouteCommandHandler.ExecuteAsync(new UpdateRouteCommand(route));
            _unitOfWork.Complete();
        }

        // DELETE: api/route/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            //_deleteRouteCommandHandler.ExecuteAsync(new DeleteRouteCommand(id));
            _unitOfWork.Complete();
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
                Distance = "132",
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
