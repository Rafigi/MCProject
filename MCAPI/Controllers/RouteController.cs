using MCAPI.Commands;
using MCAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MCAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        //Interfaces
        ICommandSender _commandSender;

        public RouteController(ICommandSender commandSender)
        {
            _commandSender = commandSender;
        }
        // GET: api/Route
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Route
        [HttpPost]
        public void CreateRoute([FromBody] Route route)
        {
            _commandSender.Send(new CreateRouteCommand(Guid.NewGuid(), route));
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
