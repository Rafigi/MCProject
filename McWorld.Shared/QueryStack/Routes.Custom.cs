namespace McWorld.Shared.QueryStack
{
    using McWorld.Shared.Dtos;

    public partial class Routes
    {

        public RouteDto AsDto()
        {
            return new RouteDto()
            {
                RouteID = RouteId,
                Created = Created,
                Distance = Distance,
                Ferry = Ferry,
                Motorway = Motorway,
                Toll = Toll,
            };
        }
    }
}
