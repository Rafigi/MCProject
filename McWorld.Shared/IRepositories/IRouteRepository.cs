namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    public interface IRouteRepository : IRepository<Route>
    {
        Route GetById(Guid id);
    }
}
