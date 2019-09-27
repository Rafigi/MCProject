namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Queryables : IQueryables
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdresseRepository _adresseRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Queryables(
            IUserRepository userRepository,
            IAdresseRepository adresseRepository,
            IRouteRepository routeRepository,
            IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _adresseRepository = adresseRepository;
            _routeRepository = routeRepository;
            _eventRepository = eventRepository
        }

        public IEnumerable<EventRouteDto> GetAllEventsWithRoutes()
        {
            List<EventRouteDto> eventList = new List<EventRouteDto>();
            var events = _eventRepository.GetAllEvents();
            var routes = _routeRepository.GetAllRoutes();
            var addressess = _adresseRepository.GetAll();
            // TODO Is the user registered?! 
            foreach (var @event in events)
            {
                eventList.Add(new EventRouteDto
                {
                    EventID = @event.EventID,
                    Description = @event.Description,
                    Headline = @event.Headline,
                    StartDate = @event.StartDate,
                    StartTime = @event.StartTime,
                    EndDate = @event.EndDate,
                    EndTime = @event.EndTime,
                    EventCreated = @event.Created,
                    EventUsername = _userRepository.GetUsernameByID(@event.UserID),
                    Route = routes.Single(x => x.RouteID == @event.RouteID),
                    RegistrationCount = @event.RegistrationCount,
                    IsUserRegistered = true
                });
            }
            return eventList;
        }
        public IEnumerable<RouteAdressesDto> GetAllRoutesWithAddress()
        {
            var routes = _routeRepository.GetAllRoutes();
            var addressess = _adresseRepository.GetAll();
            List<RouteAdressesDto> routeList = new List<RouteAdressesDto>();

            foreach (var route in routes)
            {
                routeList.Add(new RouteAdressesDto
                {
                    RouteID = route.RouteID,
                    Created = route.Created,
                    Distance = route.Distance,
                    Ferry = route.Ferry,
                    Motorway = route.Motorway,
                    Toll = route.Toll,
                    Addresses = route.Addresses.ToList()
                });
            }
            return routeList;
        }

        public IEnumerable<EventRouteDto> GetAllUserCreatedEvents(Guid userId)
        {
            List<EventRouteDto> eventList = new List<EventRouteDto>();
            var events = _eventRepository.GetEventsCreatedByUser(userId);
            var routes = _routeRepository.GetAllRoutes();
            // TODO Is the user registered?! 
            foreach (var @event in events)
            {
                eventList.Add(new EventRouteDto
                {
                    EventID = @event.EventID,
                    Description = @event.Description,
                    Headline = @event.Headline,
                    StartDate = @event.StartDate,
                    StartTime = @event.StartTime,
                    EndDate = @event.EndDate,
                    EndTime = @event.EndTime,
                    EventCreated = @event.Created,
                    EventUsername = _userRepository.GetUsernameByID(@event.UserID),
                    Route = routes.Single(x => x.RouteID == @event.RouteID),
                    RegistrationCount = @event.RegistrationCount,
                    IsUserRegistered = true
                });
            }
            return eventList;
        }

        public IEnumerable<RouteAdressesDto> GetAllUserCreatedRoutes(Guid userId)
        {
            var routes = _routeRepository.GetUserCreatedRoutesByID(userId);
            List<RouteAdressesDto> routeList = new List<RouteAdressesDto>();

            foreach (var route in routes)
            {
                routeList.Add(new RouteAdressesDto
                {
                    RouteID = route.RouteID,
                    Created = route.Created,
                    Distance = route.Distance,
                    Ferry = route.Ferry,
                    Motorway = route.Motorway,
                    Toll = route.Toll,
                    Addresses = route.Addresses.ToList()
                });
            }
            return routeList;
        }

        public IEnumerable<RegistrationDto> GetAllUserRegisteredEvents()
        {
            throw new System.NotImplementedException();
        }
    }
}
