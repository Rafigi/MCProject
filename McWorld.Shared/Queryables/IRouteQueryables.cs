
namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;

    interface IRouteQueryables
    {
        Route GetById(Guid id);
        IEnumerable<Route> GetAll();
        IEnumerable<Route> GetByUser(Guid UserId);
    }
}
