namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using McWorld.Shared.QueryStack;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RouteQueryables : IRouteQueryables
    {
        private readonly QueryContext _queryContext;

        public RouteQueryables(QueryContext queryContext)
        {
            _queryContext = queryContext;
        }
        public IEnumerable<RouteDto> GetAll()
        {
            return _queryContext
                .Routes.Select(r => r.AsDto());
        }

        public RouteDto GetById(Guid routeId)
        {
            return _queryContext
                .Routes
                .SingleOrDefault(r => r.RouteId == routeId)
                .AsDto();
        }

        public IEnumerable<RouteDto> GetByUser(Guid UserId)
        {
            return _queryContext
                .Routes
                .Where(u => u.UserId == UserId)
                .Select(r => r.AsDto());
        }

    }
}
