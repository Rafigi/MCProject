namespace McWorld.Shared.Queryables
{
    using McWorld.Shared.Dtos;
    using System;
    using System.Collections.Generic;

    public interface IEventQueryables
    {
        /// <summary>
        /// Gets the by Event ID
        /// Returning Null if not exists
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns></returns>
        EventDto GetById(Guid id);
        IEnumerable<EventDto> GetAll();
        /// <summary>
        /// Gets the by User ID
        /// Returning Null if not exists
        /// </summary>
        /// <param name="UserId">The ID.</param>
        /// <returns></returns>
        IEnumerable<EventDto> GetByUser(Guid UserId);
        /// <summary>
        /// Gets the by User ID
        /// Returning Null if not exists
        /// </summary>
        /// <param name="UserId">The ID.</param>
        /// <returns></returns>
        IEnumerable<EventDto> GetUsersRegistered(Guid UserId);
    }
}
