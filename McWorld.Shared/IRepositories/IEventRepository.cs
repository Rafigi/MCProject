namespace McWorld.Shared.IRepository
{
    using McWorld.Shared.Models;
    using System;
    using System.Collections.Generic;
    public interface IEventRepository : IRepository<Event>
    {
        /// <summary>
        /// Gets the by ID.
        /// Returning Null if Not Exists
        /// </summary>
        /// <param name="id">The Id.</param>
        /// <returns></returns>
        Event GetById(Guid id);
        IEnumerable<Registration> GetAllEventsWhereUserIsRegistered(Guid userId);
        Registration GetRegistrationByUserId(Guid? userId, Guid eventId);

        void RegisterUser(Guid? userId, Guid eventId);

        void UnRegisterUser(Guid? userId, Guid eventId);
    }
}
