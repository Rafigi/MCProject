namespace McWorld.Shared.Repository
{
    using McWorld.Shared.Data;
    using McWorld.Shared.IRepository;
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(McDbContext context) : base(context)
        {
        }

        public IEnumerable<Event> GetCreatedByUser(Guid id)
        {
            return McDbContext.Events.Where(x => x.User.UserID == id).ToList();
        }

        public Event GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"There is no event with the ID {id}");

            return McDbContext.Events.Single(x => x.EventID == id);
        }

        public IEnumerable<Registration> GetAllEventsWhereUserIsRegistered(Guid userId)
        {
            return McDbContext.Registration
                .Where(u => u.UserID == userId)
                .ToList();
        }

        public Registration GetRegistrationByUserId(Guid? userId, Guid eventId)
        {
            return McDbContext.Registration.Single(u => u.UserID == userId && u.EventID == eventId);
        }

        public void RegisterUser(Guid? userId, Guid eventId)
        {
            var registration = GetRegistrationByUserId(userId, eventId);
            McDbContext.Registration.Add(registration);
        }

        public void UnRegisterUser(Guid? userId, Guid eventId)
        {
            var registration = GetRegistrationByUserId(userId, eventId);
            McDbContext.Registration.Remove(registration);
        }

        public McDbContext McDbContext
        {
            get { return _context as McDbContext; }
        }
    }
}
